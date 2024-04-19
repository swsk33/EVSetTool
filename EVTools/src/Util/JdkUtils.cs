using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using System.Collections.Generic;
using System.Windows.Forms;
using Swsk33.EVTools.Strategy.Context;

namespace Swsk33.EVTools.Util
{
	/// <summary>
	/// java环境变量实用类
	/// </summary>
	public static class JdkUtils
	{
		/// <summary>
		/// jdk版本列表
		/// </summary>
		public static Dictionary<string, string> JdkVersions;

		/// <summary>
		/// JAVA_HOME变量名称
		/// </summary>
		private static readonly string JavaHomeName = "%JAVA_HOME%";

		/// <summary>
		/// classpath变量值
		/// </summary>
		private static readonly string ClasspathValue = ".;" + JavaHomeName + @"\lib\dt.jar;" + JavaHomeName + @"\lib\tools.jar";

		/// <summary>
		/// jdk追加Path变量值
		/// </summary>
		private static readonly string AddPathValue = JavaHomeName + @"\bin";

		/// <summary>
		/// Path中的冗余Java bin路径，需要去除
		/// </summary>
		private static readonly List<string> JavaBinaryDuplicatePath = new List<string>();

		/// <summary>
		/// 探测全部JDK
		/// </summary>
		public static void DetectJdKs()
		{
			JdkVersions = JdkDetectContext.DetectAllJdk();
			// 计算冗余值列表
			JavaBinaryDuplicatePath.Clear();
			// 加入Oracle JDK安装时的附加值
			JavaBinaryDuplicatePath.Add(@"C:\Program Files (x86)\Common Files\Oracle\Java\javapath");
			JavaBinaryDuplicatePath.Add(@"C:\Program Files\Common Files\Oracle\Java\javapath");
			// 加入已有JDK的配置冗余值
			foreach (string version in JdkVersions.Keys)
			{
				JavaBinaryDuplicatePath.Add(JdkVersions[version] + "\\bin");
				JavaBinaryDuplicatePath.Add(JdkVersions[version] + "\\bin\\");
			}
		}

		/// <summary>
		/// 设定JDK环境变量
		/// </summary>
		/// <param name="javaPath">jdk所在的路径</param>
		/// <param name="isJdk9AndAbove">是否是jdk9及其以上版本的jdk</param>
		public static void SetJdkValue(string javaPath, bool isJdk9AndAbove)
		{
			RegistryKey key = Registry.LocalMachine;
			RegistryKey evKey = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);
			// 先设定JAVA_HOME变量
			VariableUtils.SetSystemVariable("JAVA_HOME", javaPath);
			if (!RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "JAVA_HOME"))
			{
				MessageBox.Show(@"设定JAVA_HOME失败！请退出程序然后右键-以管理员身份运行此程序重试！", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 再设定classpath变量
			if (isJdk9AndAbove)
			{
				if (RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "classpath"))
				{
					evKey.DeleteValue("classpath");
				}
			}
			else
			{
				if (!RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "classpath") || !evKey.GetValue("classpath").Equals(ClasspathValue))
				{
					VariableUtils.SetSystemVariable("classpath", ClasspathValue);
				}
			}

			evKey.Close();
			key.Close();
			if (!isJdk9AndAbove && !RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "classpath"))
			{
				MessageBox.Show(@"设定classpath失败！请退出程序然后右键-以管理员身份运行此程序重试！", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 最后设定Path变量
			List<string> pathValues = new List<string>(RegUtils.GetPathVariable(false));
			// 去除冗余的Java bin路径
			ListUtils.BatchRemoveFromList(pathValues, JavaBinaryDuplicatePath);
			// 添加到Path
			if (!ListUtils.ListContainsIgnoreCase(pathValues, AddPathValue))
			{
				pathValues.Add(AddPathValue);
			}

			// 保存Path
			if (!VariableUtils.SavePath(pathValues.ToArray()))
			{
				MessageBox.Show(@"追加Path值失败！请退出程序然后右键-以管理员身份运行此程序重试！也可能是Path变量总长度超出限制！", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			MessageBox.Show(@"设置完成！", @"完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}