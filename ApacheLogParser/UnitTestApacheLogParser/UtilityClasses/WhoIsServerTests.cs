using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApacheLogParser.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApacheLogParser.Interfaces;

namespace ApacheLogParser.UtilityClasses.Tests
{
	[TestClass]
	public class WhoIsServerTests
	{
		[TestMethod]
		public void WhoIsServer_WhoIsTest()
		{
			IWhoIsProvider whois = new WhoIsServer("whois.ripe.net");

			//who.is
			//whois.arin.net
			//whois.ripe.net - наиболее полная инфа
			//iana.org		 - очень скудная инфа
			string[] ipList = new string[] {
				"207.46.13.134",
				"178.165.12.172",
				"66.249.69.136",
				"bash.im"
			};

			foreach (string ip in ipList)
			{
				try
				{
					string result = whois.WhoIs(ip);
					Console.WriteLine(result);
					Console.WriteLine(new string('*', 20));
				}
				catch
				{
					Assert.Fail(String.Format("Сбой получения инфы об адресе {0}", ip));
				}
			}
		}
	}
}