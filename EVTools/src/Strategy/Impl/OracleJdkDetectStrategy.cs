using System;
using System.Collections.Generic;
using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;

namespace Swsk33.EVTools.Strategy.Impl
{
	/// <summary>
	/// Oracle JDK查找具体策略
	/// </summary>
	public class OracleJdkDetectStrategy : IJdkDetectStrategy
	{
		/// <summary>
		/// 冗余版本信息
		/// </summary>
		private static readonly HashSet<String> NotAddVersionValue;

		static OracleJdkDetectStrategy()
		{
			// 初始化冗余版本列表
			NotAddVersionValue = new HashSet<string>
			{
				"1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8"
			};
		}

		public Dictionary<string, string> DetectJdkPath()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			RegistryKey key = Registry.LocalMachine;
			//检测jdk8及其以下版本
			if (RegUtils.IsItemExists(key, @"SOFTWARE\JavaSoft\Java Development Kit"))
			{
				RegistryKey jdkOldVersionsKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\Java Development Kit");
				string[] jdkOldVersions = jdkOldVersionsKey.GetSubKeyNames();
				foreach (string version in jdkOldVersions)
				{
					// 若不是冗余版本信息则进行添加
					if (!NotAddVersionValue.Contains(version))
					{
						RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\Java Development Kit\" + version);
						string path = jdkVersionKey.GetValue("JavaHome").ToString();
						path = FilePathUtils.RemovePathEndBackslash(path);
						result.Add(version + " - Oracle JDK", path);
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
					result.Add(version + " - Oracle JDK", path);
					jdkVersionKey.Close();
				}

				jdkNewVersionsKey.Close();
			}

			return result;
		}
	}
}