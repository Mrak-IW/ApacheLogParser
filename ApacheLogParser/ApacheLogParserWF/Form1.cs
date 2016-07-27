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
			WriteLog("Необходимо обновить таблицу\n");
		}

		public Form1()
		{
			InitializeComponent();
			AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
			ctx = new ApacheLogContext();
			DGV_DataBase.DataSource = ctx.LogEntries.ToList();
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
				//ctx.ParseLog(logfile, skipList, 1, 200, writeLogCallback: this.WriteLog);
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
					case 0:
						DGV_DataBase.DataSource = ctx.LogEntries.ToList();
						break;
					case 1:
						DGV_DataBase.DataSource = ctx.LogEntries.OrderBy(elem => elem.File.FileType).ToList();
						break;
					case 2:
						DGV_DataBase.DataSource = ctx.LogEntries.OrderByDescending(elem => elem.File.FileType).ToList();
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
