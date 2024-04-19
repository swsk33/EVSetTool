using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Swsk33.EVTools.Dialog
{
	public partial class BackupDialog : Form
	{
		/// <summary>
		/// 存放编码列表
		/// </summary>
		private static readonly Dictionary<string, Encoding> EncodingPage = new Dictionary<string, Encoding>();

		/// <summary>
		/// 静态块
		/// </summary>
		static BackupDialog()
		{
			EncodingPage.Add("GBK", Encoding.GetEncoding("GBK"));
			EncodingPage.Add("UTF-8", new UTF8Encoding(false));
			EncodingPage.Add("UTF-8 with BOM", new UTF8Encoding(true));
			EncodingPage.Add("UTF-16", Encoding.GetEncoding("UTF-16"));
			EncodingPage.Add("ASCII", Encoding.GetEncoding("ASCII"));
		}

		public BackupDialog()
		{
			InitializeComponent();
			foreach (string key in EncodingPage.Keys)
			{
				encodingBox.Items.Add(key);
			}

			encodingBox.SelectedIndex = 0;
		}

		/// <summary>
		/// 环境变量转为命令
		/// </summary>
		/// <param name="varName">环境变量名</param>
		/// <returns>cmd命令形式</returns>
		private string VarToCommand(string varName)
		{
			return "setx /m " + StringUtils.SurroundByDoubleQuotes(varName) + " " + StringUtils.SurroundByDoubleQuotes(RegUtils.GetEnvironmentVariable(varName, expandVarCheckBox.Checked).Replace("%", "%%"));
		}

		/// <summary>
		/// 操纵所有按钮
		/// </summary>
		/// <param name="enable">如果传入true则将所有按钮设置为可用状态，否则把所有按钮禁用</param>
		private void OperateButtons(bool enable)
		{
			pathBackupButton.Enabled = enable;
			allBackupButton.Enabled = enable;
			backupTip.Visible = !enable;
		}

		/// <summary>
		/// 备份Path环境变量按钮
		/// </summary>
		private void pathBackupButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Title = @"请选择导出位置";
			dialog.Filter = @"批处理脚本(*.bat)|*.bat";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				OperateButtons(false);
				new Thread(() =>
				{
					string content = "@echo off\r\n" + VarToCommand("Path") + "\r\necho 还原Path变量完成！按任意键退出！\r\npause>nul";
					File.WriteAllText(dialog.FileName, content, EncodingPage[encodingBox.SelectedItem.ToString()]);
					MessageBox.Show(@"备份脚本已导出至：" + dialog.FileName, @"完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
					OperateButtons(true);
				}).Start();
			}
		}

		/// <summary>
		/// 备份全部系统环境变量按钮
		/// </summary>
		private void allBackupButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Title = @"请选择导出位置";
			dialog.Filter = @"批处理脚本(*.bat)|*.bat";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				OperateButtons(false);
				new Thread(() =>
				{
					List<string> contents = new List<string>
					{
						"@echo off"
					};
					// 获取全部的系统变量
					RegistryKey evKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment");
					string[] varNames = evKey.GetValueNames();
					evKey.Close();
					foreach (string varName in varNames)
					{
						contents.Add(VarToCommand(varName));
					}

					contents.Add("echo 还原所有系统变量完成！按任意键退出！");
					contents.Add("pause>nul");
					File.WriteAllLines(dialog.FileName, contents.ToArray(), EncodingPage[encodingBox.SelectedItem.ToString()]);
					MessageBox.Show(@"备份脚本已导出至：" + dialog.FileName, @"完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
					OperateButtons(true);
				}).Start();
			}
		}
	}
}