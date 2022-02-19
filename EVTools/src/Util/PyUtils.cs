using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Swsk33.EVTools.Util
{
	/// <summary>
	/// python环境变量实用类
	/// </summary>
	public class PyUtils
	{
		// python版本列表
		public static Dictionary<string, string> PythonVersions = new Dictionary<string, string>();

		// python home变量名
		private static readonly string PYHOME_NAME = "PYTHON_HOME";

		// Path追加变量1
		private static readonly string PATH_ADDITION_1 = "%" + PYHOME_NAME + "%";

		// Path追加变量2
		private static readonly string PATH_ADDITION_2 = "%" + PYHOME_NAME + "%\\Scripts";

		// Path中的冗余Python bin路径，需要去除
		private static List<string> pythonBinaryDuplicatePath = new List<string>();

		/// <summary>
		/// 获取已安装Python版本，存放于PyUtils类的全局静态变量PythonVersions中。
		/// </summary>
		public static void GetPyVersions()
		{
			PythonVersions.Clear();
			RegistryKey key = Registry.LocalMachine;
			if (RegUtils.IsItemExists(key, @"SOFTWARE\Python\PythonCore"))
			{
				RegistryKey pyVersionKey = key.OpenSubKey(@"SOFTWARE\Python\PythonCore");
				string[] pyVersions = pyVersionKey.GetSubKeyNames();
				foreach (string version in pyVersions)
				{
					string eachPyVarsionPath = @"SOFTWARE\Python\PythonCore\" + version + @"\InstallPath";
					if (RegUtils.IsItemExists(key, eachPyVarsionPath))
					{
						RegistryKey eachPyVerKey = key.OpenSubKey(eachPyVarsionPath);
						string pyPath = eachPyVerKey.GetValue("").ToString();
						pyPath = FilePathUtils.RemovePathEndBackslash(pyPath);
						PyUtils.PythonVersions.Add(version, pyPath);
						eachPyVerKey.Close();
					}
				}
				pyVersionKey.Close();
			}
			// 计算冗余值列表
			pythonBinaryDuplicatePath.Clear();
			foreach (string version in PythonVersions.Keys)
			{
				pythonBinaryDuplicatePath.Add(PythonVersions[version]);
				pythonBinaryDuplicatePath.Add(PythonVersions[version] + "\\Scripts");
			}
		}

		/// <summary>
		/// 设定Python环境变量
		/// </summary>
		/// <param name="pyPath">python所在位置</param>
		public static void SetPythonValue(string pyPath)
		{
			// 先设定PYTHON_HOME变量
			VariableUtils.RunSetx(PYHOME_NAME, pyPath, true);
			if (!RegUtils.IsValueExists(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", PYHOME_NAME))
			{
				MessageBox.Show("设定PYTHON_HOME失败！请退出程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			// 再设定Path变量
			// 先执行Path去重
			List<string> pathValues = new List<string>(VariableUtils.RemoveRedundantValueInPath());
			// 去除冗余路径
			foreach (string eachDuplicatePath in pythonBinaryDuplicatePath)
			{
				for (int i = 0; i < pathValues.Count; i++)
				{
					if (eachDuplicatePath.Equals(pathValues[i], StringComparison.CurrentCultureIgnoreCase))
					{
						pathValues.RemoveAt(i);
						break;
					}
				}
			}
			if (!ListUtils.ListContainsIgnoreCase(pathValues, PATH_ADDITION_1))
			{
				pathValues.Add(PATH_ADDITION_1);
			}
			if (!ListUtils.ListContainsIgnoreCase(pathValues, PATH_ADDITION_2))
			{
				pathValues.Add(PATH_ADDITION_2);
			}
			if (!VariableUtils.SavePath(pathValues.ToArray()))
			{
				MessageBox.Show("追加Path失败！请退出程序然后右键-以管理员身份运行此程序重试！也可能是Path变量总长度超出限制！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			MessageBox.Show("设置完成！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}