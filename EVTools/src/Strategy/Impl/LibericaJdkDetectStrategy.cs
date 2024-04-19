using System.Collections.Generic;
using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;

namespace Swsk33.EVTools.Strategy.Impl
{
	/// <summary>
	/// BellSoft Liberica OpenJDK的检测实际策略
	/// </summary>
	public class LibericaJdkDetectStrategy : IJdkDetectStrategy
	{
		public Dictionary<string, string> DetectJdkPath()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			RegistryKey key = Registry.LocalMachine;
			if (RegUtils.IsItemExists(key, @"SOFTWARE\BellSoft\Liberica"))
			{
				RegistryKey libericaJdkKey = key.OpenSubKey(@"SOFTWARE\BellSoft\Liberica");
				string[] libericaVersions = libericaJdkKey.GetSubKeyNames();
				foreach (string version in libericaVersions)
				{
					RegistryKey jdkInfoKey = libericaJdkKey.OpenSubKey(version);
					string path = jdkInfoKey.GetValue("InstallationPath").ToString();
					path = FilePathUtils.RemovePathEndBackslash(path);
					result.Add(version + " - Liberica OpenJDK", path);
					jdkInfoKey.Close();
				}

				libericaJdkKey.Close();
			}

			key.Close();
			return result;
		}
	}
}