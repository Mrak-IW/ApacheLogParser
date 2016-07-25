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
		[MaxLength(256)]
		public string PageTitle { get; set; }
		public int Size { get; set; }
		[MaxLength(32)]
		public string FileType { get; set; }

		private static Regex parsePattern;

		public virtual ICollection<ApacheLogEntry> ApacheLogEntries { get; set; }

		static FileData()
		{
			parsePattern = new Regex(String.Concat(
				@"^",
				@"(.*",							//Полное имя файла (1)
				@"(?:\.(\w+))?)",				//Расширение файла (2)
				@"((?:&|\?)(?:[\w\.%]+=+[^\s&?]*|[\w&]+))*",	//GET-параметры запроса (3)
				@"$"
				), RegexOptions.Compiled | RegexOptions.RightToLeft);
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

				if (groups.Count > 2)
				{
					result.FileType = groups[2].Value == "" ? null : groups[2].Value;
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
