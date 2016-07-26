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

namespace ApacheLogParserWF
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			ApacheLogContext ctx = new ApacheLogContext();

			DGV_Log.DataSource = ctx.LogEntries.ToList();
		}

		private void miFileOpen_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Hello World");
		}

		private void miOpenLogBase_Click(object sender, EventArgs e)
		{
			var strings = ConfigurationManager.ConnectionStrings;
			string localDbString = null;
			for (int i = 0; i < strings.Count; i++)
			{
				if (strings[i].Name== "ApacheLogParser_ConnectionString")
				{
					localDbString = strings[i].ConnectionString;
					break;
				}
			}
			
			//IDataAdapter da = new SqlDataAdapter
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}
	}
}
