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
	}
}
