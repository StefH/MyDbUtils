using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyDbUtils.Business;

namespace MyDbUtils
{
    public partial class ConnectionForm : Form
    {
        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public ConnectionForm()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void btnSelectConfig_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                var xmlConfig = new XmlConfig
                {
                    ConfigFile = openFileDialog.FileName
                };

                List<string> connections = xmlConfig.GetChildElements("//connectionStrings", "connectionString");

                if (connections.Count > 0)
                {
                    var frm = new SaveConnectionAsForm();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        XmlConfig.Instance.SetValue("//MyConnectionStrings//add[@key='" + frm.ConnectionName + "']", connections[0]);
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                    MessageBox.Show("No connection string found in this configuration file.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbConnectionString.Checked)
                _connectionString = txtConnectionString.Text;

            var frm = new SaveConnectionAsForm();
            if (DialogResult.OK == frm.ShowDialog())
            {
                XmlConfig.Instance.SetValue("//MyConnectionStrings//add[@key='" + frm.ConnectionName + "']", _connectionString);
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void rbConfigFile_CheckedChanged(object sender, EventArgs e)
        {
            btnSelectConfig.Enabled = rbConfigFile.Checked;
        }
        #endregion
    }
}