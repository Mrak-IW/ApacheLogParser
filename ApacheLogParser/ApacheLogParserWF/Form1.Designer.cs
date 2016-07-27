namespace ApacheLogParserWF
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.MNU_MainMenu = new System.Windows.Forms.MenuStrip();
			this.MI_File = new System.Windows.Forms.ToolStripMenuItem();
			this.MI_FileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.MI_CB_SortType = new System.Windows.Forms.ToolStripComboBox();
			this.OFD_OpenLog = new System.Windows.Forms.OpenFileDialog();
			this.SPLIT_MainSplitContatiner = new System.Windows.Forms.SplitContainer();
			this.DGV_DataBase = new System.Windows.Forms.DataGridView();
			this.TB_Log = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.MNU_MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SPLIT_MainSplitContatiner)).BeginInit();
			this.SPLIT_MainSplitContatiner.Panel1.SuspendLayout();
			this.SPLIT_MainSplitContatiner.Panel2.SuspendLayout();
			this.SPLIT_MainSplitContatiner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGV_DataBase)).BeginInit();
			this.SuspendLayout();
			// 
			// MNU_MainMenu
			// 
			this.MNU_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_File,
            this.MI_CB_SortType});
			this.MNU_MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MNU_MainMenu.Name = "MNU_MainMenu";
			this.MNU_MainMenu.Size = new System.Drawing.Size(558, 27);
			this.MNU_MainMenu.TabIndex = 0;
			this.MNU_MainMenu.Text = "Главное меню";
			// 
			// MI_File
			// 
			this.MI_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_FileOpen});
			this.MI_File.Name = "MI_File";
			this.MI_File.Size = new System.Drawing.Size(48, 23);
			this.MI_File.Text = "Файл";
			// 
			// MI_FileOpen
			// 
			this.MI_FileOpen.Name = "MI_FileOpen";
			this.MI_FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.MI_FileOpen.Size = new System.Drawing.Size(229, 22);
			this.MI_FileOpen.Text = "Выбрать лог-файл";
			this.MI_FileOpen.Click += new System.EventHandler(this.MI_FileOpen_Click);
			// 
			// MI_CB_SortType
			// 
			this.MI_CB_SortType.Items.AddRange(new object[] {
            "<По умолчанию>",
            "Тип файла A->B",
            "Тип файла B->A"});
			this.MI_CB_SortType.Name = "MI_CB_SortType";
			this.MI_CB_SortType.Size = new System.Drawing.Size(121, 23);
			this.MI_CB_SortType.Text = "Сортировка";
			this.MI_CB_SortType.SelectedIndexChanged += new System.EventHandler(this.MI_CB_SortType_SelectedIndexChanged);
			// 
			// OFD_OpenLog
			// 
			this.OFD_OpenLog.FileName = "Имя файла";
			// 
			// SPLIT_MainSplitContatiner
			// 
			this.SPLIT_MainSplitContatiner.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SPLIT_MainSplitContatiner.Location = new System.Drawing.Point(0, 27);
			this.SPLIT_MainSplitContatiner.Name = "SPLIT_MainSplitContatiner";
			this.SPLIT_MainSplitContatiner.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// SPLIT_MainSplitContatiner.Panel1
			// 
			this.SPLIT_MainSplitContatiner.Panel1.Controls.Add(this.DGV_DataBase);
			// 
			// SPLIT_MainSplitContatiner.Panel2
			// 
			this.SPLIT_MainSplitContatiner.Panel2.Controls.Add(this.TB_Log);
			this.SPLIT_MainSplitContatiner.Size = new System.Drawing.Size(558, 336);
			this.SPLIT_MainSplitContatiner.SplitterDistance = 186;
			this.SPLIT_MainSplitContatiner.TabIndex = 1;
			// 
			// DGV_DataBase
			// 
			this.DGV_DataBase.AllowUserToAddRows = false;
			this.DGV_DataBase.AllowUserToDeleteRows = false;
			this.DGV_DataBase.AllowUserToOrderColumns = true;
			this.DGV_DataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGV_DataBase.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DGV_DataBase.Location = new System.Drawing.Point(0, 0);
			this.DGV_DataBase.Name = "DGV_DataBase";
			this.DGV_DataBase.ReadOnly = true;
			this.DGV_DataBase.Size = new System.Drawing.Size(558, 186);
			this.DGV_DataBase.TabIndex = 3;
			// 
			// TB_Log
			// 
			this.TB_Log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TB_Log.Location = new System.Drawing.Point(0, 0);
			this.TB_Log.Multiline = true;
			this.TB_Log.Name = "TB_Log";
			this.TB_Log.Size = new System.Drawing.Size(558, 146);
			this.TB_Log.TabIndex = 0;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 363);
			this.Controls.Add(this.SPLIT_MainSplitContatiner);
			this.Controls.Add(this.MNU_MainMenu);
			this.MainMenuStrip = this.MNU_MainMenu;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MNU_MainMenu.ResumeLayout(false);
			this.MNU_MainMenu.PerformLayout();
			this.SPLIT_MainSplitContatiner.Panel1.ResumeLayout(false);
			this.SPLIT_MainSplitContatiner.Panel2.ResumeLayout(false);
			this.SPLIT_MainSplitContatiner.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SPLIT_MainSplitContatiner)).EndInit();
			this.SPLIT_MainSplitContatiner.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DGV_DataBase)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MNU_MainMenu;
		private System.Windows.Forms.ToolStripMenuItem MI_File;
		private System.Windows.Forms.ToolStripMenuItem MI_FileOpen;
		private System.Windows.Forms.OpenFileDialog OFD_OpenLog;
		private System.Windows.Forms.SplitContainer SPLIT_MainSplitContatiner;
		private System.Windows.Forms.DataGridView DGV_DataBase;
		private System.Windows.Forms.ToolStripComboBox MI_CB_SortType;
		private System.Windows.Forms.TextBox TB_Log;
		private System.Windows.Forms.Timer timer1;
	}
}

