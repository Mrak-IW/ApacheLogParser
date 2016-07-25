using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApacheLogParser;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestApacheLogParser
{
	struct testDataStruct
	{
		public string queryType;
		public string fileType;
	}

	[TestClass]
	public class UnitTestApacheLogEntry
	{
		[TestMethod]
		public void ApacheLogEntry_TryParse()
		{
			//Список строк из файла, которые необходимо прогнать через парсер
			Dictionary<int, testDataStruct> testData = new Dictionary<int, testDataStruct>();	
			testData.Add(1, new testDataStruct { queryType = "GET", fileType = "html" });		//Просто строка
			testData.Add(2, new testDataStruct { queryType = "GET", fileType = "html" });		//Просто строка
			testData.Add(6, new testDataStruct { queryType = "GET", fileType = null });			//Страница не имеет расширения файла, однако имеет параметры GET
			testData.Add(7, new testDataStruct { queryType = "GET", fileType = null });			//Страница не имеет расширения файла, однако имеет параметры GET
			testData.Add(13, new testDataStruct { queryType = "GET", fileType = null });		//Страница не имеет расширения файла
			testData.Add(63, new testDataStruct { queryType = "GET", fileType = "jpg" });       //Нарушение принципа построеня GET-запроса. Передан параметр без значения.
			testData.Add(271, new testDataStruct { queryType = "GET", fileType = "html" });     //Знаки : и - в GET-параметрах
			testData.Add(608, new testDataStruct { queryType = "GET", fileType = "html" });		//Знак % в GET-параметрах
			testData.Add(959, new testDataStruct { queryType = "GET", fileType = "html" });		//Знаки ? в имени файла
			testData.Add(961, new testDataStruct { queryType = "GET", fileType = "html" });		//Знаки ? в имени файла
			testData.Add(963, new testDataStruct { queryType = "GET", fileType = "html" });     //Знаки ? в имени файла
			testData.Add(1458, new testDataStruct { queryType = "GET", fileType = "php" });     //Знаки / и = в GET-параметрах
			testData.Add(1371, new testDataStruct { queryType = "OPTIONS", fileType = null });  //Знак $ а имени файла
			testData.Add(2400, new testDataStruct { queryType = "GET", fileType = null });		//Нарушение принципа построеня GET-запроса. address/?longurlwascutoff_22&&&&&&&&&&&&& Тип файла определяется верно, но эта вот муть попадает в имя файла.
			testData.Add(2402, new testDataStruct { queryType = "GET", fileType = "html" });    //Последовательность | - "" | вместо | - - |
			testData.Add(3288, new testDataStruct { queryType = "GET", fileType = "php" });		//Символ . в параметрах запроса
			testData.Add(3606, new testDataStruct { queryType = "GET", fileType = "html" });    //Передаётся параметр с пустым значением &Itemid=&view=register
			//testData.Add(6519, new testDataStruct { queryType = "GET", fileType = null });	//Вот эту строку как понимать вообще? Обращение к стороннему серверу

			string path = AppDomain.CurrentDomain.BaseDirectory;
			string filename = "tariscope.com.access.log";
			string fullname = String.Format("{0}/{1}", path, filename);
			Assert.IsTrue(File.Exists(fullname), String.Format("Файл с логом не существует в рабочей папке теста [{0}]", fullname));

			StreamReader logfile = new StreamReader(fullname);
			for (int i = 1; i <= testData.Keys.Max(); i++)
			{
				string str = logfile.ReadLine();
				if (testData.ContainsKey(i))
				{
					ApacheLogEntry le = ApacheLogEntry.TryParse(str);
					Assert.IsNotNull(le, String.Format("Строка {0} : {1}", i, str));
					Assert.AreEqual(testData[i].fileType, le.File.FileType, String.Format("Строка {0} - получен неверный тип файла", i));
					Assert.AreEqual(testData[i].queryType, le.QueryType, String.Format("Строка {0} - получен неверный тип запроса", i));
				}
			}
		}
	}
}
