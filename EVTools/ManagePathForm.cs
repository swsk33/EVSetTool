﻿using Microsoft.Win32;
using System.Windows.Forms;

namespace EVTools
{
	public partial class ManagePathForm : Form
	{
		public ManagePathForm()
		{
			InitializeComponent();
		}

		private void ManagePathForm_Load(object sender, System.EventArgs e)
		{
			RegistryKey EVKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment");
			string pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
			EVKey.Close();
			if (pathValue.EndsWith(";"))
			{
				pathValue = pathValue.Substring(0, pathValue.Length - 1);
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
			buttonToolTip.SetToolTip(edit, "编辑所选元素");
		}

		private void cancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void up_Click(object sender, System.EventArgs e)
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

		private void down_Click(object sender, System.EventArgs e)
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

		private void remove_Click(object sender, System.EventArgs e)
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

		private void add_Click(object sender, System.EventArgs e)
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

		private void edit_Click(object sender, System.EventArgs e)
		{
			if (pathContentValue.SelectedIndex >= 0)
			{
				string value = new EditForm().SetSpecificValue(pathContentValue.SelectedItem.ToString());
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

		private void save_Click(object sender, System.EventArgs e)
		{
			string totalPathValue = "";
			foreach (string value in pathContentValue.Items)
			{
				totalPathValue = totalPathValue + value + ";";
			}
			applyTip.Visible = true;
			save.Enabled = false;
			cancel.Enabled = false;
			Application.DoEvents();
			Utils.RunSetx("Path", totalPathValue, true);
			Close();
			MessageBox.Show("修改完成！若发现环境变量并没有成功设定，请退出程序然后右键-以管理员身份运行此程序重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}