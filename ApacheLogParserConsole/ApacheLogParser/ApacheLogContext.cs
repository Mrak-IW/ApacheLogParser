using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheLogParser
{
	public class ApacheLogContext : DbContext
	{
		static ApacheLogContext()
		{
			Database.SetInitializer<ApacheLogContext>(new ApacheLogContextInitializer());
		}
		public DbSet<ApacheLogEntry> LogEntries { get; set; }
		public DbSet<Ip> IpAddresses { get; set; }
		public DbSet<FileData> Files { get; set; }
	}
}
