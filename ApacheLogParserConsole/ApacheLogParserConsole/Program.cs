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
			AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
			ApacheLogContext database = new ApacheLogContext();

			var log = database.LogEntries;

			foreach (var item in log)
			{
				Console.WriteLine(item.Date);
				Console.WriteLine(item.File);
				Console.WriteLine(item.File.PageTitle);
				Console.WriteLine(item.IpAddress);
				Console.WriteLine(item.QueryType);
				Console.WriteLine(item.QueryResult);
			}

			if (args.Length == 1 && File.Exists(args[0]))
			{
				Console.WriteLine("Файл существует");

				StreamReader inputFile = new StreamReader(args[0]);
				DateTime start = DateTime.Now;
				int i = 0;
				while (!inputFile.EndOfStream)
				{
					i++;
					string teststr = inputFile.ReadLine();
					ApacheLogEntry ale = null;
					ale = ApacheLogEntry.TryParse(teststr);
					if (ale != null)
					{
						//var testIp =
						//	from ip in database.IpAddresses
						//	where ip.IpAddr == ale.IpAddress.IpAddr
						//	select ip;
						bool match = false;
						foreach (Ip ip in database.IpAddresses)
						{
							if (ip.Equals(ale.IpAddress))
							{
								match = true;
								ale.IpAddress = ip;
								break;
							}
						}
						if (!match)
						{
							database.IpAddresses.Add(ale.IpAddress);
						}

						match = false;
						foreach (FileData file in database.Files)
						{
							if (file.Equals(ale.File))
							{
								match = true;
								ale.File = file;
								break;
							}
						}
						if (!match)
						{
							database.Files.Add(ale.File);
						}

						database.LogEntries.Add(ale);
						database.SaveChanges();

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
						Console.WriteLine("Ошибка в строке {0}", i);
					}
				}
			}
			else
			{
				Console.WriteLine("Файла не существует");
			}
		}
	}
}
