using System;
using System.Windows.Forms;

namespace Swsk33.EVTools.Dialog
{
	public partial class ToolboxDialog : Form
	{
		/// <summary>
		/// 唯一单例
		/// </summary>
		private static readonly ToolboxDialog Instance = new ToolboxDialog();

		/// <summary>
		/// 单例模式，私有化构造器
		/// </summary>
		private ToolboxDialog()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 获取唯一单例
		/// </summary>
		/// <returns>ToolboxDialog唯一单例</returns>
		public static ToolboxDialog GetInstance()
		{
			return Instance;
		}

		/// <summary>
		/// Path整理工具
		/// </summary>
		private void cleanToolButton_Click(object sender, EventArgs e)
		{
			PathCleanDialog.GetInstance().ShowDialog();
		}

		/// <summary>
		/// 备份还原工具
		/// </summary>
		private void backupToolButton_Click(object sender, EventArgs e)
		{
			BackupDialog.GetInstance().ShowDialog();
		}
	}
}