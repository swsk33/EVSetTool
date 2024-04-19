using System.Collections.Generic;
using Swsk33.EVTools.Strategy.Impl;

namespace Swsk33.EVTools.Strategy.Context
{
	/// <summary>
	/// 调用JDK检测策略的上下文
	/// </summary>
	public static class JdkDetectContext
	{
		/// <summary>
		/// 存放全部JDK检测策略的集合
		/// </summary>
		private static readonly HashSet<IJdkDetectStrategy> allStrategySet;

		static JdkDetectContext()
		{
			// 初始化策略集合
			allStrategySet = new HashSet<IJdkDetectStrategy>
			{
				new OracleJdkDetectStrategy(),
				new MicrosoftJdkDetectStrategy(),
				new AdoptJdkDetectStrategy(),
				new ZuluJdkDetectStrategy(),
				new LibericaJdkDetectStrategy()
			};
		}

		/// <summary>
		/// 调用全部JDK检测策略
		/// </summary>
		/// <returns>存放JDK名称和路径的键值对</returns>
		public static Dictionary<string, string> DetectAllJdk()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			foreach (IJdkDetectStrategy strategy in allStrategySet)
			{
				Dictionary<string, string> current = strategy.DetectJdkPath();
				foreach (string name in current.Keys)
				{
					result.Add(name, current[name]);
				}
			}

			return result;
		}
	}
}