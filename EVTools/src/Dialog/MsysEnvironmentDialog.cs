using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Swsk33.EVTools.Model;
using Swsk33.EVTools.Util;

namespace Swsk33.EVTools.Dialog
{
	/// <summary>
	/// 用于配置启用的Msys2环境的窗口
	/// </summary>
	public partial class MsysEnvironmentDialog : Form
	{
		/// <summary>
		/// 唯一单例
		/// </summary>
		private static readonly MsysEnvironmentDialog Instance = new MsysEnvironmentDialog();

		/// <summary>
		/// 单例模式，私有化构造器
		/// </summary>
		private MsysEnvironmentDialog()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 获取该窗口对象唯一单例
		/// </summary>
		/// <returns>MsysEnvironmentDialog唯一单例</returns>
		public static MsysEnvironmentDialog GetInstance()
		{
			return Instance;
		}

		/// <summary>
		/// 根据MsysUtils记录的环境对象列表，设定视图
		/// </summary>
		private void SetEnvironmentList()
		{
			// 获取排序后列表
			List<MsysEnvironment> environmentList = MsysUtils.GetSortedEnvironmentList(false);
			// 先清空视图
			msysEnvList.Items.Clear();
			// 遍历列表对象并显示到视图
			foreach (MsysEnvironment item in environmentList)
			{
				// 创建行
				ListViewItem row = new ListViewItem();
				// 每一行的列
				row.SubItems.Add(new ListViewItem.ListViewSubItem { Text = item.Name });
				row.Checked = item.Enabled;
				// 加入行
				msysEnvList.Items.Add(row);
			}
		}

		/// <summary>
		/// 将视图中的列表信息保存至MsysUtils中的环境对象列表中去
		/// </summary>
		private void SaveEnvironmentList()
		{
			// 遍历列表元素
			var viewList = msysEnvList.Items;
			for (int i = 0; i < viewList.Count; i++)
			{
				// 获取每个列表项对应的名称
				ListViewItem listItem = viewList[i];
				string name = listItem.SubItems[1].Text;
				// 修改环境对象Map中的值
				MsysEnvironment environment = MsysUtils.MsysEnvironmentMap[name];
				environment.Enabled = listItem.Checked;
				environment.Order = i;
			}
		}

		/// <summary>
		/// 窗口初始化方法
		/// </summary>
		private void MsysEnvironmentDialog_Load(object sender, EventArgs e)
		{
			SetEnvironmentList();
		}

		/// <summary>
		/// 确定保存按钮
		/// </summary>
		private void ok_Click(object sender, EventArgs e)
		{
			// 检查是否全部环境都未启用
			bool containsEnabled = false;
			foreach (ListViewItem item in msysEnvList.Items)
			{
				if (item.Checked)
				{
					containsEnabled = true;
					break;
				}
			}

			// 如果没有一个环境被启用，则提示错误
			if (!containsEnabled)
			{
				MessageBox.Show(@"至少需要启用一个环境！", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			SaveEnvironmentList();
			Close();
		}

		/// <summary>
		/// 上移选项
		/// </summary>
		private void up_Click(object sender, EventArgs e)
		{
			var selectedItems = msysEnvList.SelectedItems;
			if (selectedItems.Count > 0)
			{
				var item = selectedItems[0];
				if (item.Index > 0)
				{
					int index = item.Index;
					msysEnvList.Items.RemoveAt(index);
					msysEnvList.Items.Insert(index - 1, item);
				}

				msysEnvList.FocusedItem = item;
				msysEnvList.Select();
			}
		}

		/// <summary>
		/// 下移选项
		/// </summary>
		private void down_Click(object sender, EventArgs e)
		{
			var selectedItems = msysEnvList.SelectedItems;
			if (selectedItems.Count > 0)
			{
				var item = selectedItems[0];
				if (item.Index < msysEnvList.Items.Count - 1)
				{
					int index = item.Index;
					msysEnvList.Items.RemoveAt(index);
					msysEnvList.Items.Insert(index + 1, item);
				}

				msysEnvList.FocusedItem = item;
				msysEnvList.Select();
			}
		}
	}
}