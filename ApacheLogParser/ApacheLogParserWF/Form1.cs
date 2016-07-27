using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApacheLogParser;
using System.IO;
using System.Threading;

namespace ApacheLogParserWF
{
	public partial class Form1 : Form
	{
		//В строку соединения добавлено: MultipleActiveResultSets=true
		//Без этого вылетало с ошибкой "Существует назначенный этой команде Command открытый DataReader, который требуется предварительно закрыть."
		//в случаях, когда БД была уже создана до запуска программы.
		bool timeToRefresh = false;
		ApacheLogContext ctx;

		public void WriteLog(string line)
		{
			TB_Log.Text = string.Join("\r\n", TB_Log.Text, line);
		}

		public void RefreshDbView()
		{
			timeToRefresh = true;
			WriteLog("Разбор файла завершён\r\n");
		}

		public object GetSortedData(
			SortType date = SortType.NONE,
			SortType ip = SortType.NONE,
			SortType queryType = SortType.NONE,
			SortType responseCode = SortType.NONE,
			SortType fileType = SortType.NONE,
			SortType fileName = SortType.NONE,
			SortType fileSize = SortType.NONE
			)
		{
			var query = from str in ctx.LogEntries
						select new
						{
							Date = str.Date,
							Ip = str.IpAddress,
							Query = str.QueryType,
							Response = str.QueryResult,
							FileType = str.File.FileType,
							File = str.File.FullName,
							Size = str.DataSize,
						};
			switch (date)
			{
				case SortType.Ascending:
					query = query.OrderBy(e => e.Date);
					break;
				case SortType.Descending:
					query = query.OrderByDescending(e => e.Date);
					break;
			}
			switch (ip)
			{
				case SortType.Ascending:
					query = query.OrderBy(e => e.Ip);
					break;
				case SortType.Descending:
					query = query.OrderByDescending(e => e.Ip);
					break;
			}
			switch (queryType)
			{
				case SortType.Ascending:
					query = query.OrderBy(e => e.Query);
					break;
				case SortType.Descending:
					query = query.OrderByDescending(e => e.Query);
					break;
			}
			switch (fileType)
			{
				case SortType.Ascending:
					query = query.OrderBy(e => e.FileType);
					break;
				case SortType.Descending:
					query = query.OrderByDescending(e => e.FileType);
					break;
			}
			switch (fileName)
			{
				case SortType.Ascending:
					query = query.OrderBy(e => e.File);
					break;
				case SortType.Descending:
					query = query.OrderByDescending(e => e.File);
					break;
			}
			switch (fileSize)
			{
				case SortType.Ascending:
					query = query.OrderBy(e => e.Size);
					break;
				case SortType.Descending:
					query = query.OrderByDescending(e => e.Size);
					break;
			}
			switch (responseCode)
			{
				case SortType.Ascending:
					query = query.OrderBy(e => e.Response);
					break;
				case SortType.Descending:
					query = query.OrderByDescending(e => e.Response);
					break;
			}
			return query.ToList();
		}

		public Form1()
		{
			InitializeComponent();
			AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
			ctx = new ApacheLogContext();
			DGV_DataBase.DataSource = GetSortedData();
		}

		private void MI_FileOpen_Click(object sender, EventArgs e)
		{
			string[] skipList = new string[] {
				"jpg",
				"jpeg",
				"png",
				"bmp",
				"gif",
				"js",
				"css",
			};

			DialogResult ofd = OFD_OpenLog.ShowDialog();

			if (ofd == DialogResult.OK || ofd == DialogResult.Yes)
			{
				StreamParser parser = new StreamParser
				{
					logFileName = OFD_OpenLog.FileName,
					database = ctx,
					skipList = skipList,
					startIndex = 1,
					count = 200,
					writeLogCallback = this.WriteLog,
					finishAction = this.RefreshDbView,
				};
				Thread parseThread = new Thread(parser.Call);
				parseThread.Start();
				DGV_DataBase.DataSource = ctx.LogEntries.ToList();
			}
		}

		private void miOpenLogBase_Click(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void MI_CB_SortType_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (sender is ToolStripComboBox)
			{
				switch ((sender as ToolStripComboBox).SelectedIndex)
				{
					//< По умолчанию >
					//Тип файла A->B
					//Тип файла B->A
					//Путь A->B
					//Путь B->A
					//Тип запроса A->B
					//Код ответа A->B
					case 0:
						DGV_DataBase.DataSource = GetSortedData();
						break;
					case 1:
						DGV_DataBase.DataSource = GetSortedData(fileType: SortType.Ascending);
						break;
					case 2:
						DGV_DataBase.DataSource = GetSortedData(fileType: SortType.Descending);
						break;
					case 3:
						DGV_DataBase.DataSource = GetSortedData(fileName: SortType.Ascending);
						break;
					case 4:
						DGV_DataBase.DataSource = GetSortedData(fileName: SortType.Descending);
						break;
					case 5:
						DGV_DataBase.DataSource = GetSortedData(queryType: SortType.Ascending);
						break;
					case 6:
						DGV_DataBase.DataSource = GetSortedData(responseCode: SortType.Ascending);
						break;
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (timeToRefresh)
			{
				DGV_DataBase.DataSource = ctx.LogEntries.ToList();
				timeToRefresh = false;
			}
		}
	}
}
