using Microsoft.Win32;
using Swsk33.EVTools.Util;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Swsk33.EVTools.Dialog
{
	public partial class ManagePathDialog : Form
	{
		public ManagePathDialog()
		{
			InitializeComponent();
		}

		private void ManagePathForm_Load(object sender, EventArgs e)
		{
			string pathValue = Utils.GetVariableValue("Path");
			if (pathValue.EndsWith(";"))
			{
				pathValue = pathValue.Substring(0, pathValue.LastIndexOf(";"));
			}
			string[] pathValues = pathValue.Split(';');
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

		private void cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

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

		private void remove_Click(object sender, EventArgs e)
		{
			if (pathContentValue.SelectedIndex >= 0)
			{
				pathContentValue.Items.RemoveAt(pathContentValue.SelectedIndex);
			}
			else
			{
				MessageBox.Show("请选择要删除的值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void add_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择路径";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				string path = dialog.SelectedPath;
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

		private void edit_Click(object sender, EventArgs e)
		{
			if (pathContentValue.SelectedIndex >= 0)
			{
				string value = new EditDialog().SetSpecificValue(pathContentValue.SelectedItem.ToString());
				if (value != null)
				{
					pathContentValue.Items[pathContentValue.SelectedIndex] = value;
				}
			}
			else
			{
				MessageBox.Show("请选择要修改的值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void save_Click(object sender, EventArgs e)
		{
			string totalPathValue = "";
			foreach (string value in pathContentValue.Items)
			{
				totalPathValue = totalPathValue + value + ";";
			}
			applyTip.Visible = true;
			save.Enabled = false;
			cancel.Enabled = false;
			new Thread(() =>
			{
				Utils.RunSetx("Path", totalPathValue, true);
				Close();
				RegistryKey EVKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment");
				string getPathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
				EVKey.Close();
				if (getPathValue.Equals(totalPathValue))
				{
					MessageBox.Show("修改完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("修改失败！请关闭程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}).Start();
		}

		private void pathContentValue_DoubleClick(object sender, EventArgs e)
		{
			if (pathContentValue.SelectedIndex >= 0)
			{
				string value = new EditDialog().SetSpecificValue(pathContentValue.SelectedItem.ToString());
				if (value != null)
				{
					pathContentValue.Items[pathContentValue.SelectedIndex] = value;
				}
			}
		}
	}
}