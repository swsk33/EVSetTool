using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using Swsk33.EVTools.Model;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;

namespace Swsk33.EVTools.Util
{
	/// <summary>
	/// 设定Msys2环境变量的实用类
	/// </summary>
	public static class MsysUtils
	{
		/// <summary>
		/// 存放全部Msys2环境名称对应其对象的列表
		/// </summary>
		public static readonly Dictionary<string, MsysEnvironment> MsysEnvironmentMap = new Dictionary<string, MsysEnvironment>();

		/// <summary>
		/// 在Path中冗余的Msys2环境变量值，需要移除
		/// </summary>
		private static readonly List<string> MsysDuplicatePathList = new List<string>();

		/// <summary>
		/// MSYS2_HOME的变量名
		/// </summary>
		private const string MsysHomeName = "MSYS2_HOME";

		/// <summary>
		/// MSYS2_HOME变量引用形式
		/// </summary>
		private static readonly string MsysHomeVariable = $"%{MsysHomeName}%";

		static MsysUtils()
		{
			// 初始化环境列表
			MsysEnvironmentMap.Add("MSYS", new MsysEnvironment("MSYS", @"usr\bin", true, 0));
			MsysEnvironmentMap.Add("UCRT64", new MsysEnvironment("UCRT64", @"ucrt64\bin", true, 1));
			MsysEnvironmentMap.Add("CLANG64", new MsysEnvironment("CLANG64", @"clang64\bin", false, 2));
			MsysEnvironmentMap.Add("CLANGARM64", new MsysEnvironment("CLANGARM64", @"clangarm64\bin", false, 3));
			MsysEnvironmentMap.Add("CLANG32", new MsysEnvironment("CLANG32", @"clang32\bin", false, 4));
			MsysEnvironmentMap.Add("MINGW64", new MsysEnvironment("MINGW64", @"mingw64\bin", false, 5));
			MsysEnvironmentMap.Add("MINGW32", new MsysEnvironment("MINGW32", @"mingw32\bin", false, 6));
		}

		/// <summary>
		/// 根据MsysEnvironmentMap中每个对象的顺序，返回一个已排序的、存放环境对象的列表
		/// </summary>
		/// <param name="removeDisabled">当为true时，会移除环境对象列表中Enable属性为false的元素，使其不包含在结果列表中</param>
		/// <returns>已排序的环境对象列表</returns>
		public static List<MsysEnvironment> GetSortedEnvironmentList(bool removeDisabled)
		{
			List<MsysEnvironment> result = new List<MsysEnvironment>();
			foreach (string name in MsysEnvironmentMap.Keys)
			{
				MsysEnvironment item = MsysEnvironmentMap[name];
				if (removeDisabled && !item.Enabled)
				{
					continue;
				}

				result.Add(item);
			}

			// 排序列表
			result.Sort((x, y) => x.Order.CompareTo(y.Order));
			return result;
		}

		/// <summary>
		/// 设定Msys2的MSYS2_HOME环境变量，以及对应环境的Path变量
		/// </summary>
		/// <param name="msysPath">Msys2安装目录</param>
		public static void SetMsysValue(string msysPath)
		{
			// 先初始化冗余变量列表
			MsysDuplicatePathList.Clear();
			foreach (string name in MsysEnvironmentMap.Keys)
			{
				MsysEnvironment item = MsysEnvironmentMap[name];
				MsysDuplicatePathList.Add($@"{MsysHomeVariable}\{item.Path}");
				MsysDuplicatePathList.Add($@"{FilePathUtils.RemovePathEndBackslash(msysPath)}\{item.Path}");
				MsysDuplicatePathList.Add($@"{MsysHomeVariable}\{item.Path}\");
				MsysDuplicatePathList.Add($@"{FilePathUtils.RemovePathEndBackslash(msysPath)}\{item.Path}\");
			}

			// 注册表
			RegistryKey key = Registry.LocalMachine;
			// 设定MSYS2_HOME变量
			VariableUtils.SetSystemVariable(MsysHomeName, msysPath);
			if (!RegUtils.IsValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", MsysHomeName))
			{
				MessageBox.Show($@"设定{MsysHomeName}失败！请退出程序然后右键-以管理员身份运行此程序重试！", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 加入对应环境到Path环境变量
			// 获取Path
			List<string> pathValues = new List<string>(RegUtils.GetPathVariable(false));
			// 去除冗余
			ListUtils.BatchRemoveFromList(pathValues, MsysDuplicatePathList);
			// 获取并加入启用的环境
			List<MsysEnvironment> enabledEnvironments = GetSortedEnvironmentList(true);
			foreach (MsysEnvironment eachEnvironment in enabledEnvironments)
			{
				pathValues.Add($@"{MsysHomeVariable}\{eachEnvironment.Path}");
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