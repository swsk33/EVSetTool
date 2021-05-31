
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
			this.otherSettingTip = new System.Windows.Forms.Label();
			this.otherSetTip = new System.Windows.Forms.Label();
			this.otherOK = new System.Windows.Forms.Button();
			this.otherSetButton = new System.Windows.Forms.Button();
			this.otherSetValue = new System.Windows.Forms.TextBox();
			this.isAppend = new System.Windows.Forms.CheckBox();
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
			this.jdkAutoSetLabel.Location = new System.Drawing.Point(63, 96);
			this.jdkAutoSetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.jdkAutoSetLabel.Name = "jdkAutoSetLabel";
			this.jdkAutoSetLabel.Size = new System.Drawing.Size(116, 18);
			this.jdkAutoSetLabel.TabIndex = 0;
			this.jdkAutoSetLabel.Text = "已搜寻版本：";
			// 
			// jdkAutoSetOption
			// 
			this.jdkAutoSetOption.AutoSize = true;
			this.jdkAutoSetOption.Checked = true;
			this.jdkAutoSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.jdkAutoSetOption.Location = new System.Drawing.Point(40, 52);
			this.jdkAutoSetOption.Margin = new System.Windows.Forms.Padding(4);
			this.jdkAutoSetOption.Name = "jdkAutoSetOption";
			this.jdkAutoSetOption.Size = new System.Drawing.Size(218, 22);
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
			this.jdkAutoSetValue.Location = new System.Drawing.Point(177, 94);
			this.jdkAutoSetValue.Margin = new System.Windows.Forms.Padding(4);
			this.jdkAutoSetValue.Name = "jdkAutoSetValue";
			this.jdkAutoSetValue.Size = new System.Drawing.Size(115, 23);
			this.jdkAutoSetValue.TabIndex = 2;
			// 
			// jdkManualSetOption
			// 
			this.jdkManualSetOption.AutoSize = true;
			this.jdkManualSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.jdkManualSetOption.Location = new System.Drawing.Point(40, 140);
			this.jdkManualSetOption.Margin = new System.Windows.Forms.Padding(4);
			this.jdkManualSetOption.Name = "jdkManualSetOption";
			this.jdkManualSetOption.Size = new System.Drawing.Size(200, 22);
			this.jdkManualSetOption.TabIndex = 1;
			this.jdkManualSetOption.Text = "手动指定jdk所在位置\r\n";
			this.jdkManualSetOption.UseVisualStyleBackColor = true;
			this.jdkManualSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
			// 
			// jdkManualSetValue
			// 
			this.jdkManualSetValue.Enabled = false;
			this.jdkManualSetValue.Location = new System.Drawing.Point(67, 184);
			this.jdkManualSetValue.Margin = new System.Windows.Forms.Padding(4);
			this.jdkManualSetValue.Name = "jdkManualSetValue";
			this.jdkManualSetValue.Size = new System.Drawing.Size(285, 25);
			this.jdkManualSetValue.TabIndex = 3;
			// 
			// jdkManualSetButton
			// 
			this.jdkManualSetButton.Enabled = false;
			this.jdkManualSetButton.Location = new System.Drawing.Point(360, 182);
			this.jdkManualSetButton.Margin = new System.Windows.Forms.Padding(4);
			this.jdkManualSetButton.Name = "jdkManualSetButton";
			this.jdkManualSetButton.Size = new System.Drawing.Size(100, 29);
			this.jdkManualSetButton.TabIndex = 4;
			this.jdkManualSetButton.Text = "浏览";
			this.jdkManualSetButton.UseVisualStyleBackColor = true;
			this.jdkManualSetButton.Click += new System.EventHandler(this.jdkManualSetButton_Click);
			// 
			// JDKok
			// 
			this.JDKok.Location = new System.Drawing.Point(201, 228);
			this.JDKok.Margin = new System.Windows.Forms.Padding(4);
			this.JDKok.Name = "JDKok";
			this.JDKok.Size = new System.Drawing.Size(100, 29);
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
			this.mainTabPane.Margin = new System.Windows.Forms.Padding(4);
			this.mainTabPane.Name = "mainTabPane";
			this.mainTabPane.SelectedIndex = 0;
			this.mainTabPane.Size = new System.Drawing.Size(508, 320);
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
			this.jdkSetTab.Location = new System.Drawing.Point(4, 25);
			this.jdkSetTab.Margin = new System.Windows.Forms.Padding(4);
			this.jdkSetTab.Name = "jdkSetTab";
			this.jdkSetTab.Padding = new System.Windows.Forms.Padding(4);
			this.jdkSetTab.Size = new System.Drawing.Size(496, 291);
			this.jdkSetTab.TabIndex = 0;
			this.jdkSetTab.Text = "jdk环境变量设置";
			this.jdkSetTab.UseVisualStyleBackColor = true;
			// 
			// jdkSettingTip
			// 
			this.jdkSettingTip.AutoSize = true;
			this.jdkSettingTip.ForeColor = System.Drawing.Color.Blue;
			this.jdkSettingTip.Location = new System.Drawing.Point(7, 271);
			this.jdkSettingTip.Name = "jdkSettingTip";
			this.jdkSettingTip.Size = new System.Drawing.Size(175, 15);
			this.jdkSettingTip.TabIndex = 5;
			this.jdkSettingTip.Text = "正在设定jdk环境变量...";
			this.jdkSettingTip.Visible = false;
			// 
			// jdkRecheck
			// 
			this.jdkRecheck.Location = new System.Drawing.Point(389, 7);
			this.jdkRecheck.Margin = new System.Windows.Forms.Padding(4);
			this.jdkRecheck.Name = "jdkRecheck";
			this.jdkRecheck.Size = new System.Drawing.Size(100, 29);
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
			this.jdkNotFoundTip.Location = new System.Drawing.Point(9, 11);
			this.jdkNotFoundTip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.jdkNotFoundTip.Name = "jdkNotFoundTip";
			this.jdkNotFoundTip.Size = new System.Drawing.Size(323, 18);
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
			this.pythonTab.Location = new System.Drawing.Point(4, 25);
			this.pythonTab.Name = "pythonTab";
			this.pythonTab.Size = new System.Drawing.Size(496, 291);
			this.pythonTab.TabIndex = 2;
			this.pythonTab.Text = "python环境变量设置";
			this.pythonTab.UseVisualStyleBackColor = true;
			// 
			// pyAutoSetValue
			// 
			this.pyAutoSetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.pyAutoSetValue.FormattingEnabled = true;
			this.pyAutoSetValue.Location = new System.Drawing.Point(177, 94);
			this.pyAutoSetValue.Margin = new System.Windows.Forms.Padding(4);
			this.pyAutoSetValue.Name = "pyAutoSetValue";
			this.pyAutoSetValue.Size = new System.Drawing.Size(115, 23);
			this.pyAutoSetValue.TabIndex = 10;
			// 
			// pyRecheck
			// 
			this.pyRecheck.Location = new System.Drawing.Point(390, 6);
			this.pyRecheck.Margin = new System.Windows.Forms.Padding(4);
			this.pyRecheck.Name = "pyRecheck";
			this.pyRecheck.Size = new System.Drawing.Size(100, 29);
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
			this.pySettingTip.Location = new System.Drawing.Point(7, 271);
			this.pySettingTip.Name = "pySettingTip";
			this.pySettingTip.Size = new System.Drawing.Size(199, 15);
			this.pySettingTip.TabIndex = 15;
			this.pySettingTip.Text = "正在设定python环境变量...";
			this.pySettingTip.Visible = false;
			// 
			// pyAutoSetOption
			// 
			this.pyAutoSetOption.AutoSize = true;
			this.pyAutoSetOption.Checked = true;
			this.pyAutoSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pyAutoSetOption.Location = new System.Drawing.Point(40, 52);
			this.pyAutoSetOption.Margin = new System.Windows.Forms.Padding(4);
			this.pyAutoSetOption.Name = "pyAutoSetOption";
			this.pyAutoSetOption.Size = new System.Drawing.Size(245, 22);
			this.pyAutoSetOption.TabIndex = 8;
			this.pyAutoSetOption.TabStop = true;
			this.pyAutoSetOption.Text = "自动搜寻python并一键设定";
			this.pyAutoSetOption.UseVisualStyleBackColor = true;
			this.pyAutoSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
			// 
			// pyOk
			// 
			this.pyOk.Location = new System.Drawing.Point(205, 227);
			this.pyOk.Margin = new System.Windows.Forms.Padding(4);
			this.pyOk.Name = "pyOk";
			this.pyOk.Size = new System.Drawing.Size(100, 29);
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
			this.pyNotFoundTip.Location = new System.Drawing.Point(9, 11);
			this.pyNotFoundTip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.pyNotFoundTip.Name = "pyNotFoundTip";
			this.pyNotFoundTip.Size = new System.Drawing.Size(350, 18);
			this.pyNotFoundTip.TabIndex = 6;
			this.pyNotFoundTip.Text = "找不到此电脑安装了python，请手动指定！";
			this.pyNotFoundTip.Visible = false;
			// 
			// pyAutoSetLabel
			// 
			this.pyAutoSetLabel.AutoSize = true;
			this.pyAutoSetLabel.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pyAutoSetLabel.Location = new System.Drawing.Point(63, 96);
			this.pyAutoSetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.pyAutoSetLabel.Name = "pyAutoSetLabel";
			this.pyAutoSetLabel.Size = new System.Drawing.Size(116, 18);
			this.pyAutoSetLabel.TabIndex = 7;
			this.pyAutoSetLabel.Text = "已搜寻版本：";
			// 
			// pyManualSetButton
			// 
			this.pyManualSetButton.Enabled = false;
			this.pyManualSetButton.Location = new System.Drawing.Point(363, 182);
			this.pyManualSetButton.Margin = new System.Windows.Forms.Padding(4);
			this.pyManualSetButton.Name = "pyManualSetButton";
			this.pyManualSetButton.Size = new System.Drawing.Size(100, 29);
			this.pyManualSetButton.TabIndex = 14;
			this.pyManualSetButton.Text = "浏览";
			this.pyManualSetButton.UseVisualStyleBackColor = true;
			this.pyManualSetButton.Click += new System.EventHandler(this.pyManualSetFind_Click);
			// 
			// pyManualSetOption
			// 
			this.pyManualSetOption.AutoSize = true;
			this.pyManualSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pyManualSetOption.Location = new System.Drawing.Point(40, 140);
			this.pyManualSetOption.Margin = new System.Windows.Forms.Padding(4);
			this.pyManualSetOption.Name = "pyManualSetOption";
			this.pyManualSetOption.Size = new System.Drawing.Size(227, 22);
			this.pyManualSetOption.TabIndex = 9;
			this.pyManualSetOption.Text = "手动指定python所在位置\r\n";
			this.pyManualSetOption.UseVisualStyleBackColor = true;
			this.pyManualSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
			// 
			// pyManualSetValue
			// 
			this.pyManualSetValue.Enabled = false;
			this.pyManualSetValue.Location = new System.Drawing.Point(67, 184);
			this.pyManualSetValue.Margin = new System.Windows.Forms.Padding(4);
			this.pyManualSetValue.Name = "pyManualSetValue";
			this.pyManualSetValue.Size = new System.Drawing.Size(288, 25);
			this.pyManualSetValue.TabIndex = 11;
			// 
			// other
			// 
			this.other.Controls.Add(this.isAppend);
			this.other.Controls.Add(this.otherSettingTip);
			this.other.Controls.Add(this.otherSetTip);
			this.other.Controls.Add(this.otherOK);
			this.other.Controls.Add(this.otherSetButton);
			this.other.Controls.Add(this.otherSetValue);
			this.other.Location = new System.Drawing.Point(4, 25);
			this.other.Margin = new System.Windows.Forms.Padding(4);
			this.other.Name = "other";
			this.other.Padding = new System.Windows.Forms.Padding(4);
			this.other.Size = new System.Drawing.Size(500, 291);
			this.other.TabIndex = 1;
			this.other.Text = "加入路径至Path环境变量";
			this.other.UseVisualStyleBackColor = true;
			// 
			// otherSettingTip
			// 
			this.otherSettingTip.AutoSize = true;
			this.otherSettingTip.ForeColor = System.Drawing.Color.Blue;
			this.otherSettingTip.Location = new System.Drawing.Point(7, 261);
			this.otherSettingTip.Name = "otherSettingTip";
			this.otherSettingTip.Size = new System.Drawing.Size(183, 15);
			this.otherSettingTip.TabIndex = 9;
			this.otherSettingTip.Text = "正在追加Path环境变量...";
			this.otherSettingTip.Visible = false;
			// 
			// otherSetTip
			// 
			this.otherSetTip.AutoSize = true;
			this.otherSetTip.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.otherSetTip.Location = new System.Drawing.Point(37, 52);
			this.otherSetTip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.otherSetTip.Name = "otherSetTip";
			this.otherSetTip.Size = new System.Drawing.Size(242, 18);
			this.otherSetTip.TabIndex = 8;
			this.otherSetTip.Text = "请指定目录并加至Path变量：";
			// 
			// otherOK
			// 
			this.otherOK.Location = new System.Drawing.Point(198, 208);
			this.otherOK.Margin = new System.Windows.Forms.Padding(4);
			this.otherOK.Name = "otherOK";
			this.otherOK.Size = new System.Drawing.Size(100, 29);
			this.otherOK.TabIndex = 7;
			this.otherOK.Text = "设定";
			this.otherOK.UseVisualStyleBackColor = true;
			this.otherOK.Click += new System.EventHandler(this.otherOK_Click);
			// 
			// otherSetButton
			// 
			this.otherSetButton.Location = new System.Drawing.Point(366, 133);
			this.otherSetButton.Margin = new System.Windows.Forms.Padding(4);
			this.otherSetButton.Name = "otherSetButton";
			this.otherSetButton.Size = new System.Drawing.Size(100, 29);
			this.otherSetButton.TabIndex = 6;
			this.otherSetButton.Text = "浏览";
			this.otherSetButton.UseVisualStyleBackColor = true;
			this.otherSetButton.Click += new System.EventHandler(this.otherSetButton_Click);
			// 
			// otherSetValue
			// 
			this.otherSetValue.Location = new System.Drawing.Point(40, 133);
			this.otherSetValue.Margin = new System.Windows.Forms.Padding(4);
			this.otherSetValue.Name = "otherSetValue";
			this.otherSetValue.Size = new System.Drawing.Size(318, 25);
			this.otherSetValue.TabIndex = 5;
			// 
			// isAppend
			// 
			this.isAppend.AutoSize = true;
			this.isAppend.Checked = true;
			this.isAppend.CheckState = System.Windows.Forms.CheckState.Checked;
			this.isAppend.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.isAppend.Location = new System.Drawing.Point(40, 90);
			this.isAppend.Name = "isAppend";
			this.isAppend.Size = new System.Drawing.Size(181, 19);
			this.isAppend.TabIndex = 10;
			this.isAppend.Text = "追加值至Path变量末尾";
			this.isAppend.UseVisualStyleBackColor = true;
			// 
			// MainGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(508, 321);
			this.Controls.Add(this.mainTabPane);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
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
	}
}

