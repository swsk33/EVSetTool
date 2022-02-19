using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Swsk33.EVTools.Util
{
	/// <summary>
	/// 用于环境变量的实用类
	/// </summary>
	public class VariableUtils
	{
		/// <summary>
		/// 运行setx命令设定环境变量
		/// </summary>
		/// <param name="varName">设定变量名</param>
		/// <param name="value">变量值</param>
		/// <param name="isSysVar">是否是系统变量</param>
		public static void RunSetx(string varName, string value, bool isSysVar)
		{
			List<string> args = new List<string>();
			if (isSysVar)
			{
				args.Add("/m");
			}
			args.Add(varName);
			value = FilePathUtils.RemovePathEndBackslash(value);
			args.Add(value);
			TerminalUtils.RunCommand("setx", args.ToArray());
		}

		/// <summary>
		/// 获取环境变量Path中的变量形式
		/// </summary>
		/// <returns>一个字典，字典的键是Path中变量形式的值（例如%JAVA_HOME%\bin），其值则为这个变量的值（例如C:\Program Files\Zulu\zulu-17）</returns>
		public static Dictionary<string, string> GetVariablesInPath()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			// 先获取展开值后的环境变量Path，并把里面的斜杠换成反斜杠，并将以反斜杠结尾的部分去除
			string[] valuesExpanded = RegUtils.GetPathVariable(true);
			for (int i = 0; i < valuesExpanded.Length; i++)
			{
				valuesExpanded[i] = FilePathUtils.RemovePathEndBackslash(valuesExpanded[i].Replace("/", "\\"));
			}
			// 再获取没有展开值的环境变量Path，并把里面的斜杠换成反斜杠，并将以反斜杠结尾的部分去除
			string[] valuesNotExpanded = RegUtils.GetPathVariable(false);
			for (int i = 0; i < valuesNotExpanded.Length; i++)
			{
				valuesNotExpanded[i] = FilePathUtils.RemovePathEndBackslash(valuesNotExpanded[i].Replace("/", "\\"));
			}
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
		/// Path值去重
		/// <para>下列情况视为重复：</para>
		/// <list type="bullet">Path中有两个一模一样的值</list>
		/// <list type="bullet">Path中同时存在两个实质相同的路径，但是大小写不一样，例如"C:\abc"和"C:\Abc"，两者重复</list>
		/// <list type="bullet">Path中同时存在一个路径和一个路径带末尾斜杠，例如"C:\a"和"C:\a\"，两者视为重复，保留前者（即使大小写不同）</list>
		/// <list type="bullet">Path中同时存在一个变量形式路径和这个变量的值，例如"%JAVA_HOME%\bin"和"C:\Program Files\Zulu\zulu-17"或者"%JAVA_HOME%\bin\"和"C:\Program Files\Zulu\zulu-17"或者"%JAVA_HOME%\bin"和"C:\Program Files\Zulu\zulu-17\"，两者重复，保留变量（不以反斜杠结尾的）</list>
		/// <list type="bullet">Path中有两个实质相同的路径，但是斜杠不一样，例如C:\a\b和C:/a/b，两者视为重复，保留前者（即使大小写不同）</list>
		/// </summary>
		/// <returns>去重后的Path环境变量，数组形式</returns>
		public static string[] RemoveRedundantValueInPath()
		{
			// 用于存放结果的数组
			List<string> result = new List<string>();
			// 获取Path变量值
			string[] origin = RegUtils.GetPathVariable(false);
			// 把Path变量中的值存在的斜杠全部换成反斜杠，并去除末尾反斜杠（如果有反斜杠结尾的变量的话）
			for (int i = 0; i < origin.Length; i++)
			{
				origin[i] = FilePathUtils.RemovePathEndBackslash(origin[i].Replace("/", "\\"));
			}
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
		/// 把一个数组保存为环境变量Path的值
		/// </summary>
		/// <param name="pathValues">给定数组</param>
		/// <returns>是否保存成功</returns>
		public static bool SavePath(string[] pathValues)
		{
			string saveTotalValue = string.Join(";", pathValues) + ";";
			RunSetx("Path", saveTotalValue, true);
			if (saveTotalValue.Equals(string.Join(";", RegUtils.GetPathVariable(false)) + ";"))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// 把指定值加入到Path环境变量中去
		/// </summary>
		/// <param name="value">指定值（末尾如果有分号或者反斜杠会被去除）</param>
		/// <param name="append">为true时将值追加到Path变量之后，否则插入到最前</param>
		public static void AddValueToPath(string value, bool append)
		{
			// 先获取Path变量值
			List<string> originValues = new List<string>(RegUtils.GetPathVariable(false));
			// 处理传入值
			value = FilePathUtils.RemovePathEndBackslash(value.Replace("/", "\\"));
			// 检查重复
			if (ListUtils.ListContainsIgnoreCase(originValues, value))
			{
				MessageBox.Show("该路径已经存在于Path变量中！无需再次添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			// 开始加入
			if (append)
			{
				originValues.Add(value);
			}
			else
			{
				originValues.Insert(0, value);
			}
			// 保存Path变量值
			if (SavePath(originValues.ToArray()))
			{
				MessageBox.Show("已成功添加路径至Path变量！若没有立即生效，请关闭现有已打开终端或者重启电脑再试！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("添加路径到Path变量失败！请关闭该程序然后右键-以管理员身份运行该程序再试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}