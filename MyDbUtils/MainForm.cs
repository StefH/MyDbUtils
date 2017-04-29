using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GregoryAdam.Base.Graph;
using MyDbUtils.Business;

namespace MyDbUtils
{
    public partial class MainForm : Form
    {
        // example: Data Source=localhost\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True
        private string _mConnectionString;
        private MyDatabaseUtil _dbUtil;
        private List<MyInfo> _list;

        public MainForm()
        {
            InitializeComponent();

            Text += " - " + Application.ProductVersion;

            // Init
            XmlConfig.Instance.ConfigFile = Application.StartupPath + "\\MyDbUtils.exe.config";
            RefreshConnectionDropDown();
        }

        private void RefreshConnectionDropDown()
        {
            lbConnections.Items.Clear();

            foreach (string str in XmlConfig.Instance.GetChildElements("//MyConnectionStrings"))
            {
                lbConnections.Items.Add(str);
            }
        }

        private void RefreshList()
        {
            myInfoBindingSource.Clear();
            lbDatabaseInfo.Items.Clear();

            if (!string.IsNullOrEmpty(_mConnectionString))
            {
                _list = _dbUtil.GetInfo(null); // needed for backgroundworker...
                myInfoBindingSource.DataSource = _list;
            }

            if (myInfoBindingSource.Count == 0)
            {
                dataGridView1.Enabled = false;
                myInfoBindingSource.Add(new MyInfo());
                btnExport.Enabled = false;
                lbDatabaseInfo.Enabled = false;
                lbDatabaseInfo.Items.Add("n/a");
                chkSelectAll.Enabled = false;
                chkSelectViews.Enabled = false;
                chkSelectStoredProcedures.Enabled = false;
                chkSelectFunctions.Enabled = false;
                chkSelectTriggers.Enabled = false;
            }
            else
            {
                chkSelectAll.Enabled = true;
                chkSelectViews.Enabled = true;
                chkSelectStoredProcedures.Enabled = true;
                chkSelectFunctions.Enabled = true;
                chkSelectTriggers.Enabled = true;
                dataGridView1.Enabled = true;
                btnExport.Enabled = true;
                lbDatabaseInfo.Enabled = true;
                lbDatabaseInfo.Items.Add("DataSource\t:\t" + _dbUtil.DataSource);
                lbDatabaseInfo.Items.Add("DataBase\t:\t" + _dbUtil.Database);
            }
        }

        #region Event Handlers
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            chkSelectViews.Checked = chkSelectAll.Checked;
            chkSelectStoredProcedures.Checked = chkSelectAll.Checked;
            chkSelectFunctions.Checked = chkSelectAll.Checked;
            chkSelectTriggers.Checked = chkSelectAll.Checked;
        }

        private void chkSelectStoredProcedures_CheckedChanged(object sender, EventArgs e)
        {
            SelectItems("P", chkSelectStoredProcedures.Checked);
        }

        private void chkSelectFunctions_CheckedChanged(object sender, EventArgs e)
        {
            SelectItems("FN", chkSelectFunctions.Checked);
            SelectItems("IF", chkSelectFunctions.Checked);
            SelectItems("TF", chkSelectFunctions.Checked);
            SelectItems("FS", chkSelectFunctions.Checked);
            SelectItems("FT", chkSelectFunctions.Checked);
        }

        private void chkSelectViews_CheckedChanged(object sender, EventArgs e)
        {
            SelectItems("V", chkSelectViews.Checked);
        }

        private void chkSelectTriggers_CheckedChanged(object sender, EventArgs e)
        {
            SelectItems("TR", chkSelectTriggers.Checked);
        }

