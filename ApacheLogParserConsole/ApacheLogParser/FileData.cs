using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheLogParser
{
	public class FileData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public string PageTitle { get; set; }
		public int Size { get; set; }

		public virtual ICollection<ApacheLogEntry> ApacheLogEntries { get; set; }

		public override string ToString()
		{
			return String.Concat(Path, Name);
		}
	}
}
