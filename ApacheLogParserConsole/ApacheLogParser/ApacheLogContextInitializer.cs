using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheLogParser
{
	public class ApacheLogContextInitializer : DropCreateDatabaseAlways<ApacheLogContext>
	{
		protected override void Seed(ApacheLogContext context)
		{
			Ip tmpIp = new Ip
			{
				IpAddr = 0xFFFFFFFF,
				OwnerCompany = "Компания",
			};

			FileData tmpFileData = new FileData
			{
				FullName = "/directory/amazingFile.htm",
				PageTitle = "Охренительный файл",
				Size = 100500,
			};

			context.IpAddresses.Add(tmpIp);
			context.Files.Add(tmpFileData);

			ApacheLogEntry tmpEntry = new ApacheLogEntry
			{
				Date = DateTime.Now,
				QueryResult = 200,
				QueryType = "GET",
				File = tmpFileData,
				IpAddress = tmpIp,
			};

			context.LogEntries.Add(tmpEntry);

			context.SaveChanges();
		}
	}
}
