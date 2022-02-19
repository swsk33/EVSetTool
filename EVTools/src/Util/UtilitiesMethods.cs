using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;
using System;

namespace Swsk33.EVTools.Util
{
	/// <summary>
	/// 用于存放实用工具窗口中按钮调用方法的类，这些方法还可能被其它地方复用
	/// </summary>
	public class UtilitiesMethods
	{
		/// <summary>
		/// 把Path变量中的C:\Windows替换为%SystemRoot%的引用形式
		/// </summary>
		/// <returns>是否替换成功</returns>
		public static bool SetSystemRootReference()
		{
			string systemRootValue = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
			string systemRootName = "%SystemRoot%";
			string[] pathValues = RegUtils.GetPathVariable(false);
			for (int i = 0; i < pathValues.Length; i++)
			{
				// 先检测路径是否是C:\Windows打头
				string prefix = pathValues[i].Substring(0, systemRootValue.Length);
				if (prefix.Equals(systemRootValue, StringComparison.CurrentCultureIgnoreCase))
				{
					pathValues[i] = pathValues[i].Replace(prefix, systemRootName);
					continue;
				}
				// 否则，规整大小写
				prefix = pathValues[i].Substring(0, systemRootName.Length);
				if (prefix.Equals(systemRootName, StringComparison.CurrentCultureIgnoreCase) && !prefix.Equals(systemRootName))
				{
					pathValues[i] = pathValues[i].Replace(prefix, systemRootName);
				}
			}
			// 保存Path变量
			return VariableUtils.SavePath(pathValues);
		}

		/// <summary>
		/// 格式化Path变量（移除Path变量中，以反斜杠结尾的路径的末尾的反斜杠并把斜杠替换为反斜杠）
		/// </summary>
		/// <returns>是否操作成功</returns>
		public static bool FormatPathValue()
		{
			string[] pathValues = RegUtils.GetPathVariable(false);
			for (int i = 0; i < pathValues.Length; i++)
			{
				pathValues[i] = FilePathUtils.RemovePathEndBackslash(pathValues[i].Replace("/", "\\"));
			}
			return VariableUtils.SavePath(pathValues);
		}
	}
}