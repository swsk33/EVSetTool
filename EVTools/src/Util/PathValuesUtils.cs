using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace Swsk33.EVTools.Util
{
	/// <summary>
	/// 用于对Path环境变量中的值进行常见处理的实用类
	/// </summary>
	public static class PathValuesUtils
	{
		/// <summary>
		/// 获取环境变量Path中的变量形式
		/// </summary>
		/// <returns>一个字典，字典的键是Path中变量形式的值（例如%JAVA_HOME%\bin），其值则为这个变量的值（例如C:\Program Files\Zulu\zulu-17\bin），所有值都经过了格式化</returns>
		private static Dictionary<string, string> GetVariablesInPath()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			// 先获取展开值后的环境变量Path
			string[] valuesExpanded = GetFormattedPathValues(true);
			// 再获取没有展开值的环境变量Path
			string[] valuesNotExpanded = GetFormattedPathValues(false);
			// 进行对比，不一样的则为变量形式
			for (int i = 0; i < valuesExpanded.Length; i++)
			{
				if (!valuesNotExpanded[i].Equals(valuesExpanded[i]) && !result.ContainsKey(valuesNotExpanded[i]))
				{
					result.Add(valuesNotExpanded[i], valuesExpanded[i]);
				}
			}

			return result;
		}

		/// <summary>
		/// 返回格式化后的Path变量的副本（将斜杠换成反斜杠并去掉末尾的反斜杠）
		/// </summary>
		/// <param name="expand">是否展开其中的变量引用</param>
		/// <returns>格式化后的Path变量列表</returns>
		public static string[] GetFormattedPathValues(bool expand)
		{
			string[] pathValues = RegUtils.GetPathVariable(expand);
			for (int i = 0; i < pathValues.Length; i++)
			{
				pathValues[i] = FilePathUtils.RemovePathEndBackslash(pathValues[i].Replace("/", "\\"));
			}

			return pathValues;
		}

		/// <summary>
		/// 把Path变量中的C:\Windows替换为%SystemRoot%的引用形式
		/// </summary>
		/// <returns>返回已经替换成系统引用后的Path变量副本</returns>
		public static string[] ReplacePathSystemRootReference()
		{
			string systemRootValue = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
			string systemRootName = "%SystemRoot%";
			string[] pathValues = RegUtils.GetPathVariable(false);
			for (int i = 0; i < pathValues.Length; i++)
			{
				string prefix;
				// 检测路径是否是C:\Windows打头
				if (pathValues[i].Length >= systemRootValue.Length)
				{
					prefix = pathValues[i].Substring(0, systemRootValue.Length);
					if (prefix.Equals(systemRootValue, StringComparison.CurrentCultureIgnoreCase))
					{
						pathValues[i] = pathValues[i].Replace(prefix, systemRootName);
						continue;
					}
				}

				// 否则，规整大小写
				if (pathValues[i].Length >= systemRootName.Length)
				{
					prefix = pathValues[i].Substring(0, systemRootName.Length);
					if (prefix.Equals(systemRootName, StringComparison.CurrentCultureIgnoreCase) && !prefix.Equals(systemRootName))
					{
						pathValues[i] = pathValues[i].Replace(prefix, systemRootName);
					}
				}
			}

			return pathValues;
		}

		/// <summary>
		/// Path值去重并格式化
		/// <para>下列情况视为重复：</para>
		/// <list type="bullet">Path中有两个一模一样的值</list>
		/// <list type="bullet">Path中同时存在两个实质相同的路径，但是大小写不一样，例如"C:\abc"和"C:\Abc"，两者重复</list>
		/// <list type="bullet">Path中同时存在一个路径和一个路径带末尾斜杠，例如"C:\a"和"C:\a\"，两者视为重复，保留前者（即使大小写不同）</list>
		/// <list type="bullet">Path中同时存在一个变量形式路径和这个变量的值，例如"%JAVA_HOME%\bin"和"C:\Program Files\Zulu\zulu-17"或者"%JAVA_HOME%\bin\"和"C:\Program Files\Zulu\zulu-17"或者"%JAVA_HOME%\bin"和"C:\Program Files\Zulu\zulu-17\"，两者重复，保留变量（不以反斜杠结尾的）</list>
		/// <list type="bullet">Path中有两个实质相同的路径，但是斜杠不一样，例如C:\a\b和C:/a/b，两者视为重复，保留前者（即使大小写不同）</list>
		/// </summary>
		/// <returns>去重并格式化后的Path环境变量，数组形式</returns>
		public static string[] RemoveDuplicateValueInPathAndFormat()
		{
			// 用于存放结果的数组
			List<string> result = new List<string>();
			// 获取格式化后的Path变量值
			string[] origin = GetFormattedPathValues(false);
			// 第一遍检查是否有重复值，筛查一遍并将结果放进结果数组
			foreach (string originValue in origin)
			{
				// 检查结果列表中是否存在当前遍历的路径值
				if (!ListUtils.ListContainsIgnoreCase(result, originValue))
				{
					result.Add(originValue);
				}
			}

			// 第二遍检查是否同时存在一个变量形式路径和这个变量的值
			// 获取Path中变量形式值
			Dictionary<string, string> variables = GetVariablesInPath();
			// 遍历Path中变量形式的路径及其对应的实际值
			foreach (string key in variables.Keys)
			{
				for (int i = 0; i < result.Count; i++)
				{
					if (variables[key].Equals(result[i], StringComparison.CurrentCultureIgnoreCase))
					{
						result.RemoveAt(i);
						i--;
					}
				}
			}

			return result.ToArray();
		}

		/// <summary>
		/// 从Path环境变量中移除不存在的路径
		/// </summary>
		/// <returns>返回移除了不存在的路径后的Path变量</returns>
		public static string[] RemoveNotExistPathInPathValues()
		{
			List<string> result = new List<string>(RegUtils.GetPathVariable(false));
			Dictionary<string, string> variables = GetVariablesInPath();
			for (int i = 0; i < result.Count; i++)
			{
				string eachPath;
				// 如果这个值中包含%，说明是变量引用形式，获取其实际值
				if (result[i].Contains("%"))
				{
					eachPath = FilePathUtils.RemovePathEndBackslash(result[i].Replace("/", "\\"));
					// 变量列表中不存在该值，说明这个值是不存在的路径
					if (!variables.ContainsKey(eachPath))
					{
						result.RemoveAt(i);
						i--;
						continue;
					}

					// 否则，进一步展开变量，并检测其对应路径是否存在
					eachPath = FilePathUtils.RemovePathEndBackslash(variables[eachPath].Replace("/", "\\"));
					if (!Directory.Exists(eachPath) && !File.Exists(eachPath))
					{
						result.RemoveAt(i);
						i--;
					}
				}
				else
				{
					// 否则就是普通路径，检测是否存在即可
					eachPath = FilePathUtils.RemovePathEndBackslash(result[i].Replace("/", "\\"));
					if (!Directory.Exists(eachPath) && !File.Exists(eachPath))
					{
						result.RemoveAt(i);
						i--;
					}
				}
			}

			return result.ToArray();
		}
	}
}