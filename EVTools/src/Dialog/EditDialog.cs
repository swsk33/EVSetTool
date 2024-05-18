using System;
using System.Windows.Forms;
using Swsk33.ReadAndWriteSharp.Util;

namespace Swsk33.EVTools.Dialog
{
	public partial class EditDialog : Form
	{
		/// <summary>
		/// 结果值封装属性
		/// </summary>
		public string ResultValue { get; set; }

		/// <summary>
		/// 实例化一个编辑窗口
		/// </summary>
		/// <param name="origin">窗口文本框的初始值</param>
		public EditDialog(string origin)
		{
			InitializeComponent();
			editValue.Text = origin;
		}

		/// <summary>
		/// 取消按钮
		/// </summary>
		private void cancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Dispose();
		}

		/// <summary>
		/// 确认按钮
		/// </summary>
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

		/// <summary>
		/// 输入框键盘事件
		/// </summary>
		private void editValue_KeyDown(object sender, KeyEventArgs e)
		{
			// 按下回车键时，也执行确认操作
			if (e.KeyCode == Keys.Enter)
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
}