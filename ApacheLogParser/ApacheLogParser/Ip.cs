using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheLogParser
{
	public class Ip
	{
		public const int addrLength = 4;

		public int Id { get; set; }
		public long IpAddr { get; set; }
		public string OwnerCompany { get; set; }

		public virtual ICollection<ApacheLogEntry> ApacheLogEntries { get; set; }

		public override string ToString()
		{
			long buf = this.IpAddr;
			byte[] bytes = new byte[addrLength];
			for (int i = 0; i < addrLength; i++)
			{
				bytes[i] = (byte)((buf >> (addrLength - 1 - i) * 8) & 0xFF);
			}
			return String.Join(".", bytes);
		}

		public static Ip TryParse(string text)
		{
			Ip result = null;
			bool fl = true;
			string[] parts = text.Split(new char[] { '.' });
			if (parts.Length == addrLength)
			{
				byte[] bytes = new byte[parts.Length];
				for (int i = 0; i < bytes.Length; i++)
				{
					fl &= byte.TryParse(parts[i], out bytes[i]);
				}

				if (fl)
				{
					long ip = 0;
					for (int i = 0; i < bytes.Length; i++)
					{
						ip |= (long)bytes[i] << (bytes.Length - 1 - i) * 8;
					}
					result = new Ip
					{
						IpAddr = ip,
					};
				}
			}

			return result;
		}

		public override bool Equals(object obj)
		{
			Ip ip = obj as Ip;

			if (obj == null ||
				ip == null)
			{
				return false;
			}

			return this.IpAddr == ip.IpAddr;
		}

		public override int GetHashCode()
		{
			return this.IpAddr.GetHashCode();
		}
	}
}
