using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EVTools
{
	class PyUtils
	{
		//python版本列表
		public static Dictionary<string, string> pyVersions = new Dictionary<string, string>();
		//python home变量名
		private static readonly string PYHOME_NAME = "PYTHON_HOME";
		//Path追加变量1
		private static readonly string PATH_ADDITION_1 = "%PYTHON_HOME%";
		//Path追加变量2
		private static readonly string PATH_ADDITION_2 = "%PYTHON_HOME%\\Scripts";

		/// <summary>
		/// 获取已安装Python版本，存放于PyUtils类的全局静态变量pyVersions中。
		/// </summary>
		public static void GetPyVersions()
		{
			pyVersions.Clear();
			RegistryKey key = Registry.LocalMachine;
			if (Utils.IsRegExists(key, @"SOFTWARE\Python\PythonCore"))
			{
				RegistryKey pyVersionKey = key.OpenSubKey(@"SOFTWARE\Python\PythonCore");
				string[] pyVers = pyVersionKey.GetSubKeyNames();
				foreach (string v in pyVers)
				{
					string eachPyVarsionPath = @"SOFTWARE\Python\PythonCore\" + v + @"\InstallPath";
					if (Utils.IsRegExists(key, eachPyVarsionPath))
					{
						RegistryKey eachPyVerKey = key.OpenSubKey(eachPyVarsionPath);
						string pyPath = eachPyVerKey.GetValue("").ToString();
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
			if (pyPath.EndsWith("\\"))
			{
				pyPath = pyPath.Substring(0, pyPath.Length - 1);
			}
			Utils.RunSetx(PYHOME_NAME, pyPath, true);
			Utils.AddValueToPath(PATH_ADDITION_1, false, true);
			Utils.AddValueToPath(PATH_ADDITION_2, false, true);
			MessageBox.Show("设置完成！若发现环境变量并没有成功设定，请退出程序然后右键-以管理员身份运行此程序重试。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}