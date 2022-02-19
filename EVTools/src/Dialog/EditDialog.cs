using Swsk33.ReadAndWriteSharp.Util;
using System;
using System.Windows.Forms;

namespace Swsk33.EVTools.Dialog
{
	public partial class EditDialog : Form
	{
		private string resultValue = null;

		/// <summary>
		/// 结果值
		/// </summary>
		public string ResultValue { get => resultValue; set => resultValue = value; }

		/// <summary>
		/// 实例化一个编辑窗口
		/// </summary>
		/// <param name="origin">窗口文本框的初始值</param>
		public EditDialog(string origin)
		{
			InitializeComponent();
			editValue.Text = origin;
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void ok_Click(object sender, EventArgs e)
		{
			if (!StringUtils.IsEmpty(editValue.Text))
			{
				ResultValue = editValue.Text;
				DialogResult = DialogResult.OK;
			}
			else
			{
				DialogResult = DialogResult.Cancel;
			}
			Close();
		}
	}
}