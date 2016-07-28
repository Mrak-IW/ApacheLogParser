using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApacheLogParser;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestApacheLogParser
{
	[TestClass]
	public class UnitTestApacheLogEntry
	{
		[TestMethod]
		public void ApacheLogEntry_TryParse()
		{
			//Список строк из файла, которые необходимо прогнать через парсер
			Dictionary<int, ApacheLogEntry> sample = new Dictionary<int, ApacheLogEntry>();
			sample.Add(1, new ApacheLogEntry
			{   //Просто строка
				QueryType = "GET",
				QueryResult = 500,
				DataSize = 426,
				File = new FileData
				{
					FileType = "html",
					FullName = "/ru/forum/4-Tariscope-3x/256-Re-%D0%9D%D0%B5%D1%82-%D0%BE%D1%82%D0%BE%D0%B1%D1%80%D0%B0%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D0%B8%D0%BD%D0%B8%D1%86%D0%B8%D0%B0%D1%82%D0%BE%D1%80%D0%B0-%D0%B7%D0%B2%D0%BE%D0%BD%D0%BA%D0%B0/post.html",
				}
			});
			sample.Add(2, new ApacheLogEntry
			{   //Просто строка
				QueryType = "GET",
				QueryResult = 303,
				DataSize = 445,
				File = new FileData
				{
					FileType = "html",
					FullName = "/support/189-2012-09-08-15-14-26.html",
				}
			});
			sample.Add(6, new ApacheLogEntry
			{   //Страница не имеет расширения файла, однако имеет параметры GET
				QueryType = "GET",
				QueryResult = 200,
				DataSize = 5498,
				File = new FileData
				{
					FileType = null,
					FullName = "/ru/component/search/",
				}
			});
			sample.Add(7, new ApacheLogEntry
			{   //Страница не имеет расширения файла, однако имеет параметры GET
				QueryType = "GET",
				QueryResult = 200,
				DataSize = 1368,
				File = new FileData
				{
					FileType = null,
					FullName = "/en/",
				}
			});
			sample.Add(13, new ApacheLogEntry
			{   //Страница не имеет расширения файла
				QueryType = "GET",
				QueryResult = 200,
				DataSize = 9409,
				File = new FileData
				{
					FileType = null,
					FullName = "/en/",
				}
			});
			sample.Add(63, new ApacheLogEntry
			{   //Нарушение принципа построеня GET-запроса. Передан параметр без значения.
				QueryType = "GET",
				QueryResult = 200,
				DataSize = 30938,
				File = new FileData
				{
					FileType = "jpg",
					FullName = "/images/banners/bridges/h_bay_bridge.jpg",
				}
			});
			sample.Add(271, new ApacheLogEntry
			{   //Знаки : и - в GET-параметрах
				QueryType = "GET",
				QueryResult = 303,
				DataSize = 480,
				File = new FileData
				{
					FileType = "html",
					FullName = "/en/download/download-tariscope.html",
				}
			});
			sample.Add(608, new ApacheLogEntry
			{   //Знак % в GET-параметрах
				QueryType = "GET",
				QueryResult = 500,
				DataSize = 426,
				File = new FileData
				{
					FileType = "html",
					FullName = "/ru/component/user/login.html",
				}
			});
			sample.Add(959, new ApacheLogEntry
			{   //Знаки ? в имени файла
				QueryType = "GET",
				QueryResult = 500,
				DataSize = 426,
				File = new FileData
				{
					FileType = "html",
					FullName = "/en/forum/1-?????????????-????????????.html",
				}
			});
			sample.Add(961, new ApacheLogEntry
			{   //Знаки ? в имени файла
				QueryType = "GET",
				QueryResult = 500,
				DataSize = 426,
				File = new FileData
				{
					FileType = "html",
					FullName = "/en/forum/1-?????????????-????????????/credits.html",
				}
			});
			sample.Add(963, new ApacheLogEntry
			{   //Знаки ? в имени файла
				QueryType = "GET",
				QueryResult = 500,
				DataSize = 426,
				File = new FileData
				{
					FileType = "html",
					FullName = "/en/forum/3-Common-questions-(Russian)/2-???-?????????????????????-????????????????????.html",
				}
			});
			sample.Add(1371, new ApacheLogEntry
			{   //Знак $ а имени файла
				QueryType = "OPTIONS",
				QueryResult = 303,
				DataSize = 365,
				File = new FileData
				{
					FileType = null,
					FullName = "/ipc$",
				}
			});
			sample.Add(1458, new ApacheLogEntry
			{   //Знаки / и = в GET-параметрах
				QueryType = "GET",
				QueryResult = 303,
				DataSize = 529,
				File = new FileData
				{
					FileType = "php",
					FullName = "/index.php",
				}
			});
			sample.Add(2400, new ApacheLogEntry
			{   //Нарушение принципа построеня GET-запроса. address/?longurlwascutoff_22&&&&&&&&&&&&& Тип файла определяется верно, но эта вот муть попадает в имя файла.
				QueryType = "GET",
				QueryResult = 303,
				DataSize = 397,
				File = new FileData
				{
					FileType = null,
					FullName = "/",
				}
			});
			sample.Add(2402, new ApacheLogEntry
			{   //Последовательность | - "" | вместо | - - |
				QueryType = "GET",
				QueryResult = 301,
				DataSize = 520,
				File = new FileData
				{
					FileType = "html",
					FullName = "/en/forum/4-Tariscope-Enterprise--Provider.html",
				}
			});
			sample.Add(3288, new ApacheLogEntry
			{   //Символ . в параметрах запроса
				QueryType = "GET",
				QueryResult = 303,
				DataSize = 364,
				File = new FileData
				{
					FileType = "php",
					FullName = "/administrator/index.php",
				}
			});
			sample.Add(3606, new ApacheLogEntry
			{   //Передаётся параметр с пустым значением &Itemid=&view=register
				QueryType = "GET",
				QueryResult = 500,
				DataSize = 426,
				File = new FileData
				{
					FileType = "html",
					FullName = "/component/user/register.html",
				}
			});
			sample.Add(6519, new ApacheLogEntry
			{   //Вот эту строку как понимать вообще? Обращение к стороннему серверу
				QueryType = "GET",
				QueryResult = 303,
				DataSize = 404,
				File = new FileData
				{
					FileType = null,
					FullName = "https://www.baidu.com/",
				}
			});

			string path = AppDomain.CurrentDomain.BaseDirectory;
			string filename = "tariscope.com.access.log";
			string fullname = String.Format("{0}/{1}", path, filename);
			Assert.IsTrue(File.Exists(fullname), String.Format("Файл с логом не существует в рабочей папке теста [{0}]", fullname));

			StreamReader logfile = new StreamReader(fullname);
			StreamWriter tested = new StreamWriter(path + "/testedLines.log");
			for (int i = 1; i <= sample.Keys.Max(); i++)
			{
				string str = logfile.ReadLine();

				if (sample.ContainsKey(i))
				{
					tested.WriteLine(String.Format("Строка {0} :\n{1}", i, str));
					tested.Flush();
					ApacheLogEntry parsed = ApacheLogEntry.TryParse(str);
					Assert.IsNotNull(parsed, String.Format("Строка {0} : {1}", i, str));
					Assert.AreEqual(sample[i].File.FileType, parsed.File.FileType, String.Format("Строка {0} - получен неверный тип файла", i));
					Assert.AreEqual(sample[i].File.FullName, parsed.File.FullName, String.Format("Строка {0} - получен неверный путь к файлу", i));
					Assert.AreEqual(sample[i].QueryType, parsed.QueryType, String.Format("Строка {0} - получен неверный тип запроса", i));
					Assert.AreEqual(sample[i].QueryResult, parsed.QueryResult, String.Format("Строка {0} - получен неверный результат запроса", i));
					Assert.AreEqual(sample[i].DataSize, parsed.DataSize, String.Format("Строка {0} - получен неверный размер данных", i));
				}
			}
		}
	}

}
