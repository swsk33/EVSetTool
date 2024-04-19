using System.Collections.Generic;
using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;

namespace Swsk33.EVTools.Strategy.Impl
{
	/// <summary>
	/// Adopt OpenJDK检测具体策略
	/// </summary>
	public class AdoptJdkDetectStrategy : IJdkDetectStrategy
	{
		public Dictionary<string, string> DetectJdkPath()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
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
					result.Add(adoptJDKVersion + " - Adopt Hotspot OpenJDK", path);
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
					result.Add(adoptJDKVersion + " - Adopt Hotspot OpenJDK", path);
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
					result.Add(adoptJDKVersion + " - Adopt OpenJ9 OpenJDK", path);
					infoKey.Close();
				}

				jdkVersionKey.Close();
			}

			key.Close();
			return result;
		}
	}
}