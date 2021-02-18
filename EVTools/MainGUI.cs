using System;
using System.IO;
using System.Windows.Forms;

namespace EVTools
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 调整组件状态
        /// </summary>
        private void GetRadioButtonChanged(object sender, System.EventArgs e)
        {
            if (autoSetOption.Checked)
            {
                autoSetValue.Enabled = true;
                manualSetValue.Enabled = false;
                manualSetButton.Enabled = false;
            }
            else if (manualSetOption.Checked)
            {
                autoSetValue.Enabled = false;
                manualSetValue.Enabled = true;
                manualSetButton.Enabled = true;
            }
        }

        private void MainGUI_Load(object sender, System.EventArgs e)
        {
            RegUtils.GetJDKVersion();
            if (RegUtils.jdkVersions.Count == 0)
            {
                autoSetOption.Enabled = false;
                autoSetValue.Enabled = false;
                jdkNotFoundTip.Visible = true;
                recheck.Visible = true;
                manualSetOption.Checked = true;
            }
            else
            {
                foreach (string version in RegUtils.jdkVersions.Keys)
                {
                    autoSetValue.Items.Add(version);
                }
                autoSetValue.SelectedIndex = 0;
            }
        }

        private void manualSetButton_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择jdk所在的文件夹";
            dialog.ShowDialog();
            manualSetValue.Text = dialog.SelectedPath;
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
            if (autoSetOption.Checked)
            {
                javaPath = RegUtils.jdkVersions[autoSetValue.SelectedItem.ToString()];
                isJDK9Above = false;
                if (!autoSetValue.SelectedItem.ToString().StartsWith("1."))
                {
                    isJDK9Above = true;
                }
            }
            else if (manualSetOption.Checked)
            {
                javaPath = manualSetValue.Text.ToString();
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
            RegUtils.SetJDKValue(javaPath, isJDK9Above);
        }

        private void recheck_Click(object sender, EventArgs e)
        {
            RegUtils.GetJDKVersion();
            if (RegUtils.jdkVersions.Count != 0)
            {
                autoSetOption.Enabled = true;
                autoSetValue.Enabled = true;
                jdkNotFoundTip.Visible = false;
                recheck.Visible = false;
                autoSetOption.Checked = true;
                foreach (string version in RegUtils.jdkVersions.Keys)
                {
                    autoSetValue.Items.Add(version);
                }
                autoSetValue.SelectedIndex = 0;
            }
        }

        private void otherOK_Click(object sender, EventArgs e)
        {
            if (otherSetValue.Text.Equals(""))
            {
                MessageBox.Show("请先指定待添加路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RegUtils.AddValueToPath(otherSetValue.Text);
        }
    }
}