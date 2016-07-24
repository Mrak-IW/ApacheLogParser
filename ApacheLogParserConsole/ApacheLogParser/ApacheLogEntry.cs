using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApacheLogParser
{
	public class ApacheLogEntry
	{
		static Dictionary<string, int> monthNumber;

		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string QueryType { get; set; }
		public ushort QueryResult { get; set; }

		public int? FileId { get; set; }
		public virtual FileData File { get; set; }

		public int? IpAddressId { get; set; }
		public virtual Ip IpAddress { get; set; }

		private static Regex parsePattern;
		private static Regex transformPattern;

		static ApacheLogEntry()
		{
			CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
			DateTime date = new DateTime(1, 1, 1);
			monthNumber = new Dictionary<string, int>(12);
			for (int i = 0; i < 12; i++)
			{
				monthNumber.Add(date.AddMonths(i).ToString("MMM", culture), i + 1);
			}

			parsePattern = new Regex(String.Concat(
				@"^\s*",                        //Начало строки с возможными пробелами
				@"((?:\d{1,3}\.){3}\d{1,3})",   //IP-адрес (1)
				@"[^\[]+",                      //Разделитель
				@"\[(.*)\]",                    //Всё, что между скобками - дата (2)
				@"\s+",                         //Пробелы
				"\"",                           //Кавычка открыта
				@"([A-Z]+)",                    //Капсом - метод HTTP (3)
				@"\s*",                         //Пробелы
				@"(\S+)",                       //Всё, что не пробелы - адрес файла (4)
				"[^\"]+\"",                     //Чуть-чуть мусора и кавычка закрыта
				@"\s+",                         //Пробелы
				@"(\d+)",                       //Код возврата (5)
				@"\s+",                         //Пробелы
				@"(\d+)",                       //Размер данных (6)
				".*$"                           //Всё оставшееся
				), RegexOptions.Compiled);

			transformPattern = new Regex(String.Concat(
					@"(\d+).",          //Число (1)
					@"([A-Za-z]+).",    //Месяц (2)
					@"(\d{2,}).",       //Год (3)
					@"(\d+).",          //Часы (4)
					@"(\d+).",          //Минуты (5)
					@"(\d+).",          //Секунды (6)
					@"(\S+)"            //Поправка к UTC (7)
				), RegexOptions.Compiled);
		}

		public static ApacheLogEntry TryParse(string text)
		{
			ApacheLogEntry result = null;
			Regex pattern = ApacheLogEntry.parsePattern;
			Match match = pattern.Match(text);
			GroupCollection groups = match.Groups;

			if (match.Success)
			{
				DateTime dt = DateTime.MinValue;
				int dataSize;
				ushort retCode;
				Ip ip = Ip.TryParse(groups[1].Value);
				FileData fd = FileData.TryParse(groups[4].Value);

				bool fl = (ip != null) && (fd != null);

				string date = ApacheLogDateToParsable(groups[2].Value);
				fl &= DateTime.TryParse(date, out dt);
				fl &= ushort.TryParse(groups[5].Value, out retCode);
				fl &= int.TryParse(groups[6].Value, out dataSize);

				if (fl)
				{
					fd.Size = dataSize;
					result = new ApacheLogEntry
					{
						IpAddress = ip,
						Date = dt,
						QueryType = groups[3].Value,
						File = fd,
						QueryResult = retCode,
					};
				}
			}

			return result;
		}
		//178.154.149.1 - - [18/Jul/2016:00:03:20 +0300] "GET /support/189-2012-09-08-15-14-26.html HTTP/1.0" 303 445
		//"-" "Mozilla/5.0 (compatible; YandexBot/3.0; +http://yandex.com/bots)"
		public static ApacheLogEntry[] TryParse(string[] strings)
		{
			ApacheLogEntry[] result = null;

			return result;
		}

		private static string ApacheLogDateToParsable(string dateText)
		{
			string result = null;
			Regex pattern = transformPattern;
			Match match = pattern.Match(dateText);
			GroupCollection groups = match.Groups;
			if (match.Success)
			{
				result = String.Join(
					" ",
					String.Join(".", groups[1].Value, monthNumber[groups[2].Value].ToString("D2"), groups[3].Value),
					String.Join(":", groups[4].Value, groups[5].Value, groups[6].Value),
					groups[7].Value
					);
			}
			return result;
		}
	}
}
