using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

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
			string args = "\"" + varName + "\" " + "\"" + value + "\"";
			if (isSysVar)
			{
				args = args + " /m";
			}
			Process process = new Process();
			process.StartInfo.FileName = "setx";
			process.StartInfo.Arguments = args;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			try
			{
				process.Start();
				_ = process.StandardOutput.ReadToEnd();
				_ = process.StandardError.ReadToEnd();
				process.WaitForExit();
			}
			catch
			{
				// none
			}
			finally
			{
				process.Close();
			}
		}

		/// <summary>
		/// 判断注册表项是否存在
		/// </summary>
		/// <param name="key">主键</param>
		/// <param name="name">项的完整路径</param>
		/// <returns></returns>
		public static bool IsRegExists(RegistryKey key, string name)
		{
			bool isExists = true;
			try
			{
				RegistryKey registryKey = key.OpenSubKey(name);
				registryKey.Close();
			}
			catch (Exception)
			{
				isExists = false;
			}
			return isExists;
		}

		/// <summary>
		/// 判断注册表某一项下的某个值是否存在
		/// </summary>
		/// <param name="key">主键</param>
		/// <param name="name">项名</param>
		/// <param name="valueName">值名</param>
		/// <returns></returns>
		public static bool IsRegValueExists(RegistryKey key, string name, string valueName)
		{
			bool isExists = false;
			if (IsRegExists(key, name))
			{
				RegistryKey registryKey = key.OpenSubKey(name);
				string[] subValues = registryKey.GetValueNames();
				foreach (string eachValueName in subValues)
				{
					Console.WriteLine(eachValueName);
					if (eachValueName.Equals(valueName))
					{
						isExists = true;
						break;
					}
				}
			}
			return isExists;
		}

		/// <summary>
		/// 把指定值加入到Path环境变量中去
		/// </summary>
		/// <param name="value">指定值</param>
		/// <param name="showTip">是否显示提示</param>
		/// <param name="append">为true时将值追加到Path变量之后，否则插入到最前</param>
		public static void AddValueToPath(string value, bool showTip, bool append)
		{
			RegistryKey EVKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment");
			string pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
			if (pathValue.Contains(value + ";") || pathValue.EndsWith(value))
			{
				if (showTip)
				{
					MessageBox.Show("这个值已经存在于Path中！无需重复添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				return;
			}
			if (!pathValue.EndsWith(";"))
			{
				pathValue = pathValue + ";";
			}
			if (append)
			{
				RunSetx("Path", pathValue + value + ";", true);
			}
			else
			{
				RunSetx("Path", value + ";" + pathValue, true);
			}
			EVKey.Close();
			if (showTip)
			{
				MessageBox.Show("设置完成！若发现环境变量并没有成功设定，请退出程序然后右键-以管理员身份运行此程序重试。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}