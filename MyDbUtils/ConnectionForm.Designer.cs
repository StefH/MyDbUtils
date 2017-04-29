namespace MyDbUtils
{
    partial class ConnectionForm
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
            this.rbConnectionString = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectConfig = new System.Windows.Forms.Button();
            this.rbConfigFile = new System.Windows.Forms.RadioButton();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbConnectionString
            // 
            this.rbConnectionString.AutoSize = true;
            this.rbConnectionString.Checked = true;
            this.rbConnectionString.Location = new System.Drawing.Point(16, 29);
            this.rbConnectionString.Name = "rbConnectionString";
            this.rbConnectionString.Size = new System.Drawing.Size(109, 17);
            this.rbConnectionString.TabIndex = 0;
            this.rbConnectionString.TabStop = true;
            this.rbConnectionString.Text = "Connection String";
            this.rbConnectionString.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectConfig);
            this.groupBox1.Controls.Add(this.rbConfigFile);
            this.groupBox1.Controls.Add(this.txtConnectionString);
            this.groupBox1.Controls.Add(this.rbConnectionString);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 103);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ConnectionString Source";
            // 
            // btnSelectConfig
            // 
            this.btnSelectConfig.Enabled = false;
            this.btnSelectConfig.Location = new System.Drawing.Point(154, 65);
            this.btnSelectConfig.Name = "btnSelectConfig";
            this.btnSelectConfig.Size = new System.Drawing.Size(27, 20);
            this.btnSelectConfig.TabIndex = 3;
            this.btnSelectConfig.Text = "...";
            this.btnSelectConfig.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectConfig.UseVisualStyleBackColor = true;
            this.btnSelectConfig.Click += new System.EventHandler(this.btnSelectConfig_Click);
            // 
            // rbConfigFile
            // 
            this.rbConfigFile.AutoSize = true;
            this.rbConfigFile.Location = new System.Drawing.Point(16, 67);
            this.rbConfigFile.Name = "rbConfigFile";
            this.rbConfigFile.Size = new System.Drawing.Size(132, 17);
            this.rbConfigFile.TabIndex = 2;
            this.rbConfigFile.Text = "From Configuration File";
            this.rbConfigFile.UseVisualStyleBackColor = true;
            this.rbConfigFile.CheckedChanged += new System.EventHandler(this.rbConfigFile_CheckedChanged);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(131, 29);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(531, 20);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.Text = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(512, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(619, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "config";
            this.openFileDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*";
            this.openFileDialog.Title = "Select a app.config or web.config file.";
            // 
            // ConnectionForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(720, 170);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConnectionForm";
            this.Text = "Select Database Connection";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbConnectionString;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectConfig;
        private System.Windows.Forms.RadioButton rbConfigFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}