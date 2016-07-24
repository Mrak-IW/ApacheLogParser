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
				int i = 0;
				while (!inputFile.EndOfStream && i++ < 10)
				{
					string teststr = inputFile.ReadLine();
					ApacheLogEntry ale = ApacheLogEntry.TryParse(teststr);
					if (ale != null)
					{
						//var testIp = 
						//	from ip in database.IpAddresses
						//	where ip.IpAddr
						database.IpAddresses.Add(ale.IpAddress);
						database.Files.Add(ale.File);
						database.LogEntries.Add(ale);
						database.SaveChanges();
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
