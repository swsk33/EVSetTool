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
	}
}