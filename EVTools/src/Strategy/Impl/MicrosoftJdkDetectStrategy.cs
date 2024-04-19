using System.Collections.Generic;
using Microsoft.Win32;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;

namespace Swsk33.EVTools.Strategy.Impl
{
	/// <summary>
	/// Microsoft JDK检测具体策略
	/// </summary>
	public class MicrosoftJdkDetectStrategy : IJdkDetectStrategy
	{
		public Dictionary<string, string> DetectJdkPath()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
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
					result.Add(msJDKVersion + " - Microsoft Build OpenJDK", path);
					jdkInfoKey.Close();
				}

				msJDKVersionKey.Close();
			}

			key.Close();
			return result;
		}
	}
}