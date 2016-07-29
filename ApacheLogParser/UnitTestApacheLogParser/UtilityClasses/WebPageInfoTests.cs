using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApacheLogParser.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheLogParser.UtilityClasses.Tests
{
	[TestClass]
	public class WebPageInfoTests
	{
		[TestMethod]
		public void WebPageInfo_ConstructorTest()
		{
			WebPageInfo wp;
			string[] testList = new string[] {
				"http://bash.im",
				"http://sinoptik.ua"
			};
			foreach (string addr in testList)
			{
				try
				{
					wp = new WebPageInfo(addr);
					Console.WriteLine("{0} : [{2}] {1}", addr, wp.Title, wp.PageEncoding.WebName);
				}
				catch
				{
					Assert.Fail(String.Format("Сбой получения информации. Адрес: {0}"));
				}
			}

			//А теперь присвоим адрес вручную
			wp = new WebPageInfo(testList[0]);
			Console.WriteLine("{0} : [{2}] {1}", testList[0], wp.Title, wp.PageEncoding.WebName);

			wp.URI = testList[1];
			Console.WriteLine("{0} : [{2}] {1}", testList[1], wp.Title, wp.PageEncoding.WebName);


		}
	}
}