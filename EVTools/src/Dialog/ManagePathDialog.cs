using Swsk33.EVTools.Util;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Swsk33.EVTools.Dialog
{
	public partial class ManagePathDialog : Form
	{
		/// <summary>
		/// 添加路径时，记录上一次指定的目录
		/// </summary>
		private string lastAddPath = "";

		public ManagePathDialog()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 管理Path窗口初始化
		/// </summary>
		private void ManagePathForm_Load(object sender, EventArgs e)
		{
			string[] pathValues = RegUtils.GetPathVariable(false);
			foreach (string value in pathValues)
			{
				pathContentValue.Items.Add(value);
			}
			buttonToolTip.SetToolTip(up, "上移选定元素");
			buttonToolTip.SetToolTip(down, "下移选定元素");
			buttonToolTip.SetToolTip(remove, "移除选定元素");
			buttonToolTip.SetToolTip(add, "在选定元素之后插入路径，若未选择元素则在尾部插入");
			buttonToolTip.SetToolTip(edit, "编辑所选元素，也可以双击相应的元素进行编辑");
		}

		/// <summary>
		/// 取消按钮
		/// </summary>
		private void cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 向上移动按钮
		/// </summary>
		private void up_Click(object sender, EventArgs e)
		{
			int index = pathContentValue.SelectedIndex;
			if (index > 0)
			{
				string currentContent = pathContentValue.SelectedItem.ToString();
				pathContentValue.Items.RemoveAt(index);
				pathContentValue.Items.Insert(index - 1, currentContent);
				pathContentValue.SelectedIndex = index - 1;
			}
		}

		/// <summary>
		/// 向下移动按钮
		/// </summary>
		private void down_Click(object sender, EventArgs e)
		{
			int index = pathContentValue.SelectedIndex;
			if (index >= 0 && index < pathContentValue.Items.Count - 1)
			{
				string currentContent = pathContentValue.SelectedItem.ToString();
				pathContentValue.Items.RemoveAt(index);
				pathContentValue.Items.Insert(index + 1, currentContent);
				pathContentValue.SelectedIndex = index + 1;
			}
		}

		/// <summary>
		/// 移除按钮
		/// </summary>
		private void remove_Click(object sender, EventArgs e)
		{
			if (pathContentValue.SelectedIndex >= 0)
			{
				pathContentValue.Items.RemoveAt(pathContentValue.SelectedIndex);
			}
			else
			{
				MessageBox.Show(@"请选择要删除的值！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 增加按钮
		/// </summary>
		private void add_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择路径";
			if (!StringUtils.IsEmpty(lastAddPath))
			{
				dialog.SelectedPath = lastAddPath;
			}
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				string path = dialog.SelectedPath;
				lastAddPath = path;
				if (pathContentValue.SelectedIndex >= 0)
				{
					pathContentValue.Items.Insert(pathContentValue.SelectedIndex + 1, path);
				}
				else
				{
					pathContentValue.Items.Add(path);
				}
			}
		}

		/// <summary>
		/// 编辑按钮
		/// </summary>
		private void edit_Click(object sender, EventArgs e)
		{
			if (pathContentValue.SelectedIndex >= 0)
			{
				EditDialog dialog = new EditDialog(pathContentValue.SelectedItem.ToString());
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					pathContentValue.Items[pathContentValue.SelectedIndex] = dialog.ResultValue;
				}
			}
			else
			{
				MessageBox.Show(@"请选择要修改的值！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 保存按钮
		/// </summary>
		private void save_Click(object sender, EventArgs e)
		{
			List<string> totalPathValue = new List<string>();
			foreach (string value in pathContentValue.Items)
			{
				totalPathValue.Add(value);
			}
			applyTip.Visible = true;
			save.Enabled = false;
			cancel.Enabled = false;
			new Thread(() =>
			{
				if (VariableUtils.SavePath(totalPathValue.ToArray()))
				{
					MessageBox.Show(@"修改完成！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(@"修改失败！请关闭程序然后右键-以管理员身份运行此程序重试！也可能是Path变量总长度超出限制！", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				Close();
			}).Start();
		}

		/// <summary>
		/// 双击条目
		/// </summary>
		private void pathContentValue_DoubleClick(object sender, EventArgs e)
		{
			if (pathContentValue.SelectedIndex >= 0)
			{
				EditDialog dialog = new EditDialog(pathContentValue.SelectedItem.ToString());
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					pathContentValue.Items[pathContentValue.SelectedIndex] = dialog.ResultValue;
				}
			}
		}
	}
}