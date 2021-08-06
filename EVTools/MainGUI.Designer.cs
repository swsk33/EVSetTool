
namespace EVTools
{
    partial class MainGUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
			this.jdkAutoSetLabel = new System.Windows.Forms.Label();
			this.jdkAutoSetOption = new System.Windows.Forms.RadioButton();
			this.jdkAutoSetValue = new System.Windows.Forms.ComboBox();
			this.jdkManualSetOption = new System.Windows.Forms.RadioButton();
			this.jdkManualSetValue = new System.Windows.Forms.TextBox();
			this.jdkManualSetButton = new System.Windows.Forms.Button();
			this.JDKok = new System.Windows.Forms.Button();
			this.mainTabPane = new System.Windows.Forms.TabControl();
			this.jdkSetTab = new System.Windows.Forms.TabPage();
			this.jdkSettingTip = new System.Windows.Forms.Label();
			this.jdkRecheck = new System.Windows.Forms.Button();
			this.jdkNotFoundTip = new System.Windows.Forms.Label();
			this.pythonTab = new System.Windows.Forms.TabPage();
			this.pyAutoSetValue = new System.Windows.Forms.ComboBox();
			this.pyRecheck = new System.Windows.Forms.Button();
			this.pySettingTip = new System.Windows.Forms.Label();
			this.pyAutoSetOption = new System.Windows.Forms.RadioButton();
			this.pyOk = new System.Windows.Forms.Button();
			this.pyNotFoundTip = new System.Windows.Forms.Label();
			this.pyAutoSetLabel = new System.Windows.Forms.Label();
			this.pyManualSetButton = new System.Windows.Forms.Button();
			this.pyManualSetOption = new System.Windows.Forms.RadioButton();
			this.pyManualSetValue = new System.Windows.Forms.TextBox();
			this.other = new System.Windows.Forms.TabPage();
			this.managePath = new System.Windows.Forms.Button();
			this.isAppend = new System.Windows.Forms.CheckBox();
			this.otherSettingTip = new System.Windows.Forms.Label();
			this.otherSetTip = new System.Windows.Forms.Label();
			this.otherOK = new System.Windows.Forms.Button();
			this.otherSetButton = new System.Windows.Forms.Button();
			this.otherSetValue = new System.Windows.Forms.TextBox();
			this.appendToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.mainTabPane.SuspendLayout();
			this.jdkSetTab.SuspendLayout();
			this.pythonTab.SuspendLayout();
			this.other.SuspendLayout();
			this.SuspendLayout();
			// 
			// jdkAutoSetLabel
			// 
			this.jdkAutoSetLabel.AutoSize = true;
			this.jdkAutoSetLabel.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.jdkAutoSetLabel.Location = new System.Drawing.Point(47, 77);
			this.jdkAutoSetLabel.Name = "jdkAutoSetLabel";
			this.jdkAutoSetLabel.Size = new System.Drawing.Size(91, 14);
			this.jdkAutoSetLabel.TabIndex = 0;
			this.jdkAutoSetLabel.Text = "已搜寻版本：";
			// 
			// jdkAutoSetOption
			// 
			this.jdkAutoSetOption.AutoSize = true;
			this.jdkAutoSetOption.Checked = true;
			this.jdkAutoSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.jdkAutoSetOption.Location = new System.Drawing.Point(30, 42);
			this.jdkAutoSetOption.Name = "jdkAutoSetOption";
			this.jdkAutoSetOption.Size = new System.Drawing.Size(172, 18);
			this.jdkAutoSetOption.TabIndex = 1;
			this.jdkAutoSetOption.TabStop = true;
			this.jdkAutoSetOption.Text = "自动搜寻jdk并一键设定";
			this.jdkAutoSetOption.UseVisualStyleBackColor = true;
			this.jdkAutoSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
			// 
			// jdkAutoSetValue
			// 
			this.jdkAutoSetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.jdkAutoSetValue.FormattingEnabled = true;
			this.jdkAutoSetValue.Location = new System.Drawing.Point(133, 75);
			this.jdkAutoSetValue.Name = "jdkAutoSetValue";
			this.jdkAutoSetValue.Size = new System.Drawing.Size(212, 20);
			this.jdkAutoSetValue.TabIndex = 2;
			// 
			// jdkManualSetOption
			// 
			this.jdkManualSetOption.AutoSize = true;
			this.jdkManualSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.jdkManualSetOption.Location = new System.Drawing.Point(30, 112);
			this.jdkManualSetOption.Name = "jdkManualSetOption";
			this.jdkManualSetOption.Size = new System.Drawing.Size(158, 18);
			this.jdkManualSetOption.TabIndex = 1;
			this.jdkManualSetOption.Text = "手动指定jdk所在位置\r\n";
			this.jdkManualSetOption.UseVisualStyleBackColor = true;
			this.jdkManualSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
			// 
			// jdkManualSetValue
			// 
			this.jdkManualSetValue.Enabled = false;
			this.jdkManualSetValue.Location = new System.Drawing.Point(50, 147);
			this.jdkManualSetValue.Name = "jdkManualSetValue";
			this.jdkManualSetValue.Size = new System.Drawing.Size(215, 21);
			this.jdkManualSetValue.TabIndex = 3;
			// 
			// jdkManualSetButton
			// 
			this.jdkManualSetButton.Enabled = false;
			this.jdkManualSetButton.Location = new System.Drawing.Point(270, 146);
			this.jdkManualSetButton.Name = "jdkManualSetButton";
			this.jdkManualSetButton.Size = new System.Drawing.Size(75, 23);
			this.jdkManualSetButton.TabIndex = 4;
			this.jdkManualSetButton.Text = "浏览";
			this.jdkManualSetButton.UseVisualStyleBackColor = true;
			this.jdkManualSetButton.Click += new System.EventHandler(this.jdkManualSetButton_Click);
			// 
			// JDKok
			// 
			this.JDKok.Location = new System.Drawing.Point(151, 182);
			this.JDKok.Name = "JDKok";
			this.JDKok.Size = new System.Drawing.Size(75, 23);
			this.JDKok.TabIndex = 4;
			this.JDKok.Text = "设定";
			this.JDKok.UseVisualStyleBackColor = true;
			this.JDKok.Click += new System.EventHandler(this.JDKok_Click);
			// 
			// mainTabPane
			// 
			this.mainTabPane.Controls.Add(this.jdkSetTab);
			this.mainTabPane.Controls.Add(this.pythonTab);
			this.mainTabPane.Controls.Add(this.other);
			this.mainTabPane.Dock = System.Windows.Forms.DockStyle.Top;
			this.mainTabPane.Location = new System.Drawing.Point(0, 0);
			this.mainTabPane.Name = "mainTabPane";
			this.mainTabPane.SelectedIndex = 0;
			this.mainTabPane.Size = new System.Drawing.Size(381, 256);
			this.mainTabPane.TabIndex = 5;
			// 
			// jdkSetTab
			// 
			this.jdkSetTab.Controls.Add(this.jdkSettingTip);
			this.jdkSetTab.Controls.Add(this.jdkRecheck);
			this.jdkSetTab.Controls.Add(this.jdkAutoSetValue);
			this.jdkSetTab.Controls.Add(this.jdkAutoSetOption);
			this.jdkSetTab.Controls.Add(this.JDKok);
			this.jdkSetTab.Controls.Add(this.jdkNotFoundTip);
			this.jdkSetTab.Controls.Add(this.jdkAutoSetLabel);
			this.jdkSetTab.Controls.Add(this.jdkManualSetButton);
			this.jdkSetTab.Controls.Add(this.jdkManualSetOption);
			this.jdkSetTab.Controls.Add(this.jdkManualSetValue);
			this.jdkSetTab.Location = new System.Drawing.Point(4, 22);
			this.jdkSetTab.Name = "jdkSetTab";
			this.jdkSetTab.Padding = new System.Windows.Forms.Padding(3);
			this.jdkSetTab.Size = new System.Drawing.Size(373, 230);
			this.jdkSetTab.TabIndex = 0;
			this.jdkSetTab.Text = "jdk环境变量设置";
			this.jdkSetTab.UseVisualStyleBackColor = true;
			// 
			// jdkSettingTip
			// 
			this.jdkSettingTip.AutoSize = true;
			this.jdkSettingTip.ForeColor = System.Drawing.Color.Blue;
			this.jdkSettingTip.Location = new System.Drawing.Point(5, 214);
			this.jdkSettingTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.jdkSettingTip.Name = "jdkSettingTip";
			this.jdkSettingTip.Size = new System.Drawing.Size(137, 12);
			this.jdkSettingTip.TabIndex = 5;
			this.jdkSettingTip.Text = "正在设定jdk环境变量...";
			this.jdkSettingTip.Visible = false;
			// 
			// jdkRecheck
			// 
			this.jdkRecheck.Location = new System.Drawing.Point(292, 6);
			this.jdkRecheck.Name = "jdkRecheck";
			this.jdkRecheck.Size = new System.Drawing.Size(75, 23);
			this.jdkRecheck.TabIndex = 4;
			this.jdkRecheck.Text = "重新检测";
			this.jdkRecheck.UseVisualStyleBackColor = true;
			this.jdkRecheck.Visible = false;
			this.jdkRecheck.Click += new System.EventHandler(this.jdkRecheck_Click);
			// 
			// jdkNotFoundTip
			// 
			this.jdkNotFoundTip.AutoSize = true;
			this.jdkNotFoundTip.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.jdkNotFoundTip.ForeColor = System.Drawing.Color.Red;
			this.jdkNotFoundTip.Location = new System.Drawing.Point(7, 9);
			this.jdkNotFoundTip.Name = "jdkNotFoundTip";
			this.jdkNotFoundTip.Size = new System.Drawing.Size(252, 14);
			this.jdkNotFoundTip.TabIndex = 0;
			this.jdkNotFoundTip.Text = "找不到此电脑安装了jdk，请手动指定！";
			this.jdkNotFoundTip.Visible = false;
			// 
			// pythonTab
			// 
			this.pythonTab.Controls.Add(this.pyAutoSetValue);
			this.pythonTab.Controls.Add(this.pyRecheck);
			this.pythonTab.Controls.Add(this.pySettingTip);
			this.pythonTab.Controls.Add(this.pyAutoSetOption);
			this.pythonTab.Controls.Add(this.pyOk);
			this.pythonTab.Controls.Add(this.pyNotFoundTip);
			this.pythonTab.Controls.Add(this.pyAutoSetLabel);
			this.pythonTab.Controls.Add(this.pyManualSetButton);
			this.pythonTab.Controls.Add(this.pyManualSetOption);
			this.pythonTab.Controls.Add(this.pyManualSetValue);
			this.pythonTab.Location = new System.Drawing.Point(4, 22);
			this.pythonTab.Margin = new System.Windows.Forms.Padding(2);
			this.pythonTab.Name = "pythonTab";
			this.pythonTab.Size = new System.Drawing.Size(373, 230);
			this.pythonTab.TabIndex = 2;
			this.pythonTab.Text = "python环境变量设置";
			this.pythonTab.UseVisualStyleBackColor = true;
			// 
			// pyAutoSetValue
			// 
			this.pyAutoSetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.pyAutoSetValue.FormattingEnabled = true;
			this.pyAutoSetValue.Location = new System.Drawing.Point(133, 75);
			this.pyAutoSetValue.Name = "pyAutoSetValue";
			this.pyAutoSetValue.Size = new System.Drawing.Size(87, 20);
			this.pyAutoSetValue.TabIndex = 10;
			// 
			// pyRecheck
			// 
			this.pyRecheck.Location = new System.Drawing.Point(292, 5);
			this.pyRecheck.Name = "pyRecheck";
			this.pyRecheck.Size = new System.Drawing.Size(75, 23);
			this.pyRecheck.TabIndex = 12;
			this.pyRecheck.Text = "重新检测";
			this.pyRecheck.UseVisualStyleBackColor = true;
			this.pyRecheck.Visible = false;
			this.pyRecheck.Click += new System.EventHandler(this.pyRecheck_Click);
			// 
			// pySettingTip
			// 
			this.pySettingTip.AutoSize = true;
			this.pySettingTip.ForeColor = System.Drawing.Color.Blue;
			this.pySettingTip.Location = new System.Drawing.Point(5, 217);
			this.pySettingTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.pySettingTip.Name = "pySettingTip";
			this.pySettingTip.Size = new System.Drawing.Size(155, 12);
			this.pySettingTip.TabIndex = 15;
			this.pySettingTip.Text = "正在设定python环境变量...";
			this.pySettingTip.Visible = false;
			// 
			// pyAutoSetOption
			// 
			this.pyAutoSetOption.AutoSize = true;
			this.pyAutoSetOption.Checked = true;
			this.pyAutoSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pyAutoSetOption.Location = new System.Drawing.Point(30, 42);
			this.pyAutoSetOption.Name = "pyAutoSetOption";
			this.pyAutoSetOption.Size = new System.Drawing.Size(193, 18);
			this.pyAutoSetOption.TabIndex = 8;
			this.pyAutoSetOption.TabStop = true;
			this.pyAutoSetOption.Text = "自动搜寻python并一键设定";
			this.pyAutoSetOption.UseVisualStyleBackColor = true;
			this.pyAutoSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
			// 
			// pyOk
			// 
			this.pyOk.Location = new System.Drawing.Point(154, 182);
			this.pyOk.Name = "pyOk";
			this.pyOk.Size = new System.Drawing.Size(75, 23);
			this.pyOk.TabIndex = 13;
			this.pyOk.Text = "设定";
			this.pyOk.UseVisualStyleBackColor = true;
			this.pyOk.Click += new System.EventHandler(this.pyOk_Click);
			// 
			// pyNotFoundTip
			// 
			this.pyNotFoundTip.AutoSize = true;
			this.pyNotFoundTip.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pyNotFoundTip.ForeColor = System.Drawing.Color.Red;
			this.pyNotFoundTip.Location = new System.Drawing.Point(7, 9);
			this.pyNotFoundTip.Name = "pyNotFoundTip";
			this.pyNotFoundTip.Size = new System.Drawing.Size(273, 14);
			this.pyNotFoundTip.TabIndex = 6;
			this.pyNotFoundTip.Text = "找不到此电脑安装了python，请手动指定！";
			this.pyNotFoundTip.Visible = false;
			// 
			// pyAutoSetLabel
			// 
			this.pyAutoSetLabel.AutoSize = true;
			this.pyAutoSetLabel.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pyAutoSetLabel.Location = new System.Drawing.Point(47, 77);
			this.pyAutoSetLabel.Name = "pyAutoSetLabel";
			this.pyAutoSetLabel.Size = new System.Drawing.Size(91, 14);
			this.pyAutoSetLabel.TabIndex = 7;
			this.pyAutoSetLabel.Text = "已搜寻版本：";
			// 
			// pyManualSetButton
			// 
			this.pyManualSetButton.Enabled = false;
			this.pyManualSetButton.Location = new System.Drawing.Point(272, 146);
			this.pyManualSetButton.Name = "pyManualSetButton";
			this.pyManualSetButton.Size = new System.Drawing.Size(75, 23);
			this.pyManualSetButton.TabIndex = 14;
			this.pyManualSetButton.Text = "浏览";
			this.pyManualSetButton.UseVisualStyleBackColor = true;
			this.pyManualSetButton.Click += new System.EventHandler(this.pyManualSetFind_Click);
			// 
			// pyManualSetOption
			// 
			this.pyManualSetOption.AutoSize = true;
			this.pyManualSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pyManualSetOption.Location = new System.Drawing.Point(30, 112);
			this.pyManualSetOption.Name = "pyManualSetOption";
			this.pyManualSetOption.Size = new System.Drawing.Size(179, 18);
			this.pyManualSetOption.TabIndex = 9;
			this.pyManualSetOption.Text = "手动指定python所在位置\r\n";
			this.pyManualSetOption.UseVisualStyleBackColor = true;
			this.pyManualSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
			// 
			// pyManualSetValue
			// 
			this.pyManualSetValue.Enabled = false;
			this.pyManualSetValue.Location = new System.Drawing.Point(50, 147);
			this.pyManualSetValue.Name = "pyManualSetValue";
			this.pyManualSetValue.Size = new System.Drawing.Size(217, 21);
			this.pyManualSetValue.TabIndex = 11;
			// 
			// other
			// 
			this.other.Controls.Add(this.managePath);
			this.other.Controls.Add(this.isAppend);
			this.other.Controls.Add(this.otherSettingTip);
			this.other.Controls.Add(this.otherSetTip);
			this.other.Controls.Add(this.otherOK);
			this.other.Controls.Add(this.otherSetButton);
			this.other.Controls.Add(this.otherSetValue);
			this.other.Location = new System.Drawing.Point(4, 22);
			this.other.Name = "other";
			this.other.Padding = new System.Windows.Forms.Padding(3);
			this.other.Size = new System.Drawing.Size(373, 230);
			this.other.TabIndex = 1;
			this.other.Text = "加入路径至Path环境变量";
			this.other.UseVisualStyleBackColor = true;
			// 
			// managePath
			// 
			this.managePath.Location = new System.Drawing.Point(281, 6);
			this.managePath.Margin = new System.Windows.Forms.Padding(2);
			this.managePath.Name = "managePath";
			this.managePath.Size = new System.Drawing.Size(88, 26);
			this.managePath.TabIndex = 11;
			this.managePath.Text = "管理Path变量";
			this.managePath.UseVisualStyleBackColor = true;
			this.managePath.Click += new System.EventHandler(this.managePath_Click);
			// 
			// isAppend
			// 
			this.isAppend.AutoSize = true;
			this.isAppend.Checked = true;
			this.isAppend.CheckState = System.Windows.Forms.CheckState.Checked;
			this.isAppend.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.isAppend.Location = new System.Drawing.Point(30, 72);
			this.isAppend.Margin = new System.Windows.Forms.Padding(2);
			this.isAppend.Name = "isAppend";
			this.isAppend.Size = new System.Drawing.Size(144, 16);
			this.isAppend.TabIndex = 10;
			this.isAppend.Text = "追加值至Path变量末尾";
			this.isAppend.UseVisualStyleBackColor = true;
			// 
			// otherSettingTip
			// 
			this.otherSettingTip.AutoSize = true;
			this.otherSettingTip.ForeColor = System.Drawing.Color.Blue;
			this.otherSettingTip.Location = new System.Drawing.Point(5, 209);
			this.otherSettingTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.otherSettingTip.Name = "otherSettingTip";
			this.otherSettingTip.Size = new System.Drawing.Size(143, 12);
			this.otherSettingTip.TabIndex = 9;
			this.otherSettingTip.Text = "正在追加Path环境变量...";
			this.otherSettingTip.Visible = false;
			// 
			// otherSetTip
			// 
			this.otherSetTip.AutoSize = true;
			this.otherSetTip.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.otherSetTip.Location = new System.Drawing.Point(28, 42);
			this.otherSetTip.Name = "otherSetTip";
			this.otherSetTip.Size = new System.Drawing.Size(189, 14);
			this.otherSetTip.TabIndex = 8;
			this.otherSetTip.Text = "请指定目录并加至Path变量：";
			// 
			// otherOK
			// 
			this.otherOK.Location = new System.Drawing.Point(148, 166);
			this.otherOK.Name = "otherOK";
			this.otherOK.Size = new System.Drawing.Size(75, 23);
			this.otherOK.TabIndex = 7;
			this.otherOK.Text = "设定";
			this.otherOK.UseVisualStyleBackColor = true;
			this.otherOK.Click += new System.EventHandler(this.otherOK_Click);
			// 
			// otherSetButton
			// 
			this.otherSetButton.Location = new System.Drawing.Point(281, 105);
			this.otherSetButton.Name = "otherSetButton";
			this.otherSetButton.Size = new System.Drawing.Size(75, 23);
			this.otherSetButton.TabIndex = 6;
			this.otherSetButton.Text = "浏览";
			this.otherSetButton.UseVisualStyleBackColor = true;
			this.otherSetButton.Click += new System.EventHandler(this.otherSetButton_Click);
			// 
			// otherSetValue
			// 
			this.otherSetValue.Location = new System.Drawing.Point(30, 106);
			this.otherSetValue.Name = "otherSetValue";
			this.otherSetValue.Size = new System.Drawing.Size(240, 21);
			this.otherSetValue.TabIndex = 5;
			// 
			// MainGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(381, 257);
			this.Controls.Add(this.mainTabPane);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainGUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "环境变量设置工具";
			this.Load += new System.EventHandler(this.MainGUI_Load);
			this.mainTabPane.ResumeLayout(false);
			this.jdkSetTab.ResumeLayout(false);
			this.jdkSetTab.PerformLayout();
			this.pythonTab.ResumeLayout(false);
			this.pythonTab.PerformLayout();
			this.other.ResumeLayout(false);
			this.other.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label jdkAutoSetLabel;
        private System.Windows.Forms.RadioButton jdkAutoSetOption;
        private System.Windows.Forms.ComboBox jdkAutoSetValue;
        private System.Windows.Forms.RadioButton jdkManualSetOption;
        private System.Windows.Forms.TextBox jdkManualSetValue;
        private System.Windows.Forms.Button jdkManualSetButton;
        private System.Windows.Forms.Button JDKok;
        private System.Windows.Forms.TabControl mainTabPane;
        private System.Windows.Forms.TabPage jdkSetTab;
        private System.Windows.Forms.TabPage other;
        private System.Windows.Forms.Label jdkNotFoundTip;
        private System.Windows.Forms.Label otherSetTip;
        private System.Windows.Forms.Button otherOK;
        private System.Windows.Forms.Button otherSetButton;
        private System.Windows.Forms.TextBox otherSetValue;
        private System.Windows.Forms.Button jdkRecheck;
        private System.Windows.Forms.Label jdkSettingTip;
        private System.Windows.Forms.Label otherSettingTip;
        private System.Windows.Forms.TabPage pythonTab;
        private System.Windows.Forms.Label pySettingTip;
        private System.Windows.Forms.Button pyRecheck;
        private System.Windows.Forms.ComboBox pyAutoSetValue;
        private System.Windows.Forms.RadioButton pyAutoSetOption;
        private System.Windows.Forms.Button pyOk;
        private System.Windows.Forms.Label pyNotFoundTip;
        private System.Windows.Forms.Label pyAutoSetLabel;
        private System.Windows.Forms.Button pyManualSetButton;
        private System.Windows.Forms.RadioButton pyManualSetOption;
        private System.Windows.Forms.TextBox pyManualSetValue;
		private System.Windows.Forms.CheckBox isAppend;
		private System.Windows.Forms.ToolTip appendToolTip;
		private System.Windows.Forms.Button managePath;
	}
}

