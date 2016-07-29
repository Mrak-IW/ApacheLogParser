using ApacheLogParser.Delegates;
using ApacheLogParser.Interfaces;

namespace ApacheLogParser.UtilityClasses
{
	public class StreamParser
	{
		public string logFileName;
		public int startIndex = 1;
		public int count = -1;
		public ApacheLogContext database;
		public string[] skipList = null;

		public SendMessage writeLogCallback = null;
		public SimpleCallback finishAction = null;

		public IWebPageInfo webPageInfoProvider = null;
		public IWhoIsProvider whoIsProvider = null;

		public void Call()
		{
			database.WebPageInfoProvider = webPageInfoProvider;
			database.WhoIsProvider = whoIsProvider;

			database.ParseLog(logFileName, skipList, startIndex, count, writeLogCallback, finishAction);
		}
	}
}
