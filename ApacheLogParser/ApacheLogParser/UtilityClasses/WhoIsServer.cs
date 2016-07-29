using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApacheLogParser.Interfaces;
using System.Net.Sockets;
using System.IO;

namespace ApacheLogParser.UtilityClasses
{
	public class WhoIsServer : IWhoIsProvider
	{
		public static int whoIsPort = 43;

		public string ServerAddr { get; set; }

		public WhoIsServer(string serverAddr)
		{
			ServerAddr = serverAddr;
		}

		public string WhoIs(string address)
		{
			//Сервер whois.ripe.net выдаёт самую подробную инфу
			//Предположительно, название организации-владельца находится в графе
			//netname:        KHARKOV-MAXNET-N3 (к примеру)

			string result = null;

			string txtResponse = "";
			string strResponse = "";

			try
			{
				TcpClient tcpWhois = new TcpClient(ServerAddr, whoIsPort);
				NetworkStream nsWhois = tcpWhois.GetStream();
				BufferedStream bfWhois = new BufferedStream(nsWhois);

				StreamWriter swSend = new StreamWriter(bfWhois);
				swSend.WriteLine(address);
				swSend.Flush();

				StreamReader srReceive = new StreamReader(bfWhois);

				while ((strResponse = srReceive.ReadLine()) != null)
				{
					txtResponse += strResponse + "\r\n";
				}

				tcpWhois.Close();

				result = txtResponse;
			}
			catch { }
			return result;
		}
	}
}
