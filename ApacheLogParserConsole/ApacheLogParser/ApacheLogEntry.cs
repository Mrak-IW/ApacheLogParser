using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheLogParser
{
	public class ApacheLogEntry
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string QueryType { get; set; }
		public byte QueryResult { get; set; }
		public int DataSize { get; set; }

		public int? FileId { get; set; }
		public virtual FileData File { get; set; }

		public int? IpAddressId { get; set; }
		public virtual Ip IpAddress { get; set; }
	}
}
