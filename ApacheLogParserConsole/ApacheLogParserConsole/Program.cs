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
		static Program()
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
		}

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
			
			using (ApacheLogContext database = new ApacheLogContext())
			{
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

					using (Stream inputFile = new FileStream(args[0], FileMode.Open))
					{
						database.ParseLog(inputFile, skipList, startIndex, count, Console.WriteLine);
					}
				}
				else
				{
					Console.WriteLine("Файла не существует");
				}
			}
		}
	}
}
