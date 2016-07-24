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
		public int Id { get; set; }
		[MaxLength(6)]
		public byte[] IpAddr { get; set; }
		public string OwnerCompany { get; set; }

		public virtual ICollection<ApacheLogEntry> ApacheLogEntries { get; set; }

		public override string ToString()
		{
			return String.Join(".", IpAddr);
		}

		public static Ip TryParse(string text)
		{
			Ip result = null;
			bool fl = true;
			string[] bytes = text.Split(new char[] { '.' });
			if (bytes.Length == 4 || bytes.Length == 6)
			{
				byte[] buf = new byte[bytes.Length];
				for (int i = 0; i < buf.Length; i++)
				{
					fl &= byte.TryParse(bytes[i], out buf[i]);
				}

				if (fl)
				{
					result = new Ip
					{
						IpAddr = buf,
					};
				}
			}

			return result;
		}

		public override bool Equals(object obj)
		{
			Ip ip = obj as Ip;

			if (obj == null ||
				ip == null ||
				ip.IpAddr.Length != this.IpAddr.Length)
			{
				return false;
			}

			bool fl = true;

			for (int i = 0; i < ip.IpAddr.Length; i++)
			{
				fl &= this.IpAddr[i] == ip.IpAddr[i];
			}

			return fl;
		}

		public override int GetHashCode()
		{
			ulong sum = 0;
			for (int i = 0; i < this.IpAddr.Length; i++)
			{
				sum |= ((ulong)this.IpAddr[i]) << i * 8;
			}
			return sum.GetHashCode();
		}
	}
}
