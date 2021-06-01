using System;
using System.Windows.Forms;

namespace EVTools
{
	public partial class EditForm : Form
	{
		private string resultValue = null;

		public EditForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 将指定值传入变量编辑窗口并显示以修改
		/// </summary>
		/// <param name="origin">原值</param>
		/// <returns>点击确定返回修改后的值，点击取消返回null</returns>
		public string SetSpecificValue(string origin)
		{
			editValue.Text = origin;
			ShowDialog();
			return resultValue;
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ok_Click(object sender, EventArgs e)
		{
			resultValue = editValue.Text;
			Close();
		}
	}
}
