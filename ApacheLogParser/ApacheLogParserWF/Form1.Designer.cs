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
			this.MI_SortLabel = new System.Windows.Forms.ToolStripMenuItem();
			this.MI_CB_SortType = new System.Windows.Forms.ToolStripComboBox();
			this.OFD_OpenLog = new System.Windows.Forms.OpenFileDialog();
			this.SPLIT_MainSplitContatiner = new System.Windows.Forms.SplitContainer();
			this.DGV_DataBase = new System.Windows.Forms.DataGridView();
			this.TB_Log = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.NUD_StartIndex = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.NUD_Count = new System.Windows.Forms.NumericUpDown();
			this.TT_Helper = new System.Windows.Forms.ToolTip(this.components);
			this.TB_ServerAddress = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.MNU_MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SPLIT_MainSplitContatiner)).BeginInit();
			this.SPLIT_MainSplitContatiner.Panel1.SuspendLayout();
			this.SPLIT_MainSplitContatiner.Panel2.SuspendLayout();
			this.SPLIT_MainSplitContatiner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGV_DataBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD_StartIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).BeginInit();
			this.SuspendLayout();
			// 
			// MNU_MainMenu
			// 
			this.MNU_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_File,
            this.MI_SortLabel,
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
			this.MI_FileOpen.Size = new System.Drawing.Size(220, 22);
			this.MI_FileOpen.Text = "Выбрать лог-файл";
			this.MI_FileOpen.Click += new System.EventHandler(this.MI_FileOpen_Click);
			// 
			// MI_SortLabel
			// 
			this.MI_SortLabel.Name = "MI_SortLabel";
			this.MI_SortLabel.Size = new System.Drawing.Size(91, 23);
			this.MI_SortLabel.Text = "Сортировка :";
			// 
			// MI_CB_SortType
			// 
			this.MI_CB_SortType.Items.AddRange(new object[] {
            "<По умолчанию>",
            "Тип файла A->B",
            "Тип файла B->A",
            "Путь A->B",
            "Путь B->A",
            "Тип запроса A->B",
            "Код ответа A->B"});
			this.MI_CB_SortType.Name = "MI_CB_SortType";
			this.MI_CB_SortType.Size = new System.Drawing.Size(121, 23);
			this.MI_CB_SortType.Text = "<По умолчанию>";
			this.MI_CB_SortType.SelectedIndexChanged += new System.EventHandler(this.MI_CB_SortType_SelectedIndexChanged);
			// 
			// OFD_OpenLog
			// 
			this.OFD_OpenLog.FileName = "Имя файла";
			// 
			// SPLIT_MainSplitContatiner
			// 
			this.SPLIT_MainSplitContatiner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SPLIT_MainSplitContatiner.Location = new System.Drawing.Point(0, 59);
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
			this.SPLIT_MainSplitContatiner.Size = new System.Drawing.Size(558, 304);
			this.SPLIT_MainSplitContatiner.SplitterDistance = 168;
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
			this.DGV_DataBase.Size = new System.Drawing.Size(558, 168);
			this.DGV_DataBase.TabIndex = 3;
			// 
			// TB_Log
			// 
			this.TB_Log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TB_Log.Location = new System.Drawing.Point(0, 0);
			this.TB_Log.Multiline = true;
			this.TB_Log.Name = "TB_Log";
			this.TB_Log.Size = new System.Drawing.Size(558, 132);
			this.TB_Log.TabIndex = 0;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// NUD_StartIndex
			// 
			this.NUD_StartIndex.Location = new System.Drawing.Point(65, 30);
			this.NUD_StartIndex.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.NUD_StartIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NUD_StartIndex.Name = "NUD_StartIndex";
			this.NUD_StartIndex.Size = new System.Drawing.Size(89, 20);
			this.NUD_StartIndex.TabIndex = 2;
			this.TT_Helper.SetToolTip(this.NUD_StartIndex, "Начать разбор файла с этой строки.");
			this.NUD_StartIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Начало";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(175, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Количество";
			// 
			// NUD_Count
			// 
			this.NUD_Count.Location = new System.Drawing.Point(247, 30);
			this.NUD_Count.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.NUD_Count.Name = "NUD_Count";
			this.NUD_Count.Size = new System.Drawing.Size(89, 20);
			this.NUD_Count.TabIndex = 5;
			this.TT_Helper.SetToolTip(this.NUD_Count, "Количество строк для чтения. 0 - читать всё.");
			// 
			// TB_ServerAddress
			// 
			this.TB_ServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TB_ServerAddress.Location = new System.Drawing.Point(446, 29);
			this.TB_ServerAddress.Name = "TB_ServerAddress";
			this.TB_ServerAddress.Size = new System.Drawing.Size(100, 20);
			this.TB_ServerAddress.TabIndex = 6;
			this.TB_ServerAddress.Text = "http://www.tariscope.com";
			this.TT_Helper.SetToolTip(this.TB_ServerAddress, "Если оставить поле пустым, запросы на заголовки страниц производиться не будут");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(357, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Адрес сервера";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 363);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TB_ServerAddress);
			this.Controls.Add(this.NUD_Count);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.NUD_StartIndex);
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
			((System.ComponentModel.ISupportInitialize)(this.NUD_StartIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).EndInit();
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
		private System.Windows.Forms.NumericUpDown NUD_StartIndex;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown NUD_Count;
		private System.Windows.Forms.ToolTip TT_Helper;
		private System.Windows.Forms.TextBox TB_ServerAddress;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolStripMenuItem MI_SortLabel;
	}
}

