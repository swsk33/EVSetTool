using Microsoft.Win32;
using System.Windows.Forms;
using Swsk33.ReadAndWriteSharp;
using System.Collections.Generic;
using System;

namespace EVTools
{
	class Utils
	{
		/// <summary>
		/// 运行setx命令设定环境变量
		/// </summary>
		/// <param name="varName">设定变量名</param>
		/// <param name="value">变量值</param>
		/// <param name="isSysVar">是否是系统变量</param>
		public static void RunSetx(string varName, string value, bool isSysVar)
		{
			List<string> args = new List<string>();
			if (isSysVar)
			{
				args.Add("/m");
			}
			args.Add(varName);
			args.Add(value);
			Console.WriteLine(value);
			TerminalUtils.RunCommand("setx", args.ToArray());
		}

		/// <summary>
		/// 把指定值加入到Path环境变量中去
		/// </summary>
		/// <param name="value">指定值</param>
		/// <param name="showTip">是否显示提示</param>
		/// <param name="append">为true时将值追加到Path变量之后，否则插入到最前</param>
		public static bool AddValueToPath(string value, bool showTip, bool append)
		{
			bool result = false;
			RegistryKey EVKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment");
			string pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
			if (pathValue.Contains(value + ";") || pathValue.EndsWith(value))
			{
				if (showTip)
				{
					MessageBox.Show("这个值已经存在于Path中！无需重复添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				return true;
			}
			if (!pathValue.EndsWith(";"))
			{
				pathValue = pathValue + ";";
			}
			if (append)
			{
				RunSetx("Path", pathValue + value + ";", true);
				pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
				if (pathValue.EndsWith(value + ";"))
				{
					result = true;
				}
			}
			else
			{
				RunSetx("Path", value + ";" + pathValue, true);
				pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
				if (pathValue.StartsWith(value + ";"))
				{
					result = true;
				}
			}
			EVKey.Close();
			if (showTip)
			{
				if (result)
				{
					MessageBox.Show("设置完成！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("设定失败！请退出程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			return result;
		}
	}
}