using ApacheLogParser.Delegates;

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
		public StringInStringOut getPageTitle = null;

		public void Call()
		{
			database.ParseLog(logFileName, skipList, startIndex, count, writeLogCallback, finishAction, getPageTitle);
		}
	}
}
