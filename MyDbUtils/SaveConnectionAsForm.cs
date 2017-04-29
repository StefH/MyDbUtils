using System;
using System.Windows.Forms;

namespace MyDbUtils
{
	public partial class SaveConnectionAsForm : Form
	{
		private string _name;

		public string ConnectionName
		{
			get { return _name; }
		}

		public SaveConnectionAsForm()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			_name = tbSaveAs.Text;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}