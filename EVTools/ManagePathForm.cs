using Microsoft.Win32;
using System.Windows.Forms;

namespace EVTools
{
	public partial class ManagePathForm : Form
	{
		public ManagePathForm()
		{
			InitializeComponent();
		}

		private void ManagePathForm_Load(object sender, System.EventArgs e)
		{
			RegistryKey EVKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment");
			string pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
			EVKey.Close();
			if (pathValue.EndsWith(";"))
			{
				pathValue = pathValue.Substring(0, pathValue.Length - 1);
			}
			string[] pathValues = pathValue.Split(';');
			foreach (string value in pathValues)
			{
				pathContentValue.Items.Add(value);
			}
		}

		private void cancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void up_Click(object sender, System.EventArgs e)
		{
			int index = pathContentValue.SelectedIndex;
			if (index > 0)
			{
				string currentContent = pathContentValue.SelectedItem.ToString();
				pathContentValue.Items.RemoveAt(index);
				pathContentValue.Items.Insert(index - 1, currentContent);
				pathContentValue.SelectedIndex = index - 1;
			}
		}

		private void down_Click(object sender, System.EventArgs e)
		{
			int index = pathContentValue.SelectedIndex;
			if (index >= 0 && index < pathContentValue.Items.Count - 1)
			{
				string currentContent = pathContentValue.SelectedItem.ToString();
				pathContentValue.Items.RemoveAt(index);
				pathContentValue.Items.Insert(index + 1, currentContent);
				pathContentValue.SelectedIndex = index + 1;
			}
		}

		private void remove_Click(object sender, System.EventArgs e)
		{
			if (pathContentValue.SelectedIndex >= 0)
			{
				pathContentValue.Items.RemoveAt(pathContentValue.SelectedIndex);
			}
		}

		private void add_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择路径";
			dialog.ShowDialog();
			string path = dialog.SelectedPath;
			if (pathContentValue.SelectedIndex >= 0)
			{
				pathContentValue.Items.Insert(pathContentValue.SelectedIndex + 1, path);
			}
			else
			{
				pathContentValue.Items.Add(path);
			}
		}

		private void edit_Click(object sender, System.EventArgs e)
		{

		}
	}
}
