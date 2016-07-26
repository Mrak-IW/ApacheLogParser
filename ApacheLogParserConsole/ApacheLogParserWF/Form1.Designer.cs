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
			this.menuMainMenu = new System.Windows.Forms.MenuStrip();
			this.miFile = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.miOpenLogBase = new System.Windows.Forms.ToolStripMenuItem();
			this.OFD_OpenLog = new System.Windows.Forms.OpenFileDialog();
			this.DGV_Log = new System.Windows.Forms.DataGridView();
			this.menuMainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGV_Log)).BeginInit();
			this.SuspendLayout();
			// 
			// menuMainMenu
			// 
			this.menuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile});
			this.menuMainMenu.Location = new System.Drawing.Point(0, 0);
			this.menuMainMenu.Name = "menuMainMenu";
			this.menuMainMenu.Size = new System.Drawing.Size(558, 24);
			this.menuMainMenu.TabIndex = 0;
			this.menuMainMenu.Text = "Главное меню";
			// 
			// miFile
			// 
			this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileOpen,
            this.miOpenLogBase});
			this.miFile.Name = "miFile";
			this.miFile.Size = new System.Drawing.Size(48, 20);
			this.miFile.Text = "Файл";
			// 
			// miFileOpen
			// 
			this.miFileOpen.Name = "miFileOpen";
			this.miFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.miFileOpen.Size = new System.Drawing.Size(229, 22);
			this.miFileOpen.Text = "Выбрать лог-файл";
			this.miFileOpen.Click += new System.EventHandler(this.miFileOpen_Click);
			// 
			// miOpenLogBase
			// 
			this.miOpenLogBase.Name = "miOpenLogBase";
			this.miOpenLogBase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.miOpenLogBase.Size = new System.Drawing.Size(229, 22);
			this.miOpenLogBase.Text = "Открыть лог из базы";
			this.miOpenLogBase.Click += new System.EventHandler(this.miOpenLogBase_Click);
			// 
			// OFD_OpenLog
			// 
			this.OFD_OpenLog.FileName = "Имя файла";
			// 
			// DGV_Log
			// 
			this.DGV_Log.AllowUserToAddRows = false;
			this.DGV_Log.AllowUserToDeleteRows = false;
			this.DGV_Log.AllowUserToOrderColumns = true;
			this.DGV_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DGV_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGV_Log.Location = new System.Drawing.Point(12, 28);
			this.DGV_Log.Name = "DGV_Log";
			this.DGV_Log.ReadOnly = true;
			this.DGV_Log.Size = new System.Drawing.Size(533, 323);
			this.DGV_Log.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 363);
			this.Controls.Add(this.DGV_Log);
			this.Controls.Add(this.menuMainMenu);
			this.MainMenuStrip = this.menuMainMenu;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuMainMenu.ResumeLayout(false);
			this.menuMainMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGV_Log)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuMainMenu;
		private System.Windows.Forms.ToolStripMenuItem miFile;
		private System.Windows.Forms.ToolStripMenuItem miFileOpen;
		private System.Windows.Forms.OpenFileDialog OFD_OpenLog;
		private System.Windows.Forms.ToolStripMenuItem miOpenLogBase;
		private System.Windows.Forms.DataGridView DGV_Log;
	}
}

