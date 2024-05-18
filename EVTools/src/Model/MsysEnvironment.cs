using System;

namespace Swsk33.EVTools.Model
{
	/// <summary>
	/// 表示Msys2环境实体类
	/// </summary>
	public class MsysEnvironment
	{
		private String name;

		private String path;

		private bool enabled;

		private int order;

		/// <summary>
		/// 环境名称
		/// </summary>
		public string Name
		{
			get => name;
			set => name = value;
		}

		/// <summary>
		/// 环境相对路径
		/// </summary>
		public string Path
		{
			get => path;
			set => path = value;
		}

		/// <summary>
		/// 是否将该环境路径加入到Path环境变量
		/// </summary>
		public bool Enabled
		{
			get => enabled;
			set => enabled = value;
		}

		/// <summary>
		/// 该环境在所有环境列表中顺序，数字越小优先级越高（位于Path中最前面），从0开始
		/// </summary>
		public int Order
		{
			get => order;
			set => order = value;
		}

		/// <summary>
		/// 带参构造函数
		/// </summary>
		public MsysEnvironment(string name, string path, bool enabled, int order)
		{
			this.name = name;
			this.path = path;
			this.enabled = enabled;
			this.order = order;
		}
	}
}