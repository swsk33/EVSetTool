using System.Collections.Generic;

namespace Swsk33.EVTools.Strategy
{
	/// <summary>
	/// 用于不同的JDK程序的检测策略抽象接口
	/// </summary>
	public interface IJdkDetectStrategy
	{
		/// <summary>
		/// 检测JDK路径
		/// </summary>
		/// <returns>字典，键为带版本号的JDK名称，值为JDK安装路径</returns>
		Dictionary<string, string> DetectJdkPath();
	}
}