using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ApacheLogParser;

namespace ApacheLogParser.Tests
{
	[TestClass]
	public class UnitTestWebHelper
	{
		[TestMethod]
		public void GetPageTitleTest()
		{
			string pageURI = "http://bash.im";
			//"http://www.tariscope.com";
			string title = WebHelper.GetPageTitle(pageURI);
			Assert.AreEqual("Цитатник Рунета", title);
		}

		[TestMethod]
		public void WhoisTest()
		{
			//who.is
			//whois.arin.net
			//whois.ripe.net - наиболее полная инфа
			//iana.org		 - очень скудная инфа
			string[] ipList = new string[] {
				"207.46.13.134",
				"178.165.12.172",
				"66.249.69.136"
			};

			foreach (string ip in ipList)
			{
				string result = WebHelper.Whois(ip, "whois.ripe.net", 43);
				Console.WriteLine(result);
				Console.WriteLine(new string('*', 20));
			}
		}
	}
}

