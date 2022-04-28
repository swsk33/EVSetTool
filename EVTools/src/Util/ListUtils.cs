using System;
using System.Collections.Generic;

namespace Swsk33.EVTools.Util
{
	/// <summary>
	/// 列表实用类
	/// </summary>
	public class ListUtils
	{
		/// <summary>
		/// 判断一个字符串元素是否在一个字符串列表中，判断时忽略大小写
		/// </summary>
		/// <param name="stringList">字符串列表</param>
		/// <param name="element">给定字符串</param>
		/// <returns>给定字符串是否存在于字符串列表中，即使大小写不同但是内容相同也算</returns>
		public static bool ListContainsIgnoreCase(List<string> stringList, string element)
		{
			foreach (string item in stringList)
			{
				if (element.Equals(item, StringComparison.CurrentCultureIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 批量从列表中移除一些项
		/// </summary>
		/// <param name="origin">待批量移除项目的列表</param>
		/// <param name="removeStrings">被移除的条目</param>
		public static void BatchRemoveFromList(List<string> origin, List<string> removeStrings)
		{
			foreach (string item in removeStrings)
			{
				for (int i = 0; i < origin.Count; i++)
				{
					if (origin[i].Equals(item, StringComparison.CurrentCultureIgnoreCase))
					{
						origin.RemoveAt(i);
						i--;
					}
				}
			}
		}
	}
}