        private void SelectItems(string type, bool isChecked)
        {
            foreach (var info in myInfoBindingSource.List.Cast<MyInfo>().Where(i => i.Type == type))
            {
                info.Checked = isChecked;
            }

            dataGridView1.Refresh();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var checkedList = myInfoBindingSource.List.Cast<MyInfo>().Where(i => i.Checked).ToList();

            if (checkedList.Count > 0)
            {
                if (mBackgroundWorker.IsBusy)
                {
                    mBackgroundWorker.CancelAsync();
                }
                else
                {
                    var checkedButton = gbExport_Create.Controls.OfType<RadioButton>().First(r => r.Checked);
                    var mode = (GenerateMode) Convert.ToInt32(checkedButton.Tag);

                    var myParams = new MyThreadParams
                    {
                        Mode = mode,
                        AddUseStatement = chkAddUseDatabase.Checked,
                        DatabaseName = _dbUtil.Database,
                        IncludeDependencies = chkIncludeDependencies.Checked,
                        MultipleFiles = rbCreateMultipleFiles.Checked
                    };

                    DialogResult result;
                    if (myParams.MultipleFiles)
                    {
                        result = folderBrowserDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            myParams.PathOrFilename = folderBrowserDialog.SelectedPath;
                        }
                    }
                    else
                    {
                        result = saveFileDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            myParams.PathOrFilename = saveFileDialog.FileName;
                        }
                    }

                    if (result == DialogResult.OK)
                    {
                        myParams.SelectedItems = _dbUtil.GetInfo(checkedList.Select(i => i.Name)).Clone(); // refresh objects
                        mBackgroundWorker.RunWorkerAsync(myParams);

                        btnExport.Text = result == DialogResult.OK ? "Cancel" : "Export";
                    }
                }
            }
            else
            {
                MessageBox.Show("No StoredProcedure(s)/Function(s)/View(s)/Trigger(s) selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lbConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbConnections.SelectedItem != null)
            {
                var currentCursor = Cursor.Current;

                Cursor.Current = Cursors.WaitCursor;
                _mConnectionString = XmlConfig.Instance.GetValue("//MyConnectionStrings//add[@key='" + lbConnections.SelectedItem + "']");
                _dbUtil = new MyDatabaseUtil(_mConnectionString);
                RefreshList();
                Cursor.Current = currentCursor;
                chkSelectAll.Checked = false;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ConnectionForm();
            if (DialogResult.OK == form.ShowDialog())
            {
                RefreshConnectionDropDown();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbConnections.SelectedItem != null)
            {
                var frm = new ManageConnectionForm
                {
                    txtName = { Text = lbConnections.SelectedItem.ToString() },
                    txtConnectionString = { Text = _mConnectionString }
                };

                switch (frm.ShowDialog())
                {
                    case DialogResult.OK: // update
                        _dbUtil = new MyDatabaseUtil(frm.txtConnectionString.Text);
                        RefreshConnectionDropDown();
                        RefreshList();
                        break;

                    case DialogResult.Abort: // delete
                        _mConnectionString = string.Empty;
                        RefreshConnectionDropDown();
                        RefreshList();
                        break;
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlConfig.Instance.RemoveElement("//MyConnectionStrings//add[@key='" + lbConnections.SelectedItem + "']");
            RefreshConnectionDropDown();
            RefreshList();
        }
        #endregion

        #region BackgroundWorker
        private void mBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 0;
            var param = (MyThreadParams)e.Argument;

            if (param.MultipleFiles)
            {
                foreach (var info in param.SelectedItems)
                {
                    if (mBackgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    var fi = new FileInfo(param.PathOrFilename + "\\" + info.Scheme + "." + info.Name + ".sql");

                    using (var textWriter = fi.CreateText())
                    {
                        textWriter.WriteLine(SqlStatementHelper.Copyright());

                        if (param.AddUseStatement)
                        {
                            textWriter.WriteLine(SqlStatementHelper.UseDatabaseStatement(param.DatabaseName));
                        }

                        textWriter.WriteLine(SqlStatementHelper.Statement(info.Type, info.Name, info.Scheme, info.Text.Trim(), param.Mode));
                    }
                    x++;
                    mBackgroundWorker.ReportProgress((100 * x) / param.SelectedItems.Count);
                }
            }
            else // Single file
            {
                var fileInfo = new FileInfo(param.PathOrFilename);
                using (var textWriter = fileInfo.CreateText())
                {
                    textWriter.WriteLine(SqlStatementHelper.Copyright());

                    if (param.AddUseStatement)
                    {
                        textWriter.WriteLine(SqlStatementHelper.UseDatabaseStatement(param.DatabaseName));
                    }

                    IEnumerable<MyInfo> finalList;
                    if (param.IncludeDependencies)
                    {
                        // Try to resolve the dependencies
                        foreach (var info in param.SelectedItems.Where(i => i.Checked))
                        {
                            SelectDependencies(info);
                        }

                        finalList = PerformTopoSort(param.SelectedItems);
                    }
                    else
                    {
                        // Just export only what has been selected
                        finalList = param.SelectedItems;
                    }

                    foreach (var info in finalList.Where(i => i.Checked))
                    {
                        if (mBackgroundWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        textWriter.WriteLine(SqlStatementHelper.Statement(info.Type, info.Name, info.Scheme, info.Text.Trim(), param.Mode));

                        x++;
                        mBackgroundWorker.ReportProgress((100 * x) / finalList.Count());
                    }
                }
            }

            e.Result = 1;
        }

        private void mBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = "Progress : " + e.ProgressPercentage + "%";
            progressBarExport.Value = e.ProgressPercentage;
        }

        private void mBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                progressBarExport.Value = 0;
                lblProgress.Text = "Progress : 0%";
            }
            else
            {
                progressBarExport.Value = 100;
                lblProgress.Text = "Progress : 100%";
            }

            btnExport.Text = "Export";
        }
        #endregion

        public static Queue<MyInfo> PerformTopoSort(List<MyInfo> nodes)
        {
            var sorter = new TopologicalSort<MyInfo>();

            Queue<MyInfo> outQueue;
            foreach (var myInfo in nodes.Where(n => n.Checked))
            {
                if (myInfo.Dependencies.Any())
                {
                    foreach (var dependency in myInfo.Dependencies)
                    {
                        if (myInfo.Equals(dependency))
                        {
                            throw new Exception("Cyclic Dependency detected from '" + dependency + "' to '" + myInfo + "'");
                        }

                        sorter.Edge(myInfo, dependency);
                    }
                }
                else
                {
                    sorter.Edge(myInfo);
                }
            }

            sorter.Sort(out outQueue);

            return outQueue;
        }

        private void SelectDependencies(MyInfo info)
        {
            foreach (var parent in info.Dependencies.Where(p => !p.Checked))
            {
                parent.Checked = true;

                SelectDependencies(parent);
            }
        }
    }
}