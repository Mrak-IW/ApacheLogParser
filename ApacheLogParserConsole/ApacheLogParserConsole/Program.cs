using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ApacheLogParserConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 1 && File.Exists(args[0]))
			{
				Console.WriteLine("Файл существует");
			}
		}
	}
}
