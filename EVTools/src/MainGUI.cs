using Swsk33.EVTools.Dialog;
using Swsk33.EVTools.Util;
using Swsk33.ReadAndWriteSharp.Util;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Swsk33.EVTools
{
	public partial class MainGUI : Form
	{
		/// <summary>
		/// 在使用添加路径至Path选项卡时，记录上一次指定的目录
		/// </summary>
		private string lastAddPath = "";

		public MainGUI()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
		}

		/// <summary>
		/// 调整组件状态
		/// </summary>
		private void GetRadioButtonChanged(object sender, EventArgs e)
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

		/// <summary>
		/// 窗口加载初始化
		/// </summary>
		private void MainGUI_Load(object sender, EventArgs e)
		{
			// 探测JDK
			JDKUtils.DetectJDKs();
			if (JDKUtils.JDKVersions.Count == 0)
			{
				jdkAutoSetOption.Enabled = false;
				jdkAutoSetValue.Enabled = false;
				jdkNotFoundTip.Visible = true;
				jdkRecheck.Visible = true;
				jdkManualSetOption.Checked = true;
			}
			else
			{
				foreach (string version in JDKUtils.JDKVersions.Keys)
				{
					jdkAutoSetValue.Items.Add(version);
				}
				jdkAutoSetValue.SelectedIndex = 0;
			}
			// 探测Python
			PyUtils.GetPyVersions();
			if (PyUtils.PythonVersions.Count == 0)
			{
				pyAutoSetOption.Enabled = false;
				pyAutoSetValue.Enabled = false;
				pyNotFoundTip.Visible = true;
				pyRecheck.Visible = true;
				pyManualSetOption.Checked = true;
			}
			else
			{
				foreach (string version in PyUtils.PythonVersions.Keys)
				{
					pyAutoSetValue.Items.Add(version);
				}
				pyAutoSetValue.SelectedIndex = 0;
			}
			mainToolTip.SetToolTip(isAppend, "勾选此项，指定值会被追加到Path变量最后，优先级最低；反之值会被插入到Path变量最前，优先级最高。");
			mainToolTip.SetToolTip(JDKok, "点击以设定JDK环境变量。若已经设置JDK环境变量，还可以选择列表中其它版本JDK然后点击设定按钮以切换至指定JDK版本。");
			mainToolTip.SetToolTip(pyOk, "点击以设定Python环境变量。若已经设置Python环境变量，还可以选择列表中其它版本Python然后点击设定按钮以切换至指定Python版本。");
		}

		/// <summary>
		/// 手动选择JDK路径-浏览按钮
		/// </summary>
		private void jdkManualSetButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择jdk所在的文件夹";
			dialog.ShowDialog();
			jdkManualSetValue.Text = dialog.SelectedPath;
		}

		/// <summary>
		/// 确认设定JDK环境变量
		/// </summary>
		private void JDKok_Click(object sender, EventArgs e)
		{
			string javaPath = "";
			bool isJDK9Above = false;
			if (jdkAutoSetOption.Checked)
			{
				javaPath = JDKUtils.JDKVersions[jdkAutoSetValue.SelectedItem.ToString()];
			}
			else if (jdkManualSetOption.Checked)
			{
				javaPath = jdkManualSetValue.Text.ToString();
				if (StringUtils.IsEmpty(javaPath))
				{
					MessageBox.Show("请先指定jdk所在路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			if (!Directory.Exists(javaPath + "\\jre"))
			{
				isJDK9Above = true;
			}
			JDKok.Enabled = false;
			jdkSettingTip.Visible = true;
			new Thread(() =>
			{
				JDKUtils.SetJDKValue(javaPath, isJDK9Above);
				jdkSettingTip.Visible = false;
				JDKok.Enabled = true;
			}).Start();
		}

		/// <summary>
		/// 重新探测JDK按钮
		/// </summary>
		private void jdkRecheck_Click(object sender, EventArgs e)
		{
			JDKUtils.DetectJDKs();
			if (JDKUtils.JDKVersions.Count != 0)
			{
				jdkAutoSetOption.Enabled = true;
				jdkAutoSetValue.Enabled = true;
				jdkNotFoundTip.Visible = false;
				jdkRecheck.Visible = false;
				jdkAutoSetOption.Checked = true;
				foreach (string version in JDKUtils.JDKVersions.Keys)
				{
					jdkAutoSetValue.Items.Add(version);
				}
				jdkAutoSetValue.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// 重新探测Python按钮
		/// </summary>
		private void pyRecheck_Click(object sender, EventArgs e)
		{
			PyUtils.GetPyVersions();
			if (PyUtils.PythonVersions.Count != 0)
			{
				pyAutoSetValue.Enabled = true;
				pyAutoSetOption.Enabled = true;
				pyNotFoundTip.Visible = false;
				pyRecheck.Visible = false;
				pyAutoSetOption.Checked = true;
				foreach (string version in PyUtils.PythonVersions.Keys)
				{
					pyAutoSetValue.Items.Add(version);
				}
				pyAutoSetValue.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// 手动设定Python路径-浏览按钮
		/// </summary>
		private void pyManualSetFind_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择Python所在的文件夹";
			dialog.ShowDialog();
			pyManualSetValue.Text = dialog.SelectedPath;
		}

		/// <summary>
		/// 设定Python环境变量按钮
		/// </summary>
		private void pyOk_Click(object sender, EventArgs e)
		{
			string pyPath = "";
			if (pyAutoSetOption.Checked)
			{
				pyPath = PyUtils.PythonVersions[pyAutoSetValue.SelectedItem.ToString()];
			}
			else if (pyManualSetOption.Checked)
			{
				if (StringUtils.IsEmpty(pyManualSetValue.Text))
				{
					MessageBox.Show("请先指定Python所在路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				pyPath = pyManualSetValue.Text;
			}
			pyOk.Enabled = false;
			pySettingTip.Visible = true;
			new Thread(() =>
			{
				PyUtils.SetPythonValue(pyPath);
				pySettingTip.Visible = false;
				pyOk.Enabled = true;
			}).Start();
		}

		/// <summary>
		/// 实用工具按钮
		/// </summary>
		private void utilitiesButton_Click(object sender, EventArgs e)
		{
			new UtilitiesDialog().ShowDialog();
		}

		/// <summary>
		/// 管理Path变量按钮
		/// </summary>
		private void managePath_Click(object sender, EventArgs e)
		{
			new ManagePathDialog().ShowDialog();
		}

		/// <summary>
		/// 加入路径至Path-浏览按钮
		/// </summary>
		private void otherSetButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择路径";
			if (!StringUtils.IsEmpty(lastAddPath))
			{
				dialog.SelectedPath = lastAddPath;
			}
			dialog.ShowDialog();
			otherSetValue.Text = dialog.SelectedPath;
			lastAddPath = dialog.SelectedPath;
		}

		/// <summary>
		/// 加入路径至Path环境变量-确认按钮
		/// </summary>
		private void otherOK_Click(object sender, EventArgs e)
		{
			if (StringUtils.IsEmpty(otherSetValue.Text))
			{
				MessageBox.Show("请先指定待添加路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (otherSetValue.Text.Contains("\""))
			{
				MessageBox.Show("添加的路径中不能包含英文双引号(\")！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			otherOK.Enabled = false;
			otherSettingTip.Visible = true;
			new Thread(() =>
			{
				VariableUtils.AddValueToPath(otherSetValue.Text, isAppend.Checked);
				otherSettingTip.Visible = false;
				otherOK.Enabled = true;
			}).Start();
		}
	}
}