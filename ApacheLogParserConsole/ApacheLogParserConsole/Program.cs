using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ApacheLogParser;

namespace ApacheLogParserConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

			if (args.Length == 1 && File.Exists(args[0]))
			{
				Console.WriteLine("Файл существует");
			}

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

			database.SaveChanges();
		}
	}
}
