namespace MyDbUtils
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rbCreate = new System.Windows.Forms.RadioButton();
            this.rbDeleteAndCreate = new System.Windows.Forms.RadioButton();
            this.gbExport_Create = new System.Windows.Forms.GroupBox();
            this.rbCreateOrAlter = new System.Windows.Forms.RadioButton();
            this.chkIncludeDependencies = new System.Windows.Forms.CheckBox();
            this.chkAddUseDatabase = new System.Windows.Forms.CheckBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.lblInfoSP = new System.Windows.Forms.Label();
            this.lblSelectConnection = new System.Windows.Forms.Label();
            this.lbDatabaseInfo = new System.Windows.Forms.ListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.gbFileSettings = new System.Windows.Forms.GroupBox();
            this.rbCreateMultipleFiles = new System.Windows.Forms.RadioButton();
            this.rbCreateSingleFile = new System.Windows.Forms.RadioButton();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbConnections = new System.Windows.Forms.ListBox();
            this.lblDBInfo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.schemeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkSelectViews = new System.Windows.Forms.CheckBox();
            this.chkSelectFunctions = new System.Windows.Forms.CheckBox();
            this.chkSelectStoredProcedures = new System.Windows.Forms.CheckBox();
            this.mBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.chkSelectTriggers = new System.Windows.Forms.CheckBox();
            this.gbExport_Create.SuspendLayout();
            this.gbFileSettings.SuspendLayout();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rbCreate
            // 
            this.rbCreate.AutoSize = true;
            this.rbCreate.Location = new System.Drawing.Point(19, 50);
            this.rbCreate.Name = "rbCreate";
            this.rbCreate.Size = new System.Drawing.Size(136, 17);
            this.rbCreate.TabIndex = 2;
            this.rbCreate.Tag = "0";
            this.rbCreate.Text = "\'Create\' statements only";
            this.rbCreate.UseVisualStyleBackColor = true;
            // 
            // rbDeleteAndCreate
            // 
            this.rbDeleteAndCreate.AutoSize = true;
            this.rbDeleteAndCreate.Location = new System.Drawing.Point(19, 91);
            this.rbDeleteAndCreate.Name = "rbDeleteAndCreate";
            this.rbDeleteAndCreate.Size = new System.Drawing.Size(173, 17);
            this.rbDeleteAndCreate.TabIndex = 4;
            this.rbDeleteAndCreate.Tag = "2";
            this.rbDeleteAndCreate.Text = "\'Delete\' and \'Create\' statements";
            this.rbDeleteAndCreate.UseVisualStyleBackColor = true;
            // 
            // gbExport_Create
            // 
            this.gbExport_Create.Controls.Add(this.rbCreateOrAlter);
            this.gbExport_Create.Controls.Add(this.chkIncludeDependencies);
            this.gbExport_Create.Controls.Add(this.chkAddUseDatabase);
            this.gbExport_Create.Controls.Add(this.rbCreate);
            this.gbExport_Create.Controls.Add(this.rbDeleteAndCreate);
            this.gbExport_Create.Location = new System.Drawing.Point(430, 13);
            this.gbExport_Create.Name = "gbExport_Create";
            this.gbExport_Create.Size = new System.Drawing.Size(222, 137);
            this.gbExport_Create.TabIndex = 4;
            this.gbExport_Create.TabStop = false;
            this.gbExport_Create.Text = "Export Settings";
            // 
            // rbCreateOrAlter
            // 
            this.rbCreateOrAlter.AutoSize = true;
            this.rbCreateOrAlter.Checked = true;
            this.rbCreateOrAlter.Location = new System.Drawing.Point(19, 71);
            this.rbCreateOrAlter.Name = "rbCreateOrAlter";
            this.rbCreateOrAlter.Size = new System.Drawing.Size(154, 17);
            this.rbCreateOrAlter.TabIndex = 3;
            this.rbCreateOrAlter.TabStop = true;
            this.rbCreateOrAlter.Tag = "1";
            this.rbCreateOrAlter.Text = "\'Create\' or \'Alter\' statements";
            this.rbCreateOrAlter.UseVisualStyleBackColor = true;
            // 
            // chkIncludeDependencies
            // 
            this.chkIncludeDependencies.AutoSize = true;
            this.chkIncludeDependencies.Checked = true;
            this.chkIncludeDependencies.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeDependencies.Location = new System.Drawing.Point(19, 114);
            this.chkIncludeDependencies.Name = "chkIncludeDependencies";
            this.chkIncludeDependencies.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeDependencies.TabIndex = 5;
            this.chkIncludeDependencies.Text = "Include dependencies";
            this.chkIncludeDependencies.UseVisualStyleBackColor = true;
            // 
            // chkAddUseDatabase
            // 
            this.chkAddUseDatabase.AutoSize = true;
            this.chkAddUseDatabase.Checked = true;
            this.chkAddUseDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddUseDatabase.Location = new System.Drawing.Point(19, 19);
            this.chkAddUseDatabase.Name = "chkAddUseDatabase";
            this.chkAddUseDatabase.Size = new System.Drawing.Size(177, 17);
            this.chkAddUseDatabase.TabIndex = 1;
            this.chkAddUseDatabase.Text = "Add USE [DATABASE] at begin";
            this.chkAddUseDatabase.UseVisualStyleBackColor = true;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Enabled = false;
            this.chkSelectAll.Location = new System.Drawing.Point(12, 451);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(37, 17);
            this.chkSelectAll.TabIndex = 6;
            this.chkSelectAll.Text = "All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // lblInfoSP
            // 
            this.lblInfoSP.AutoSize = true;
            this.lblInfoSP.Location = new System.Drawing.Point(9, 234);
            this.lblInfoSP.Name = "lblInfoSP";
            this.lblInfoSP.Size = new System.Drawing.Size(243, 13);
            this.lblInfoSP.TabIndex = 7;
            this.lblInfoSP.Text = "Stored Procedures, Functions, Views and Triggers";
            // 
            // lblSelectConnection
            // 
            this.lblSelectConnection.AutoSize = true;
            this.lblSelectConnection.Location = new System.Drawing.Point(8, 13);
            this.lblSelectConnection.Name = "lblSelectConnection";
            this.lblSelectConnection.Size = new System.Drawing.Size(325, 13);
            this.lblSelectConnection.TabIndex = 8;
            this.lblSelectConnection.Text = "Select the connection (or right-click for add/edit/delete connection)";
            // 
            // lbDatabaseInfo
            // 
            this.lbDatabaseInfo.Enabled = false;
            this.lbDatabaseInfo.FormattingEnabled = true;
            this.lbDatabaseInfo.Location = new System.Drawing.Point(12, 191);
            this.lbDatabaseInfo.Name = "lbDatabaseInfo";
            this.lbDatabaseInfo.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbDatabaseInfo.Size = new System.Drawing.Size(398, 30);
            this.lbDatabaseInfo.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(578, 497);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gbFileSettings
            // 
            this.gbFileSettings.Controls.Add(this.rbCreateMultipleFiles);
            this.gbFileSettings.Controls.Add(this.rbCreateSingleFile);
            this.gbFileSettings.Location = new System.Drawing.Point(430, 171);
            this.gbFileSettings.Name = "gbFileSettings";
            this.gbFileSettings.Size = new System.Drawing.Size(222, 65);
            this.gbFileSettings.TabIndex = 10;
            this.gbFileSettings.TabStop = false;
            this.gbFileSettings.Text = "File Settings";
            // 
            // rbCreateMultipleFiles
            // 
            this.rbCreateMultipleFiles.AutoSize = true;
            this.rbCreateMultipleFiles.Location = new System.Drawing.Point(19, 41);
            this.rbCreateMultipleFiles.Name = "rbCreateMultipleFiles";
            this.rbCreateMultipleFiles.Size = new System.Drawing.Size(140, 17);
            this.rbCreateMultipleFiles.TabIndex = 3;
            this.rbCreateMultipleFiles.Text = "Create Multiple SQL files";
            this.rbCreateMultipleFiles.UseVisualStyleBackColor = true;
            // 
            // rbCreateSingleFile
            // 
            this.rbCreateSingleFile.AutoSize = true;
            this.rbCreateSingleFile.Checked = true;
            this.rbCreateSingleFile.Location = new System.Drawing.Point(19, 19);
            this.rbCreateSingleFile.Name = "rbCreateSingleFile";
            this.rbCreateSingleFile.Size = new System.Drawing.Size(128, 17);
            this.rbCreateSingleFile.TabIndex = 2;
            this.rbCreateSingleFile.TabStop = true;
            this.rbCreateSingleFile.Text = "Create Single SQL file";
            this.rbCreateSingleFile.UseVisualStyleBackColor = true;
            // 
            // progressBarExport
            // 
            this.progressBarExport.Location = new System.Drawing.Point(373, 461);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(280, 23);
            this.progressBarExport.TabIndex = 12;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(469, 381);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(48, 13);
            this.lblProgress.TabIndex = 14;
            this.lblProgress.Text = "Progress";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select a folder to store the generated SQL files.";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "sql";
            this.saveFileDialog.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
            this.saveFileDialog.Title = "Select a SQL destination file.";
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.ShowImageMargin = false;
            this.ctxMenu.Size = new System.Drawing.Size(89, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // lbConnections
            // 
            this.lbConnections.ContextMenuStrip = this.ctxMenu;
            this.lbConnections.FormattingEnabled = true;
            this.lbConnections.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "R",
            "Z",
            "P"});
            this.lbConnections.Location = new System.Drawing.Point(12, 29);
            this.lbConnections.Name = "lbConnections";
            this.lbConnections.ScrollAlwaysVisible = true;
            this.lbConnections.Size = new System.Drawing.Size(398, 121);
            this.lbConnections.TabIndex = 18;
            this.lbConnections.SelectedIndexChanged += new System.EventHandler(this.lbConnections_SelectedIndexChanged);
            // 
            // lblDBInfo
            // 
            this.lblDBInfo.AutoSize = true;
            this.lblDBInfo.Location = new System.Drawing.Point(12, 175);
            this.lblDBInfo.Name = "lblDBInfo";
            this.lblDBInfo.Size = new System.Drawing.Size(73, 13);
            this.lblDBInfo.TabIndex = 19;
            this.lblDBInfo.Text = "Database info";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedDataGridViewCheckBoxColumn,
            this.schemeDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.myInfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(641, 195);
            this.dataGridView1.TabIndex = 20;
            // 
            // checkedDataGridViewCheckBoxColumn
            // 
            this.checkedDataGridViewCheckBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewCheckBoxColumn.Frozen = true;
            this.checkedDataGridViewCheckBoxColumn.HeaderText = "Checked";
            this.checkedDataGridViewCheckBoxColumn.Name = "checkedDataGridViewCheckBoxColumn";
            this.checkedDataGridViewCheckBoxColumn.Width = 40;
            // 
            // schemeDataGridViewTextBoxColumn
            // 
            this.schemeDataGridViewTextBoxColumn.DataPropertyName = "Scheme";
            this.schemeDataGridViewTextBoxColumn.Frozen = true;
            this.schemeDataGridViewTextBoxColumn.HeaderText = "Scheme";
            this.schemeDataGridViewTextBoxColumn.Name = "schemeDataGridViewTextBoxColumn";
            this.schemeDataGridViewTextBoxColumn.ReadOnly = true;
            this.schemeDataGridViewTextBoxColumn.Width = 50;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Width = 40;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // myInfoBindingSource
            // 
            this.myInfoBindingSource.DataSource = typeof(MyDbUtils.Business.MyInfo);
            // 
            // chkSelectViews
            // 
            this.chkSelectViews.AutoSize = true;
            this.chkSelectViews.Enabled = false;
            this.chkSelectViews.Location = new System.Drawing.Point(12, 520);
            this.chkSelectViews.Name = "chkSelectViews";
            this.chkSelectViews.Size = new System.Drawing.Size(54, 17);
            this.chkSelectViews.TabIndex = 21;
            this.chkSelectViews.Text = "Views";
            this.chkSelectViews.UseVisualStyleBackColor = true;
            this.chkSelectViews.CheckedChanged += new System.EventHandler(this.chkSelectViews_CheckedChanged);
            // 
            // chkSelectFunctions
            // 
            this.chkSelectFunctions.AutoSize = true;
            this.chkSelectFunctions.Enabled = false;
            this.chkSelectFunctions.Location = new System.Drawing.Point(12, 497);
            this.chkSelectFunctions.Name = "chkSelectFunctions";
            this.chkSelectFunctions.Size = new System.Drawing.Size(72, 17);
            this.chkSelectFunctions.TabIndex = 22;
            this.chkSelectFunctions.Text = "Functions";
            this.chkSelectFunctions.UseVisualStyleBackColor = true;
            this.chkSelectFunctions.CheckedChanged += new System.EventHandler(this.chkSelectFunctions_CheckedChanged);
            // 
            // chkSelectStoredProcedures
            // 
            this.chkSelectStoredProcedures.AutoSize = true;
            this.chkSelectStoredProcedures.Enabled = false;
            this.chkSelectStoredProcedures.Location = new System.Drawing.Point(12, 474);
            this.chkSelectStoredProcedures.Name = "chkSelectStoredProcedures";
            this.chkSelectStoredProcedures.Size = new System.Drawing.Size(114, 17);
            this.chkSelectStoredProcedures.TabIndex = 23;
            this.chkSelectStoredProcedures.Text = "Stored Procedures";
            this.chkSelectStoredProcedures.UseVisualStyleBackColor = true;
            this.chkSelectStoredProcedures.CheckedChanged += new System.EventHandler(this.chkSelectStoredProcedures_CheckedChanged);
            // 
            // mBackgroundWorker
            // 
            this.mBackgroundWorker.WorkerReportsProgress = true;
            this.mBackgroundWorker.WorkerSupportsCancellation = true;
            this.mBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.mBackgroundWorker_DoWork);
            this.mBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.mBackgroundWorker_ProgressChanged);
            this.mBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.mBackgroundWorker_RunWorkerCompleted);
            // 
            // chkSelectTriggers
            // 
            this.chkSelectTriggers.AutoSize = true;
            this.chkSelectTriggers.Enabled = false;
            this.chkSelectTriggers.Location = new System.Drawing.Point(12, 543);
            this.chkSelectTriggers.Name = "chkSelectTriggers";
            this.chkSelectTriggers.Size = new System.Drawing.Size(64, 17);
            this.chkSelectTriggers.TabIndex = 24;
            this.chkSelectTriggers.Text = "Triggers";
            this.chkSelectTriggers.UseVisualStyleBackColor = true;
            this.chkSelectTriggers.CheckedChanged += new System.EventHandler(this.chkSelectTriggers_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 573);
            this.Controls.Add(this.chkSelectTriggers);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chkSelectStoredProcedures);
            this.Controls.Add(this.chkSelectFunctions);
            this.Controls.Add(this.chkSelectViews);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lbConnections);
            this.Controls.Add(this.lblDBInfo);
            this.Controls.Add(this.lblSelectConnection);
            this.Controls.Add(this.lbDatabaseInfo);
            this.Controls.Add(this.gbExport_Create);
            this.Controls.Add(this.lblInfoSP);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gbFileSettings);
            this.Controls.Add(this.progressBarExport);
            this.Controls.Add(this.chkSelectAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyDbUtils";
            this.gbExport_Create.ResumeLayout(false);
            this.gbExport_Create.PerformLayout();
            this.gbFileSettings.ResumeLayout(false);
            this.gbFileSettings.PerformLayout();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rbCreate;
		private System.Windows.Forms.RadioButton rbDeleteAndCreate;
		private System.Windows.Forms.GroupBox gbExport_Create;
		private System.Windows.Forms.CheckBox chkSelectAll;
		private System.Windows.Forms.Label lblInfoSP;
		private System.Windows.Forms.Label lblSelectConnection;
		private System.Windows.Forms.ListBox lbDatabaseInfo;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.GroupBox gbFileSettings;
		private System.Windows.Forms.RadioButton rbCreateSingleFile;
		private System.Windows.Forms.RadioButton rbCreateMultipleFiles;
		private System.Windows.Forms.ProgressBar progressBarExport;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.CheckBox chkAddUseDatabase;
		private System.Windows.Forms.ContextMenuStrip ctxMenu;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ListBox lbConnections;
		private System.Windows.Forms.Label lblDBInfo;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.CheckBox chkSelectViews;
		private System.Windows.Forms.CheckBox chkSelectFunctions;
		private System.Windows.Forms.CheckBox chkSelectStoredProcedures;
		private System.ComponentModel.BackgroundWorker mBackgroundWorker;
		private System.Windows.Forms.BindingSource myInfoBindingSource;
		private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn schemeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.CheckBox chkSelectTriggers;
		private System.Windows.Forms.CheckBox chkIncludeDependencies;
		private System.Windows.Forms.RadioButton rbCreateOrAlter;
	}
}

