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
			WebHelper.Whois("172.0.0.1", "whois.nic.ru", 43);
		}
	}
}

