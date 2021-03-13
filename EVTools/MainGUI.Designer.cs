
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.autoSetLabel = new System.Windows.Forms.Label();
            this.autoSetOption = new System.Windows.Forms.RadioButton();
            this.autoSetValue = new System.Windows.Forms.ComboBox();
            this.manualSetOption = new System.Windows.Forms.RadioButton();
            this.manualSetValue = new System.Windows.Forms.TextBox();
            this.manualSetButton = new System.Windows.Forms.Button();
            this.JDKok = new System.Windows.Forms.Button();
            this.mainTabPane = new System.Windows.Forms.TabControl();
            this.jdkSetTab = new System.Windows.Forms.TabPage();
            this.recheck = new System.Windows.Forms.Button();
            this.jdkNotFoundTip = new System.Windows.Forms.Label();
            this.other = new System.Windows.Forms.TabPage();
            this.otherSetTip = new System.Windows.Forms.Label();
            this.otherOK = new System.Windows.Forms.Button();
            this.otherSetButton = new System.Windows.Forms.Button();
            this.otherSetValue = new System.Windows.Forms.TextBox();
            this.jdkSettingTip = new System.Windows.Forms.Label();
            this.otherSettingTip = new System.Windows.Forms.Label();
            this.mainTabPane.SuspendLayout();
            this.jdkSetTab.SuspendLayout();
            this.other.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoSetLabel
            // 
            this.autoSetLabel.AutoSize = true;
            this.autoSetLabel.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoSetLabel.Location = new System.Drawing.Point(63, 96);
            this.autoSetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.autoSetLabel.Name = "autoSetLabel";
            this.autoSetLabel.Size = new System.Drawing.Size(116, 18);
            this.autoSetLabel.TabIndex = 0;
            this.autoSetLabel.Text = "已搜寻版本：";
            // 
            // autoSetOption
            // 
            this.autoSetOption.AutoSize = true;
            this.autoSetOption.Checked = true;
            this.autoSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoSetOption.Location = new System.Drawing.Point(40, 52);
            this.autoSetOption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.autoSetOption.Name = "autoSetOption";
            this.autoSetOption.Size = new System.Drawing.Size(218, 22);
            this.autoSetOption.TabIndex = 1;
            this.autoSetOption.TabStop = true;
            this.autoSetOption.Text = "自动搜寻jdk并一键设定";
            this.autoSetOption.UseVisualStyleBackColor = true;
            this.autoSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
            // 
            // autoSetValue
            // 
            this.autoSetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoSetValue.FormattingEnabled = true;
            this.autoSetValue.Location = new System.Drawing.Point(177, 94);
            this.autoSetValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.autoSetValue.Name = "autoSetValue";
            this.autoSetValue.Size = new System.Drawing.Size(115, 23);
            this.autoSetValue.TabIndex = 2;
            // 
            // manualSetOption
            // 
            this.manualSetOption.AutoSize = true;
            this.manualSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.manualSetOption.Location = new System.Drawing.Point(40, 140);
            this.manualSetOption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.manualSetOption.Name = "manualSetOption";
            this.manualSetOption.Size = new System.Drawing.Size(200, 22);
            this.manualSetOption.TabIndex = 1;
            this.manualSetOption.Text = "手动指定jdk所在位置\r\n";
            this.manualSetOption.UseVisualStyleBackColor = true;
            this.manualSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
            // 
            // manualSetValue
            // 
            this.manualSetValue.Enabled = false;
            this.manualSetValue.Location = new System.Drawing.Point(67, 184);
            this.manualSetValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.manualSetValue.Name = "manualSetValue";
            this.manualSetValue.Size = new System.Drawing.Size(212, 25);
            this.manualSetValue.TabIndex = 3;
            // 
            // manualSetButton
            // 
            this.manualSetButton.Enabled = false;
            this.manualSetButton.Location = new System.Drawing.Point(291, 182);
            this.manualSetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.manualSetButton.Name = "manualSetButton";
            this.manualSetButton.Size = new System.Drawing.Size(100, 29);
            this.manualSetButton.TabIndex = 4;
            this.manualSetButton.Text = "浏览";
            this.manualSetButton.UseVisualStyleBackColor = true;
            this.manualSetButton.Click += new System.EventHandler(this.manualSetButton_Click);
            // 
            // JDKok
            // 
            this.JDKok.Location = new System.Drawing.Point(173, 231);
            this.JDKok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.mainTabPane.Controls.Add(this.other);
            this.mainTabPane.Location = new System.Drawing.Point(1, 1);
            this.mainTabPane.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainTabPane.Name = "mainTabPane";
            this.mainTabPane.SelectedIndex = 0;
            this.mainTabPane.Size = new System.Drawing.Size(455, 320);
            this.mainTabPane.TabIndex = 5;
            // 
            // jdkSetTab
            // 
            this.jdkSetTab.Controls.Add(this.jdkSettingTip);
            this.jdkSetTab.Controls.Add(this.recheck);
            this.jdkSetTab.Controls.Add(this.autoSetValue);
            this.jdkSetTab.Controls.Add(this.autoSetOption);
            this.jdkSetTab.Controls.Add(this.JDKok);
            this.jdkSetTab.Controls.Add(this.jdkNotFoundTip);
            this.jdkSetTab.Controls.Add(this.autoSetLabel);
            this.jdkSetTab.Controls.Add(this.manualSetButton);
            this.jdkSetTab.Controls.Add(this.manualSetOption);
            this.jdkSetTab.Controls.Add(this.manualSetValue);
            this.jdkSetTab.Location = new System.Drawing.Point(4, 25);
            this.jdkSetTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.jdkSetTab.Name = "jdkSetTab";
            this.jdkSetTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.jdkSetTab.Size = new System.Drawing.Size(447, 291);
            this.jdkSetTab.TabIndex = 0;
            this.jdkSetTab.Text = "jdk环境变量设置";
            this.jdkSetTab.UseVisualStyleBackColor = true;
            // 
            // recheck
            // 
            this.recheck.Location = new System.Drawing.Point(336, 5);
            this.recheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recheck.Name = "recheck";
            this.recheck.Size = new System.Drawing.Size(100, 29);
            this.recheck.TabIndex = 4;
            this.recheck.Text = "重新检测";
            this.recheck.UseVisualStyleBackColor = true;
            this.recheck.Visible = false;
            this.recheck.Click += new System.EventHandler(this.recheck_Click);
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
            // other
            // 
            this.other.Controls.Add(this.otherSettingTip);
            this.other.Controls.Add(this.otherSetTip);
            this.other.Controls.Add(this.otherOK);
            this.other.Controls.Add(this.otherSetButton);
            this.other.Controls.Add(this.otherSetValue);
            this.other.Location = new System.Drawing.Point(4, 25);
            this.other.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.other.Name = "other";
            this.other.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.other.Size = new System.Drawing.Size(447, 291);
            this.other.TabIndex = 1;
            this.other.Text = "加入路径至Path环境变量";
            this.other.UseVisualStyleBackColor = true;
            // 
            // otherSetTip
            // 
            this.otherSetTip.AutoSize = true;
            this.otherSetTip.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.otherSetTip.Location = new System.Drawing.Point(36, 68);
            this.otherSetTip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.otherSetTip.Name = "otherSetTip";
            this.otherSetTip.Size = new System.Drawing.Size(242, 18);
            this.otherSetTip.TabIndex = 8;
            this.otherSetTip.Text = "请指定目录并加至Path变量：";
            // 
            // otherOK
            // 
            this.otherOK.Location = new System.Drawing.Point(168, 208);
            this.otherOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.otherOK.Name = "otherOK";
            this.otherOK.Size = new System.Drawing.Size(100, 29);
            this.otherOK.TabIndex = 7;
            this.otherOK.Text = "设定";
            this.otherOK.UseVisualStyleBackColor = true;
            this.otherOK.Click += new System.EventHandler(this.otherOK_Click);
            // 
            // otherSetButton
            // 
            this.otherSetButton.Location = new System.Drawing.Point(304, 134);
            this.otherSetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.otherSetButton.Name = "otherSetButton";
            this.otherSetButton.Size = new System.Drawing.Size(100, 29);
            this.otherSetButton.TabIndex = 6;
            this.otherSetButton.Text = "浏览";
            this.otherSetButton.UseVisualStyleBackColor = true;
            this.otherSetButton.Click += new System.EventHandler(this.otherSetButton_Click);
            // 
            // otherSetValue
            // 
            this.otherSetValue.Location = new System.Drawing.Point(40, 135);
            this.otherSetValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.otherSetValue.Name = "otherSetValue";
            this.otherSetValue.Size = new System.Drawing.Size(237, 25);
            this.otherSetValue.TabIndex = 5;
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
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 321);
            this.Controls.Add(this.mainTabPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "环境变量设置工具";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.mainTabPane.ResumeLayout(false);
            this.jdkSetTab.ResumeLayout(false);
            this.jdkSetTab.PerformLayout();
            this.other.ResumeLayout(false);
            this.other.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label autoSetLabel;
        private System.Windows.Forms.RadioButton autoSetOption;
        private System.Windows.Forms.ComboBox autoSetValue;
        private System.Windows.Forms.RadioButton manualSetOption;
        private System.Windows.Forms.TextBox manualSetValue;
        private System.Windows.Forms.Button manualSetButton;
        private System.Windows.Forms.Button JDKok;
        private System.Windows.Forms.TabControl mainTabPane;
        private System.Windows.Forms.TabPage jdkSetTab;
        private System.Windows.Forms.TabPage other;
        private System.Windows.Forms.Label jdkNotFoundTip;
        private System.Windows.Forms.Label otherSetTip;
        private System.Windows.Forms.Button otherOK;
        private System.Windows.Forms.Button otherSetButton;
        private System.Windows.Forms.TextBox otherSetValue;
        private System.Windows.Forms.Button recheck;
        private System.Windows.Forms.Label jdkSettingTip;
        private System.Windows.Forms.Label otherSettingTip;
    }
}

