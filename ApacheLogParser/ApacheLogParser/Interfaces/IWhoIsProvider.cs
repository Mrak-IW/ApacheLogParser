using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheLogParser.Interfaces
{
	public interface IWhoIsProvider
	{
		string WhoIs(string address);
	}
}
