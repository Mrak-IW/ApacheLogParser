using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ApacheLogParser;
using ApacheLogParser.Delegates;

namespace ApacheLogParserWF
{
	class StreamParser
	{
		public string logFileName;
		public int startIndex = 1;
		public int count = -1;
		public ApacheLogContext database;
		public string[] skipList = null;

		public SendMessage writeLogCallback = null;
		public SimpleCallback finishAction = null;

		public void Call()
		{
			database.ParseLog(logFileName, skipList, startIndex, count, writeLogCallback, finishAction);
		}
	}
}
