using Microsoft.Win32;
using System.Windows.Forms;
using Swsk33.ReadAndWriteSharp;
using System.Collections.Generic;

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
			if (value.EndsWith("\\"))
			{
				value = value.Substring(0, value.LastIndexOf("\\"));
			}
			args.Add(value);
			TerminalUtils.RunCommand("setx", args.ToArray());
		}

		/// <summary>
		/// 获取指定环境变量的值
		/// </summary>
		/// <param name="variableName">环境变量名</param>
		/// <returns>环境变量值</returns>
		public static string getVariableValue(string variableName)
		{
			RegistryKey EVKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment");
			string pathValue = EVKey.GetValue(variableName, "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
			EVKey.Close();
			return pathValue;
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
			string pathValue = getVariableValue("Path");
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
				pathValue = getVariableValue("Path");
				if (pathValue.EndsWith(value + ";"))
				{
					result = true;
				}
			}
			else
			{
				RunSetx("Path", value + ";" + pathValue, true);
				pathValue = getVariableValue("Path");
				if (pathValue.StartsWith(value + ";"))
				{
					result = true;
				}
			}
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