using Swsk33.EVTools.Dialog;
using Swsk33.ReadAndWriteSharp.Network;
using System;
using System.Threading;

namespace Swsk33.EVTools.Util
{
	/// <summary>
	/// 用于检查更新的实用类
	/// </summary>
	public class CheckUpdateUtils
	{
		/// <summary>
		/// 应用程序版本
		/// </summary>
		public static readonly string VERSION = "5.0.0";

		/// <summary>
		/// 获取版本号的网址
		/// </summary>
		public static readonly string CHECK_URL = "https://gitee.com/swsk33/EVSetTool/raw/master/Version";

		/// <summary>
		/// 程序下载地址
		/// </summary>
		public static readonly string DOWNLOAD_URL = "https://gitee.com/swsk33/EVSetTool/releases";

		/// <summary>
		/// 发送网络请求获取版本号检查自己是否最新，若不是则会弹出提示框，这是个异步方法
		/// </summary>
		public static void CheckUpdate()
		{
			new Thread(() =>
			{
				// 发请求
				string getVersion;
				try
				{
					getVersion = NetworkUtils.SendGetRequest(CHECK_URL);
					// 若版本对不上则弹出更新提示
					if (!getVersion.Equals(VERSION))
					{
						new UpdateDialog().ShowDialog();
					}
				}
				catch (Exception)
				{
					// 什么都不做
				}
			}).Start();
		}
	}
}