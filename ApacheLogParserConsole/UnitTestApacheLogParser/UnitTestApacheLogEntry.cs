using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApacheLogParser;
using System.IO;
using System.Linq;

namespace UnitTestApacheLogParser
{
	[TestClass]
	public class UnitTestApacheLogEntry
	{
		[TestMethod]
		public void ApacheLogEntry_TryParse()
		{
			int[] logStringNumbers = new int[] {
				1,
				2,
				6,
				13,
				959,
				961,
				963,
				1371,
				2402,
			};
			string path = AppDomain.CurrentDomain.BaseDirectory;
			string filename = "tariscope.com.access.log";
			string fullname = String.Format("{0}/{1}", path, filename);
			Assert.IsTrue(File.Exists(fullname), "Файл с логом не существует в рабочей папке теста");

			StreamReader logfile = new StreamReader(fullname);
			for (int i = 1; i <= logStringNumbers.Max(); i++)
			{
				string str = logfile.ReadLine();
				if (logStringNumbers.Contains(i))
				{
					ApacheLogEntry le = ApacheLogEntry.TryParse(str);
					Assert.IsNotNull(le, String.Format("Строка {0} : {1}", i, str));
				}
			}
		}
	}
}
