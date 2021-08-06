using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Swsk33.ReadAndWriteSharp;

namespace EVTools
{
	class JDKUtils
	{
		//冗余版本信息
		private static readonly string[] NOT_ADD_VERSION_VALUE = { "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8" };
		//jdk版本列表
		public static Dictionary<string, string> jdkVersions = new Dictionary<string, string>();
		//JAVA_HOME变量名称
		private static readonly string JAVA_HOME_NAME = "%JAVA_HOME%";
		//classpath变量值
		private static readonly string CLASSPATH_VALUE = ".;" + JAVA_HOME_NAME + @"\lib\dt.jar;" + JAVA_HOME_NAME + @"\lib\tools.jar";
		//jdk追加Path变量值
		private static readonly string ADD_PATH_VALUE = JAVA_HOME_NAME + @"\bin";

		/// <summary>
		/// 检测已安装Oracle JDK版本，信息储存至JDKUtils类的全局静态变量jdkVersions中。
		/// </summary>
		public static void GetOracleJDKVersion()
		{
			RegistryKey key = Registry.LocalMachine;
			//检测jdk8及其以下版本
			if (RegUtils.IsItemExists(key, @"SOFTWARE\JavaSoft\Java Development Kit"))
			{
				RegistryKey jdkOldVersionsKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\Java Development Kit");
				string[] jdkOldVersions = jdkOldVersionsKey.GetSubKeyNames();
				foreach (string version in jdkOldVersions)
				{
					if (Array.IndexOf(NOT_ADD_VERSION_VALUE, version) == -1)
					{
						RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\Java Development Kit\" + version);
						string path = jdkVersionKey.GetValue("JavaHome").ToString();
						jdkVersions.Add(version + " - Oracle JDK", path);
						jdkVersionKey.Close();
					}
				}
				jdkOldVersionsKey.Close();
			}
			//检测jdk9及其以上版本
			if (RegUtils.IsItemExists(key, @"SOFTWARE\JavaSoft\JDK"))
			{
				RegistryKey jdkNewVersionsKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\JDK");
				string[] jdkNewVersions = jdkNewVersionsKey.GetSubKeyNames();
				foreach (string version in jdkNewVersions)
				{
					RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\JDK\" + version);
					string path = jdkVersionKey.GetValue("JavaHome").ToString();
					jdkVersions.Add(version + " - Oracle JDK", path);
					jdkVersionKey.Close();
				}
				jdkNewVersionsKey.Close();
			}
		}

		/// <summary>
		/// 检测已安装Microsoft JDK版本，信息储存至JDKUtils类的全局静态变量jdkVersions中。
		/// </summary>
		public static void GetMicrosoftJDKVersion()
		{
			RegistryKey key = Registry.LocalMachine;
			if (RegUtils.IsItemExists(key, @"SOFTWARE\Microsoft\JDK"))
			{
				RegistryKey msJDKVersionKey = key.OpenSubKey(@"SOFTWARE\Microsoft\JDK");
				string[] msJDKVersions = msJDKVersionKey.GetSubKeyNames();
				foreach (string msJDKVersion in msJDKVersions)
				{
					RegistryKey jdkInfoKey = msJDKVersionKey.OpenSubKey(msJDKVersion + @"\hotspot\MSI");
					string path = jdkInfoKey.GetValue("Path").ToString();
					jdkVersions.Add(msJDKVersion + " - Microsoft JDK", path);
					jdkInfoKey.Close();
				}
				msJDKVersionKey.Close();
			}
			key.Close();
		}

		/// <summary>
		/// 设定JDK环境变量
		/// </summary>
		/// <param name="javaPath">jdk所在的路径</param>
		/// <param name="isJDK9AndAbove">是否是jdk9及其以上版本的jdk</param>
		public static void SetJDKValue(string javaPath, bool isJDK9AndAbove)
		{
			RegistryKey key = Registry.LocalMachine;
			RegistryKey EVKey = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);
			if (javaPath.EndsWith("\\"))
			{
				javaPath = javaPath.Substring(0, javaPath.Length - 1);
			}
			Utils.RunSetx("JAVA_HOME", javaPath, true);
			if (isJDK9AndAbove)
			{
				if (RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "classpath"))
				{
					EVKey.DeleteValue("classpath");
				}
			}
			else
			{
				if (!RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "classpath") || !EVKey.GetValue("classpath").Equals(CLASSPATH_VALUE))
				{
					Utils.RunSetx("classpath", CLASSPATH_VALUE, true);
				}
			}
			bool setPath = Utils.AddValueToPath(ADD_PATH_VALUE, false, false);
			EVKey.Close();
			key.Close();
			if (!RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "JAVA_HOME"))
			{
				MessageBox.Show("设定JAVA_HOME失败！请退出程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (!isJDK9AndAbove && !RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "classpath"))
			{
				MessageBox.Show("设定classpath失败！请退出程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (!setPath)
			{
				MessageBox.Show("追加Path值失败！请退出程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			MessageBox.Show("设置完成！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}