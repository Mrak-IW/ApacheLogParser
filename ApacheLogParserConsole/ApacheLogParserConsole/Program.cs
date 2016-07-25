using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ApacheLogParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApacheLogParserConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] skipList = new string[] {
				"jpg",
				"jpeg",
				"png",
				"bmp",
				"gif",
				"js",
				"css",
			};
			AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
			ApacheLogContext database = new ApacheLogContext();

			int startIndex = 1, count = -1;
			if (args.Length > 1)
			{
				int.TryParse(args[1], out startIndex);
			}
			if (args.Length > 2)
			{
				int.TryParse(args[2], out count);
			}

			if (args.Length > 0 && File.Exists(args[0]))
			{
				Console.WriteLine("Файл существует");

				StreamReader inputFile = new StreamReader(args[0]);
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
								Console.WriteLine("Обработано {0} строк [+{1} s]", i, diff.TotalSeconds.ToString("F4"));
							}
						}
						else
						{
							skipped++;
						}
					}
					else
					{
						Console.WriteLine("Ошибка в строке {0}", i);
						errorFound++;
					}
				}

				Console.WriteLine("");
				Console.WriteLine("Обработано {0} строк", i - 1);
				Console.WriteLine("Отфильтровано по типу файла {0} строк", skipped);
				Console.WriteLine("Отброшено из-за ошибки парсинга {0} строк", errorFound);
				Console.WriteLine("Отброшено для предотвращения дублирования {0} строк", duplicateFound);
				Console.WriteLine("Добавлено в базу {0} строк", added);
			}
			else
			{
				Console.WriteLine("Файла не существует");
			}
		}
	}
}
