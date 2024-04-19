using Swsk33.EVTools.Util;
using System.Threading;
using System.Windows.Forms;

namespace Swsk33.EVTools.Dialog
{
	public partial class PathCleanDialog : Form
	{
		public PathCleanDialog()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 操纵所有按钮
		/// </summary>
		/// <param name="enable">如果传入true则将所有按钮设置为可用状态，否则把所有按钮禁用</param>
		private void operateAllButtons(bool enable)
		{
			replaceSystemRoot.Enabled = enable;
			formatPathValue.Enabled = enable;
			removeDuplicate.Enabled = enable;
			removeNotExist.Enabled = enable;
			processTipLabel.Visible = !enable;
		}

		private void UtilitiesDialog_Load(object sender, System.EventArgs e)
		{
			buttonToolTip.SetToolTip(replaceSystemRoot, "点击以将Path环境变量中的C:\\WINDOWS替换为%SystemRoot%的引用形式");
			buttonToolTip.SetToolTip(formatPathValue, "点击以将Path环境变量中以反斜杠(\\)结尾的路径的末尾反斜杠去除，如果有路径以斜杠(/)表示目录分隔符，那么也会被替换为反斜杠");
			buttonToolTip.SetToolTip(removeDuplicate, "点击以将Path环境变量中重复值去除，与此同时也会格式化路径");
			buttonToolTip.SetToolTip(removeNotExist, "点击以将Path环境变量中不存在的路径移除");
		}

		/// <summary>
		/// 替换系统引用按钮
		/// </summary>
		private void replaceSystemRoot_Click(object sender, System.EventArgs e)
		{
			operateAllButtons(false);
			new Thread(() =>
			{
				if (VariableUtils.SavePath(PathValuesUtils.ReplacePathSystemRootReference()))
				{
					MessageBox.Show(@"操作成功！", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(@"操作失败！请退出程序后重新右键-以管理员身份运行此程序再试！", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				operateAllButtons(true);
			}).Start();
		}

		/// <summary>
		/// 格式化Path变量按钮
		/// </summary>
		private void formatPathValue_Click(object sender, System.EventArgs e)
		{
			operateAllButtons(false);
			new Thread(() =>
			{
				if (VariableUtils.SavePath(PathValuesUtils.GetFormattedPathValues(false)))
				{
					MessageBox.Show(@"操作成功！", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(@"操作失败！请退出程序后重新右键-以管理员身份运行此程序再试！", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				operateAllButtons(true);
			}).Start();
		}

		/// <summary>
		/// 移除Path重复值按钮
		/// </summary>
		private void removeDuplicate_Click(object sender, System.EventArgs e)
		{
			operateAllButtons(false);
			new Thread(() =>
			{
				if (VariableUtils.SavePath(PathValuesUtils.RemoveDuplicateValueInPathAndFormat()))
				{
					MessageBox.Show(@"操作成功！", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(@"操作失败！请退出程序后重新右键-以管理员身份运行此程序再试！", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				operateAllButtons(true);
			}).Start();
		}

		/// <summary>
		/// 移除不存在的路径按钮
		/// </summary>
		private void removeNotExist_Click(object sender, System.EventArgs e)
		{
			operateAllButtons(false);
			new Thread(() =>
			{
				if (VariableUtils.SavePath(PathValuesUtils.RemoveNotExistPathInPathValues()))
				{
					MessageBox.Show(@"操作成功！", @"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(@"操作失败！请退出程序后重新右键-以管理员身份运行此程序再试！", @"失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				operateAllButtons(true);
			}).Start();
		}
	}
}