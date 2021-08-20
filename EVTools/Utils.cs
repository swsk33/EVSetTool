using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EVTools
{
	class Utils
	{
		/// <summary>
		/// 去掉原字符串最末尾的反斜杠(\)
		/// </summary>
		/// <param name="origin">原字符串</param>
		/// <returns>去掉末尾反斜杠后的字符串，若原字符串不以反斜杠结尾则返回原字符串</returns>
		public static string RemoveEndBackslash(string origin)
		{
			if (origin.EndsWith("\\"))
			{
				origin = origin.Substring(0, origin.LastIndexOf("\\"));
			}
			return origin;
		}

		/// <summary>
		/// 去除一个变量值中冗余值（例如Path中已经包含了java路径：C:\Program Files\Java\jdk_x.x.x\bin和%JAVA_HOME%\bin，这两个值实质上一样，因此需要从Path去掉前者重复值，传入Path或者其它变量值和重复值，即可从中去除重复值并返回新值）
		/// </summary>
		/// <param name="originValue">原值</param>
		/// <param name="removeValue">带去除值</param>
		/// <returns>去除冗余后的新值</returns>
		public static string removeRedundantValue(string originValue, string removeValue)
		{
			if (originValue.EndsWith(removeValue))
			{
				originValue = originValue.Replace(removeValue, "");
			}
			string removeValueVar = removeValue + ";";
			if (originValue.Contains(removeValueVar))
			{
				originValue = originValue.Replace(removeValueVar, "");
			}
			string removeValueSep = removeValue + "\\";
			if (originValue.EndsWith(removeValueSep))
			{
				originValue = originValue.Replace(removeValueSep, "");
			}
			string removeValueSepVar = removeValueSep + ";";
			if (originValue.Contains(removeValueSepVar))
			{
				originValue = originValue.Replace(removeValueSepVar, "");
			}
			return originValue;
		}

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
			value = RemoveEndBackslash(value);
			args.Add(value);
			TerminalUtils.RunCommand("setx", args.ToArray());
		}

		/// <summary>
		/// 获取指定环境变量的值
		/// </summary>
		/// <param name="variableName">环境变量名</param>
		/// <returns>环境变量值</returns>
		public static string GetVariableValue(string variableName)
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
			string pathValue = GetVariableValue("Path");
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
				pathValue = GetVariableValue("Path");
				if (pathValue.EndsWith(value + ";"))
				{
					result = true;
				}
			}
			else
			{
				RunSetx("Path", value + ";" + pathValue, true);
				pathValue = GetVariableValue("Path");
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

		/// <summary>
		/// 把Path变量中的C:\Windows替换为%SystemRoot%的引用形式
		/// </summary>
		/// <returns>是否替换成功</returns>
		public static bool SetSystemRootRefer()
		{
			bool result = false;
			string pathValue = GetVariableValue("Path");
			string systemRootRefer = "%SystemRoot%";
			string systemRootValue = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
			pathValue = pathValue.Replace(systemRootValue, systemRootRefer);
			pathValue = pathValue.Replace(systemRootRefer.ToUpper(), systemRootRefer);
			pathValue = pathValue.Replace(systemRootRefer.ToLower(), systemRootRefer);
			RunSetx("Path", pathValue, true);
			if (!GetVariableValue("Path").Contains(systemRootValue))
			{
				result = true;
			}
			return result;
		}

		/// <summary>
		/// 移除Path变量中，以反斜杠结尾的路径的末尾的反斜杠
		/// </summary>
		/// <returns>是否移除成功</returns>
		public static bool RemovePathSeparatorAtTheEnd()
		{
			bool result = false;
			string pathValue = GetVariableValue("Path");
			if (pathValue.EndsWith(";"))
			{
				pathValue = pathValue.Substring(0, pathValue.LastIndexOf(";"));
			}
			string[] paths = pathValue.Split(';');
			string resultPathValue = "";
			foreach (string path in paths)
			{
				resultPathValue = resultPathValue + RemoveEndBackslash(path) + ";";
			}
			RunSetx("Path", resultPathValue, true);
			if (resultPathValue.Equals(GetVariableValue("Path")))
			{
				result = true;
			}
			return result;
		}
	}
}