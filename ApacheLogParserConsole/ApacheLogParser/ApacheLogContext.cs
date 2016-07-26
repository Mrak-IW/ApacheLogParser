using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using ApacheLogParser.Delegates;

namespace ApacheLogParser
{
	public class ApacheLogContext : DbContext
	{
		public DbSet<ApacheLogEntry> LogEntries { get; set; }
		public DbSet<Ip> IpAddresses { get; set; }
		public DbSet<FileData> Files { get; set; }

		static ApacheLogContext()
		{
			Database.SetInitializer<ApacheLogContext>(new ApacheLogContextInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			////Шаманство для UNIQUE на столбце имени файла
			//modelBuilder.Entity<FileData>()
			//	.Property(fd => fd.FullName).HasColumnAnnotation(IndexAnnotation.AnnotationName,
			//		new IndexAnnotation(
			//		new IndexAttribute("IX_UniqueFileName") { IsUnique = true }));

			//Шаманство для UNIQUE на столбце IP-адреса
			modelBuilder.Entity<Ip>()
				.Property(ip => ip.IpAddr).HasColumnAnnotation(IndexAnnotation.AnnotationName,
					new IndexAnnotation(
					new IndexAttribute("IX_UniqueIp") { IsUnique = true }));
		}

		public void ParseLog(Stream inputStream, string[] skipList = null, int startIndex = 1, int count = -1, SendMessage writeLogCallback = null)
		{
			if (skipList == null)
			{
				skipList = new string[0];
			}

			AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
			ApacheLogContext database = new ApacheLogContext();

			StreamReader inputFile = new StreamReader(inputStream);
			DateTime start = DateTime.Now;
			int added = 0;
			int skipped = 0;
			int duplicateFound = 0;
			int errorFound = 0;
			int i;
			for (i = 1; !inputFile.EndOfStream && (i < startIndex + count || count < 1); i++)
			{
				string teststr = inputFile.ReadLine();

				if (i < startIndex)
				{
					continue;
				}

				ApacheLogEntry ale = null;
				ale = ApacheLogEntry.TryParse(teststr);

				if (ale != null)
				{
					bool skip = ale.File.FileType != null && skipList.Contains(ale.File.FileType.ToLower());
					if (!skip)
					{
						var entryMatches = from e in database.LogEntries
										   where e.Date.Equals(ale.Date)
										   select e;

						ApacheLogEntry entryFound = null;
						foreach (ApacheLogEntry e in entryMatches)
						{
							if (e.Equals(ale))
							{
								entryFound = e;
								break;
							}
						}

						if (entryFound == null)
						{

							var ipMatches = from ip in database.IpAddresses
											where ip.IpAddr == ale.IpAddress.IpAddr
											select ip;
							Ip ipFound = ipMatches.FirstOrDefault();
							if (ipFound != null)
							{
								ale.IpAddress = ipFound;
							}
							else
							{
								database.IpAddresses.Add(ale.IpAddress);
							}

							var fileMatches = from f in database.Files
											  where f.FullName == ale.File.FullName
											  select f;
							FileData fileFound = fileMatches.FirstOrDefault();
							if (fileFound != null)
							{
								ale.File = fileFound;
							}
							else
							{
								database.Files.Add(ale.File);
							}

							database.LogEntries.Add(ale);
							database.SaveChanges();
							added++;
						}
						else
						{
							duplicateFound++;
						}

						if (i % 100 == 0)
						{
							DateTime end = DateTime.Now;
							TimeSpan diff = end - start;
							start = end;
							writeLogCallback?.Invoke(String.Format("Обработано {0} строк [+{1} s]", i, diff.TotalSeconds.ToString("F4")));
						}
					}
					else
					{
						skipped++;
					}
				}
				else
				{
					writeLogCallback?.Invoke(String.Format("Ошибка в строке {0}", i));
					errorFound++;
				}
			}

			if (writeLogCallback != null)
			{
				writeLogCallback(String.Format("Обработано {0} строк", i - 1));
				writeLogCallback(String.Format("Отфильтровано по типу файла {0} строк", skipped));
				writeLogCallback(String.Format("Отброшено из-за ошибки парсинга {0} строк", errorFound));
				writeLogCallback(String.Format("Отброшено для предотвращения дублирования {0} строк", duplicateFound));
				writeLogCallback(String.Format("Добавлено в базу {0} строк", added));
			}
		}
	}
}
