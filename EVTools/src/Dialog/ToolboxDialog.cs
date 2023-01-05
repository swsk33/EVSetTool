using System;
using System.Windows.Forms;

namespace Swsk33.EVTools.Dialog
{
	public partial class ToolboxDialog : Form
	{
		public ToolboxDialog()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Path整理工具
		/// </summary>
		private void cleanToolButton_Click(object sender, EventArgs e)
		{
			new PathCleanDialog().ShowDialog();
		}

		/// <summary>
		/// 备份还原工具
		/// </summary>
		private void backupToolButton_Click(object sender, EventArgs e)
		{
			new BackupDialog().ShowDialog();
		}
	}
}