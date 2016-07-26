using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheLogParser
{
	//If you delete the DB file, it still stays registered with SqlLocalDB. Sometimes it fixes it to delete the DB. You can do this from the command line.
	//Open the "Developer Command Propmpt for VisualStudio" under your start/programs menu.
	//Run the following commands:

	//sqllocaldb.exe stop v11.0
	//sqllocaldb.exe delete v11.0

	//Лично у меня сработало вот так, без версии:
	//sqllocaldb.exe stop
	//sqllocaldb.exe delete

	public class ApacheLogContextInitializer : CreateDatabaseIfNotExists<ApacheLogContext>
	{
		protected override void Seed(ApacheLogContext context)
		{
			Console.WriteLine("Инициализируется БД");
			//Ip tmpIp = new Ip
			//{
			//	IpAddr = 0xFFFFFFFF,
			//	OwnerCompany = "Компания",
			//};

			//FileData tmpFileData = new FileData
			//{
			//	FullName = "/directory/amazingFile.htm",
			//	PageTitle = "Охренительный файл",
			//	Size = 100500,
			//};

			//context.IpAddresses.Add(tmpIp);
			//context.Files.Add(tmpFileData);

			//ApacheLogEntry tmpEntry = new ApacheLogEntry
			//{
			//	Date = DateTime.Now,
			//	QueryResult = 200,
			//	QueryType = "GET",
			//	File = tmpFileData,
			//	IpAddress = tmpIp,
			//};

			//context.LogEntries.Add(tmpEntry);

			context.SaveChanges();
		}
	}
}
