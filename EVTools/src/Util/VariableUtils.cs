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
		/// 设定环境变量
		/// </summary>
		/// <param name="varName">设定变量名</param>
		/// <param name="value">变量值</param>
		public static void SetSystemVariable(string varName, string value)
		{
			Environment.SetEnvironmentVariable(varName, FilePathUtils.RemovePathEndBackslash(value), EnvironmentVariableTarget.Machine);
		}

		/// <summary>
		/// 把一个数组保存为环境变量Path的值
		/// </summary>
		/// <param name="pathValues">给定数组</param>
		/// <returns>是否保存成功</returns>
		public static bool SavePath(string[] pathValues)
		{
			string saveTotalValue = string.Join(";", pathValues) + ";";
			SetSystemVariable("Path", saveTotalValue);
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