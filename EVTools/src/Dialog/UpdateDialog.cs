using Swsk33.EVTools.Util;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Swsk33.EVTools.Dialog
{
	public partial class UpdateDialog : Form
	{
		public UpdateDialog()
		{
			InitializeComponent();
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ok_Click(object sender, EventArgs e)
		{
			Process.Start(CheckUpdateUtils.DOWNLOAD_URL);
			Application.Exit();
		}
	}
}