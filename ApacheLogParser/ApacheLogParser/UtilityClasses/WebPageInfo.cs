using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

using ApacheLogParser.Interfaces;

namespace ApacheLogParser.UtilityClasses
{
	public class WebPageInfo : IWebPageInfo
	{
		public static readonly Encoding defaultEncoding;
		public static int defaultBlockSize;

		private Encoding enc;

		public string URI { get; protected set; }
		public string Title { get; protected set; }

		static WebPageInfo()
		{
			defaultEncoding = Encoding.GetEncoding(1251);
			defaultBlockSize = 1000;
		}

		public WebPageInfo(string pageURI)
		{
			URI = pageURI;

			byte[] bytes = ReadBytes(0, defaultBlockSize);

			PageEncoding = GetHtmlCharset(bytes);
			Decoder dec = PageEncoding.GetDecoder();

			char[] chars = new char[bytes.Length];
			int count = dec.GetChars(bytes, 0, bytes.Length, chars, 0);
			string html = new string(chars);

			Title = GetHtmlTitle(html);
		}

		public Encoding PageEncoding
		{
			get
			{
				return enc ?? defaultEncoding;
			}
			set
			{
				enc = value;
			}
		}

		public virtual char[] ReadChars(int index, int length)
		{
			char[] result = null;

			try
			{
				HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create(URI);
				proxy_request.Method = "GET";
				proxy_request.ContentType = "application/x-www-form-urlencoded";
				proxy_request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/532.5 (KHTML, like Gecko) Chrome/4.0.249.89 Safari/532.5";
				proxy_request.KeepAlive = true;
				HttpWebResponse resp = proxy_request.GetResponse() as HttpWebResponse;
				if (resp.StatusCode == HttpStatusCode.OK)
				{
					using (StreamReader sr = new StreamReader(resp.GetResponseStream(), PageEncoding))
					{
						char[] buf = new char[length];
						int countRead = sr.ReadBlock(result, index, result.Length);

						if (countRead == length)
						{
							result = buf;
						}
						else
						{
							result = new char[countRead];
							buf.CopyTo(result, 0);
						}
					}
				}
			}
			catch { }

			return result;
		}

		public virtual byte[] ReadBytes(int index, int length)
		{
			byte[] result = null;

			try
			{
				HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create(URI);
				proxy_request.Method = "GET";
				proxy_request.ContentType = "application/x-www-form-urlencoded";
				proxy_request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/532.5 (KHTML, like Gecko) Chrome/4.0.249.89 Safari/532.5";
				proxy_request.KeepAlive = true;
				HttpWebResponse resp = proxy_request.GetResponse() as HttpWebResponse;
				if (resp.StatusCode == HttpStatusCode.OK)
				{
					using (BinaryReader br = new BinaryReader(resp.GetResponseStream()))
					{
						byte[] bytes = br.ReadBytes(length);
						result = bytes;
					}
				}
			}
			catch { }

			return result;
		}

		public static Encoding GetHtmlCharset(byte[] bytes)
		{
			Encoding result = null;

			if (bytes != null)
			{
				char[] chars = new char[bytes.Length];
				Decoder dec = defaultEncoding.GetDecoder();
				int count = dec.GetChars(bytes, 0, bytes.Length, chars, 0);
				string html = new string(chars, 0, count);

				Regex pattern = new Regex("charset=\"(.*?)\"");
				Match match = pattern.Match(html);
				if (match.Success)
				{
					GroupCollection groups = match.Groups;
					string encName = groups[1].Value;
					Encoding enc = Encoding.GetEncoding(encName);
					result = enc;
				}
			}

			return result;
		}

		public static string GetHtmlTitle(string html)
		{
			string result = null;

			Regex pattern = new Regex("<title>(.*?)</title>");
			Match match = pattern.Match(html);
			if (match.Success)
			{
				GroupCollection groups = match.Groups;
				result = groups[1].Value;
			}

			return result;
		}
	}
}
