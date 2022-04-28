using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Swsk33.EVTools.Util
{
	/// <summary>
	/// java环境变量实用类
	/// </summary>
	public class JDKUtils
	{
		/// <summary>
		/// 冗余版本信息
		/// </summary>
		private static readonly string[] NOT_ADD_VERSION_VALUE = { "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8" };

		/// <summary>
		/// jdk版本列表
		/// </summary>
		public static Dictionary<string, string> JDKVersions = new Dictionary<string, string>();

		/// <summary>
		/// JAVA_HOME变量名称
		/// </summary>
		private static readonly string JAVA_HOME_NAME = "%JAVA_HOME%";

		/// <summary>
		/// classpath变量值
		/// </summary>
		private static readonly string CLASSPATH_VALUE = ".;" + JAVA_HOME_NAME + @"\lib\dt.jar;" + JAVA_HOME_NAME + @"\lib\tools.jar";

		/// <summary>
		/// jdk追加Path变量值
		/// </summary>
		private static readonly string ADD_PATH_VALUE = JAVA_HOME_NAME + @"\bin";

		/// <summary>
		/// Oracle JDK安装附加值
		/// </summary>
		private static readonly string[] ORACLE_SETUP_PATHS = { @"C:\Program Files (x86)\Common Files\Oracle\Java\javapath", @"C:\Program Files\Common Files\Oracle\Java\javapath" };

		/// <summary>
		/// Path中的冗余Java bin路径，需要去除
		/// </summary>
		private static List<string> javaBinaryDuplicatePath = new List<string>();

		/// <summary>
		/// 检测已安装Oracle JDK版本，信息储存至JDKUtils类的全局静态变量JDKVersions中。
		/// </summary>
		private static void getOracleJDKVersion()
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
						path = FilePathUtils.RemovePathEndBackslash(path);
						JDKVersions.Add(version + " - Oracle JDK", path);
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
					path = FilePathUtils.RemovePathEndBackslash(path);
					JDKVersions.Add(version + " - Oracle JDK", path);
					jdkVersionKey.Close();
				}
				jdkNewVersionsKey.Close();
			}
		}

		/// <summary>
		/// 检测已安装Microsoft JDK版本，信息储存至JDKUtils类的全局静态变量JDKVersions中。
		/// </summary>
		private static void getMicrosoftJDKVersion()
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
					path = FilePathUtils.RemovePathEndBackslash(path);
					JDKVersions.Add(msJDKVersion + " - Microsoft Build OpenJDK", path);
					jdkInfoKey.Close();
				}
				msJDKVersionKey.Close();
			}
			key.Close();
		}

		/// <summary>
		/// 检测已安装Adopt OpenJDK版本，信息储存至JDKUtils类的全局静态变量JDKVersions中。
		/// </summary>
		private static void getAdpotJDKVersion()
		{
			RegistryKey key = Registry.LocalMachine;
			// 检测Hotspot VM JDK
			if (RegUtils.IsItemExists(key, @"SOFTWARE\Temurin\JDK"))
			{
				RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\Temurin\JDK");
				string[] adoptJDKVersions = jdkVersionKey.GetSubKeyNames();
				foreach (string adoptJDKVersion in adoptJDKVersions)
				{
					RegistryKey infoKey = jdkVersionKey.OpenSubKey(adoptJDKVersion + @"\hotspot\MSI");
					string path = infoKey.GetValue("Path").ToString();
					path = FilePathUtils.RemovePathEndBackslash(path);
					JDKVersions.Add(adoptJDKVersion + " - Adopt Hotspot OpenJDK", path);
					infoKey.Close();
				}
				jdkVersionKey.Close();
			}
			if (RegUtils.IsItemExists(key, @"SOFTWARE\Eclipse Foundation\JDK"))
			{
				RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\Eclipse Foundation\JDK");
				string[] adoptJDKVersions = jdkVersionKey.GetSubKeyNames();
				foreach (string adoptJDKVersion in adoptJDKVersions)
				{
					RegistryKey infoKey = jdkVersionKey.OpenSubKey(adoptJDKVersion + @"\hotspot\MSI");
					string path = infoKey.GetValue("Path").ToString();
					path = FilePathUtils.RemovePathEndBackslash(path);
					JDKVersions.Add(adoptJDKVersion + " - Adopt Hotspot OpenJDK", path);
					infoKey.Close();
				}
				jdkVersionKey.Close();
			}
			// 检测OpenJ9 VM JDK
			if (RegUtils.IsItemExists(key, @"SOFTWARE\Semeru\JDK"))
			{
				RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\Semeru\JDK");
				string[] adoptJDKVersions = jdkVersionKey.GetSubKeyNames();
				foreach (string adoptJDKVersion in adoptJDKVersions)
				{
					RegistryKey infoKey = jdkVersionKey.OpenSubKey(adoptJDKVersion + @"\openj9\MSI");
					string path = infoKey.GetValue("Path").ToString();
					path = FilePathUtils.RemovePathEndBackslash(path);
					JDKVersions.Add(adoptJDKVersion + " - Adopt OpenJ9 OpenJDK", path);
					infoKey.Close();
				}
				jdkVersionKey.Close();
			}
			key.Close();
		}

		/// <summary>
		/// 检测已安装Azul Zulu OpenJDK版本，信息储存至JDKUtils类的全局静态变量JDKVersions中。
		/// </summary>
		private static void getAzulZuluJDKVersion()
		{
			RegistryKey key = Registry.LocalMachine;
			if (RegUtils.IsItemExists(key, @"SOFTWARE\Azul Systems\Zulu"))
			{
				RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\Azul Systems\Zulu");
				string[] zuluJDKVersions = jdkVersionKey.GetSubKeyNames();
				foreach (string zuluJDKVersion in zuluJDKVersions)
				{
					RegistryKey infoKey = jdkVersionKey.OpenSubKey(zuluJDKVersion);
					string path = infoKey.GetValue("InstallationPath").ToString();
					path = FilePathUtils.RemovePathEndBackslash(path);
					JDKVersions.Add(zuluJDKVersion + " - Azul Zulu OpenJDK", path);
					infoKey.Close();
				}
				jdkVersionKey.Close();
			}
		}

		/// <summary>
		/// 探测全部JDK
		/// </summary>
		public static void DetectJDKs()
		{
			JDKVersions.Clear();
			getOracleJDKVersion();
			getMicrosoftJDKVersion();
			getAdpotJDKVersion();
			getAzulZuluJDKVersion();
			// 计算冗余值列表
			javaBinaryDuplicatePath.Clear();
			javaBinaryDuplicatePath.AddRange(ORACLE_SETUP_PATHS);
			foreach (string version in JDKVersions.Keys)
			{
				javaBinaryDuplicatePath.Add(JDKVersions[version] + "\\bin");
			}
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
			// 先设定JAVA_HOME变量
			VariableUtils.RunSetx("JAVA_HOME", javaPath, true);
			if (!RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "JAVA_HOME"))
			{
				MessageBox.Show("设定JAVA_HOME失败！请退出程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			// 再设定classpath变量
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
					VariableUtils.RunSetx("classpath", CLASSPATH_VALUE, true);
				}
			}
			EVKey.Close();
			key.Close();
			if (!isJDK9AndAbove && !RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "classpath"))
			{
				MessageBox.Show("设定classpath失败！请退出程序然后右键-以管理员身份运行此程序重试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			// 最后设定Path变量
			// 执行Path去重
			List<string> pathValues = new List<string>(PathValuesUtils.RemoveDuplicateValueInPathAndFormat());
			// 去除冗余的Java bin路径
			ListUtils.BatchRemoveFromList(pathValues, javaBinaryDuplicatePath);
			// 添加到Path
			if (!ListUtils.ListContainsIgnoreCase(pathValues, ADD_PATH_VALUE))
			{
				pathValues.Add(ADD_PATH_VALUE);
			}
			// 保存Path
			if (!VariableUtils.SavePath(pathValues.ToArray()))
			{
				MessageBox.Show("追加Path值失败！请退出程序然后右键-以管理员身份运行此程序重试！也可能是Path变量总长度超出限制！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			MessageBox.Show("设置完成！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}