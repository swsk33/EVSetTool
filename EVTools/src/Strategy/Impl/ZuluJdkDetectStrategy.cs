using System.Collections.Generic;
using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;

namespace Swsk33.EVTools.Strategy.Impl
{
	/// <summary>
	/// Azul Zulu OpenJDK检测具体策略
	/// </summary>
	public class ZuluJdkDetectStrategy : IJdkDetectStrategy
	{
		public Dictionary<string, string> DetectJdkPath()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
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
					result.Add(zuluJDKVersion + " - Azul Zulu OpenJDK", path);
					infoKey.Close();
				}

				jdkVersionKey.Close();
			}

			return result;
		}
	}
}