using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Sockets;

namespace ApacheLogParser
{
	public static class WebHelper
	{
		public static string Whois(string ip, string whoisServer, int port)
		{
			throw new NotImplementedException("TODO: узнать, как подключаться к серверу whois");
			//Возможно, у меня это не работает из-за прокси. Проверить. 

			string result = null;

			string txtResponse = "";
			string strResponse = "";

			TcpClient tcpWhois = new TcpClient(whoisServer, port);
			NetworkStream nsWhois = tcpWhois.GetStream();
			BufferedStream bfWhois = new BufferedStream(nsWhois);

			StreamWriter swSend = new StreamWriter(bfWhois);
			swSend.WriteLine(ip);
			swSend.Flush();

			StreamReader srReceive = new StreamReader(bfWhois);

			while ((strResponse = srReceive.ReadLine()) != null)
			{
				txtResponse += strResponse + "\r\n";
			}

			tcpWhois.Close();

			return result;
		}

		public static string GetPageTitle(string pageURI)
		{
			string result = null;
			char[] buf = new char[2000];

			HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create(pageURI);
			proxy_request.Method = "GET";
			proxy_request.ContentType = "application/x-www-form-urlencoded";
			proxy_request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/532.5 (KHTML, like Gecko) Chrome/4.0.249.89 Safari/532.5";
			proxy_request.KeepAlive = true;
			//Попытаемся скачать только первые пару килобайт
			HttpWebResponse resp = proxy_request.GetResponse() as HttpWebResponse;
			if (resp.StatusCode == HttpStatusCode.OK)
			{
				string html = "";
				using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding(1251)))
					sr.ReadBlock(buf, 0, buf.Length);
				html = new string(buf).Trim();

				Regex pattern = new Regex("<title>(.*?)</title>");
				Match match = pattern.Match(html);
				if (match.Success)
				{
					GroupCollection groups = match.Groups;
					result = groups[1].Value;
				}
			}
			return result;
		}
	}
}
