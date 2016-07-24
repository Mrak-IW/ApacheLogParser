using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApacheLogParser
{
	public class FileData
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string PageTitle { get; set; }
		public int Size { get; set; }
		public string FileType { get; set; }

		private static Regex parsePattern;

		public virtual ICollection<ApacheLogEntry> ApacheLogEntries { get; set; }

		static FileData()
		{
			parsePattern = new Regex(String.Concat(
				"^",
				"(",
				@"/(?:\S+/)*",                      //Путь к файлу (1)
				"([^\\s:\")(]+\\.([a-z]+))?",    //Имя файла (2) и его расширение (3)
				")",
				@"(\?.*)?",                         //GET-параметры запроса
				"$"
				), RegexOptions.Compiled);
		}

		public override string ToString()
		{
			return FullName;
		}

		public static FileData TryParse(string text)
		{
			FileData result = null;

			Regex pattern = parsePattern;
			Match match = pattern.Match(text);
			GroupCollection groups = match.Groups;

			if (match.Success)
			{
				result = new FileData
				{
					FullName = groups[1].Value,
				};

				if (groups.Count > 3)
				{
					result.FileType = groups[3].Value;
				}
			}

			return result;
		}

		public override bool Equals(object obj)
		{
			FileData file = obj as FileData;

			if (obj == null ||
				file == null)
			{
				return false;
			}

			return this.FullName == file.FullName;
		}

		public override int GetHashCode()
		{
			return this.FullName.GetHashCode();
		}
	}
}
