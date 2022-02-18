using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Swsk33.EVTools.Util
{
	public class PyUtils
	{
		//python版本列表
		public static Dictionary<string, string> pyVersions = new Dictionary<string, string>();
		//python home变量名
		private static readonly string PYHOME_NAME = "PYTHON_HOME";
		//Path追加变量1
		private static readonly string PATH_ADDITION_1 = "%" + PYHOME_NAME + "%";
		//Path追加变量2
		private static readonly string PATH_ADDITION_2 = "%" + PYHOME_NAME + "%\\Scripts";

		/// <summary>
		/// 获取已安装Python版本，存放于PyUtils类的全局静态变量pyVersions中。
		/// </summary>
		public static void GetPyVersions()
		{
			pyVersions.Clear();
			RegistryKey key = Registry.LocalMachine;
			if (RegUtils.IsItemExists(key, @"SOFTWARE\Python\PythonCore"))
			{
				RegistryKey pyVersionKey = key.OpenSubKey(@"SOFTWARE\Python\PythonCore");
				string[] pyVers = pyVersionKey.GetSubKeyNames();
				foreach (string v in pyVers)
				{
					string eachPyVarsionPath = @"SOFTWARE\Python\PythonCore\" + v + @"\InstallPath";
					if (RegUtils.IsItemExists(key, eachPyVarsionPath))
					{
						RegistryKey eachPyVerKey = key.OpenSubKey(eachPyVarsionPath);
						string pyPath = eachPyVerKey.GetValue("").ToString();
						pyPath = FilePathUtils.RemovePathEndBackslash(pyPath);
						pyVersions.Add(v, pyPath);
						eachPyVerKey.Close();
					}
				}
				pyVersionKey.Close();
			}
		}

		/// <summary>
		/// 设定Python环境变量
		/// </summary>
		/// <param name="pyPath">python所在位置</param>
		public static void SetPythonValue(string pyPath)
		{
			// 先执行Path去重
			List<string> pathValues = new List<string>(Utils.RemoveRedundantValueInPath());
			Utils.RunSetx(PYHOME_NAME, pyPath, true);
			pathValues.Add(PATH_ADDITION_1);
			pathValues.Add(PATH_ADDITION_2);
			if (!RegUtils.IsValueExists(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", PYHOME_NAME))
			{
				MessageBox.Show("设定PYTHON_HOME失败！请退出程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (!Utils.SavePath(pathValues.ToArray()))
			{
				MessageBox.Show("追加Path失败！请退出程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			MessageBox.Show("设置完成！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}