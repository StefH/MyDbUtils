using System;
using System.Windows.Forms;
using MyDbUtils.Business;

namespace MyDbUtils
{
	public partial class ManageConnectionForm : Form
	{
		private string _oldName;

		public ManageConnectionForm()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			_oldName = txtName.Text;
		}

		#region Event Handlers
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			XmlConfig.Instance.RemoveElement("//MyConnectionStrings//add[@key='" + _oldName + "']");
			XmlConfig.Instance.SetValue("//MyConnectionStrings//add[@key='" + txtName.Text + "']", txtConnectionString.Text);
			Close();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			XmlConfig.Instance.RemoveElement("//MyConnectionStrings//add[@key='" + txtName.Text + "']");
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion
	}
}