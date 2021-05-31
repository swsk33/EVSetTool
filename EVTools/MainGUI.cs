using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace EVTools
{
	public partial class MainGUI : Form
	{
		public MainGUI()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
		}

		/// <summary>
		/// 调整组件状态
		/// </summary>
		private void GetRadioButtonChanged(object sender, System.EventArgs e)
		{
			if (jdkAutoSetOption.Checked)
			{
				jdkAutoSetValue.Enabled = true;
				jdkManualSetValue.Enabled = false;
				jdkManualSetButton.Enabled = false;
			}
			else if (jdkManualSetOption.Checked)
			{
				jdkAutoSetValue.Enabled = false;
				jdkManualSetValue.Enabled = true;
				jdkManualSetButton.Enabled = true;
			}
			if (pyAutoSetOption.Checked)
			{
				pyAutoSetValue.Enabled = true;
				pyManualSetValue.Enabled = false;
				pyManualSetButton.Enabled = false;
			}
			else if (pyManualSetOption.Checked)
			{
				pyAutoSetValue.Enabled = false;
				pyManualSetValue.Enabled = true;
				pyManualSetButton.Enabled = true;
			}
		}

		private void MainGUI_Load(object sender, System.EventArgs e)
		{
			JDKUtils.GetJDKVersion();
			if (JDKUtils.jdkVersions.Count == 0)
			{
				jdkAutoSetOption.Enabled = false;
				jdkAutoSetValue.Enabled = false;
				jdkNotFoundTip.Visible = true;
				jdkRecheck.Visible = true;
				jdkManualSetOption.Checked = true;
			}
			else
			{
				foreach (string version in JDKUtils.jdkVersions.Keys)
				{
					jdkAutoSetValue.Items.Add(version);
				}
				jdkAutoSetValue.SelectedIndex = 0;
			}
			PyUtils.GetPyVersions();
			if (PyUtils.pyVersions.Count == 0)
			{
				pyAutoSetOption.Enabled = false;
				pyAutoSetValue.Enabled = false;
				pyNotFoundTip.Visible = true;
				pyRecheck.Visible = true;
				pyManualSetOption.Checked = true;
			}
			else
			{
				foreach (string version in PyUtils.pyVersions.Keys)
				{
					pyAutoSetValue.Items.Add(version);
				}
				pyAutoSetValue.SelectedIndex = 0;
			}
			appendToolTip.SetToolTip(isAppend, "勾选此项，指定值会被追加到Path变量最后，优先级最低；反之值会被插入到Path变量最前，优先级最高。");
		}

		private void jdkManualSetButton_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择jdk所在的文件夹";
			dialog.ShowDialog();
			jdkManualSetValue.Text = dialog.SelectedPath;
		}

		private void otherSetButton_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择路径";
			dialog.ShowDialog();
			otherSetValue.Text = dialog.SelectedPath;
		}

		private void JDKok_Click(object sender, EventArgs e)
		{
			string javaPath = "";
			bool isJDK9Above = false;
			if (jdkAutoSetOption.Checked)
			{
				javaPath = JDKUtils.jdkVersions[jdkAutoSetValue.SelectedItem.ToString()];
				isJDK9Above = false;
				if (!jdkAutoSetValue.SelectedItem.ToString().StartsWith("1."))
				{
					isJDK9Above = true;
				}
			}
			else if (jdkManualSetOption.Checked)
			{
				javaPath = jdkManualSetValue.Text.ToString();
				if (javaPath.Equals(""))
				{
					MessageBox.Show("请先指定jdk所在路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				isJDK9Above = false;
				if (!Directory.Exists(javaPath + "\\jre"))
				{
					isJDK9Above = true;
				}
			}
			jdkSettingTip.Visible = true;
			new Thread(() =>
			{
				JDKUtils.SetJDKValue(javaPath, isJDK9Above);
				jdkSettingTip.Visible = false;
			}).Start();
		}

		private void jdkRecheck_Click(object sender, EventArgs e)
		{
			JDKUtils.GetJDKVersion();
			if (JDKUtils.jdkVersions.Count != 0)
			{
				jdkAutoSetOption.Enabled = true;
				jdkAutoSetValue.Enabled = true;
				jdkNotFoundTip.Visible = false;
				jdkRecheck.Visible = false;
				jdkAutoSetOption.Checked = true;
				foreach (string version in JDKUtils.jdkVersions.Keys)
				{
					jdkAutoSetValue.Items.Add(version);
				}
				jdkAutoSetValue.SelectedIndex = 0;
			}
		}

		private void otherOK_Click(object sender, EventArgs e)
		{
			if (otherSetValue.Text.Equals(""))
			{
				MessageBox.Show("请先指定待添加路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			otherSettingTip.Visible = true;
			new Thread(() =>
			{
				Utils.AddValueToPath(otherSetValue.Text, true, isAppend.Checked);
				otherSettingTip.Visible = false;
			}).Start();
		}

		private void pyRecheck_Click(object sender, EventArgs e)
		{
			PyUtils.GetPyVersions();
			if (PyUtils.pyVersions.Count != 0)
			{
				pyAutoSetValue.Enabled = true;
				pyAutoSetOption.Enabled = true;
				pyNotFoundTip.Visible = false;
				pyRecheck.Visible = false;
				pyAutoSetOption.Checked = true;
				foreach (string version in PyUtils.pyVersions.Keys)
				{
					pyAutoSetValue.Items.Add(version);
				}
				pyAutoSetValue.SelectedIndex = 0;
			}
		}

		private void pyManualSetFind_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择Python所在的文件夹";
			dialog.ShowDialog();
			pyManualSetValue.Text = dialog.SelectedPath;
		}

		private void pyOk_Click(object sender, EventArgs e)
		{
			string pyPath = "";
			if (pyAutoSetOption.Checked)
			{
				pyPath = PyUtils.pyVersions[pyAutoSetValue.SelectedItem.ToString()];
			}
			else if (pyManualSetOption.Checked)
			{
				if (pyManualSetValue.Text.Equals(""))
				{
					MessageBox.Show("请先指定Python所在路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				pyPath = pyManualSetValue.Text;
			}
			pySettingTip.Visible = true;
			new Thread(() =>
			{
				PyUtils.SetPythonValue(pyPath);
				pySettingTip.Visible = false;
			}).Start();
		}

		private void managePath_Click(object sender, EventArgs e)
		{
			new ManagePathForm().ShowDialog();
		}
	}
}