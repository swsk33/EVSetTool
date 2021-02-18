
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
            this.mainTabPane.SuspendLayout();
            this.jdkSetTab.SuspendLayout();
            this.other.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoSetLabel
            // 
            this.autoSetLabel.AutoSize = true;
            this.autoSetLabel.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoSetLabel.Location = new System.Drawing.Point(47, 77);
            this.autoSetLabel.Name = "autoSetLabel";
            this.autoSetLabel.Size = new System.Drawing.Size(91, 14);
            this.autoSetLabel.TabIndex = 0;
            this.autoSetLabel.Text = "已搜寻版本：";
            // 
            // autoSetOption
            // 
            this.autoSetOption.AutoSize = true;
            this.autoSetOption.Checked = true;
            this.autoSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoSetOption.Location = new System.Drawing.Point(30, 42);
            this.autoSetOption.Name = "autoSetOption";
            this.autoSetOption.Size = new System.Drawing.Size(172, 18);
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
            this.autoSetValue.Location = new System.Drawing.Point(133, 75);
            this.autoSetValue.Name = "autoSetValue";
            this.autoSetValue.Size = new System.Drawing.Size(87, 20);
            this.autoSetValue.TabIndex = 2;
            // 
            // manualSetOption
            // 
            this.manualSetOption.AutoSize = true;
            this.manualSetOption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.manualSetOption.Location = new System.Drawing.Point(30, 112);
            this.manualSetOption.Name = "manualSetOption";
            this.manualSetOption.Size = new System.Drawing.Size(158, 18);
            this.manualSetOption.TabIndex = 1;
            this.manualSetOption.Text = "手动指定jdk所在位置\r\n";
            this.manualSetOption.UseVisualStyleBackColor = true;
            this.manualSetOption.CheckedChanged += new System.EventHandler(this.GetRadioButtonChanged);
            // 
            // manualSetValue
            // 
            this.manualSetValue.Enabled = false;
            this.manualSetValue.Location = new System.Drawing.Point(50, 147);
            this.manualSetValue.Name = "manualSetValue";
            this.manualSetValue.Size = new System.Drawing.Size(160, 21);
            this.manualSetValue.TabIndex = 3;
            // 
            // manualSetButton
            // 
            this.manualSetButton.Enabled = false;
            this.manualSetButton.Location = new System.Drawing.Point(218, 146);
            this.manualSetButton.Name = "manualSetButton";
            this.manualSetButton.Size = new System.Drawing.Size(75, 23);
            this.manualSetButton.TabIndex = 4;
            this.manualSetButton.Text = "浏览";
            this.manualSetButton.UseVisualStyleBackColor = true;
            this.manualSetButton.Click += new System.EventHandler(this.manualSetButton_Click);
            // 
            // JDKok
            // 
            this.JDKok.Location = new System.Drawing.Point(130, 188);
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
            this.mainTabPane.Controls.Add(this.other);
            this.mainTabPane.Location = new System.Drawing.Point(1, 1);
            this.mainTabPane.Name = "mainTabPane";
            this.mainTabPane.SelectedIndex = 0;
            this.mainTabPane.Size = new System.Drawing.Size(341, 256);
            this.mainTabPane.TabIndex = 5;
            // 
            // jdkSetTab
            // 
            this.jdkSetTab.Controls.Add(this.recheck);
            this.jdkSetTab.Controls.Add(this.autoSetValue);
            this.jdkSetTab.Controls.Add(this.autoSetOption);
            this.jdkSetTab.Controls.Add(this.JDKok);
            this.jdkSetTab.Controls.Add(this.jdkNotFoundTip);
            this.jdkSetTab.Controls.Add(this.autoSetLabel);
            this.jdkSetTab.Controls.Add(this.manualSetButton);
            this.jdkSetTab.Controls.Add(this.manualSetOption);
            this.jdkSetTab.Controls.Add(this.manualSetValue);
            this.jdkSetTab.Location = new System.Drawing.Point(4, 22);
            this.jdkSetTab.Name = "jdkSetTab";
            this.jdkSetTab.Padding = new System.Windows.Forms.Padding(3);
            this.jdkSetTab.Size = new System.Drawing.Size(333, 230);
            this.jdkSetTab.TabIndex = 0;
            this.jdkSetTab.Text = "jdk环境变量设置";
            this.jdkSetTab.UseVisualStyleBackColor = true;
            // 
            // recheck
            // 
            this.recheck.Location = new System.Drawing.Point(252, 4);
            this.recheck.Name = "recheck";
            this.recheck.Size = new System.Drawing.Size(75, 23);
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
            this.jdkNotFoundTip.Location = new System.Drawing.Point(7, 9);
            this.jdkNotFoundTip.Name = "jdkNotFoundTip";
            this.jdkNotFoundTip.Size = new System.Drawing.Size(252, 14);
            this.jdkNotFoundTip.TabIndex = 0;
            this.jdkNotFoundTip.Text = "找不到此电脑安装了jdk，请手动指定！";
            this.jdkNotFoundTip.Visible = false;
            // 
            // other
            // 
            this.other.Controls.Add(this.otherSetTip);
            this.other.Controls.Add(this.otherOK);
            this.other.Controls.Add(this.otherSetButton);
            this.other.Controls.Add(this.otherSetValue);
            this.other.Location = new System.Drawing.Point(4, 22);
            this.other.Name = "other";
            this.other.Padding = new System.Windows.Forms.Padding(3);
            this.other.Size = new System.Drawing.Size(333, 230);
            this.other.TabIndex = 1;
            this.other.Text = "加入路径至Path环境变量";
            this.other.UseVisualStyleBackColor = true;
            // 
            // otherSetTip
            // 
            this.otherSetTip.AutoSize = true;
            this.otherSetTip.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.otherSetTip.Location = new System.Drawing.Point(27, 54);
            this.otherSetTip.Name = "otherSetTip";
            this.otherSetTip.Size = new System.Drawing.Size(189, 14);
            this.otherSetTip.TabIndex = 8;
            this.otherSetTip.Text = "请指定目录并加至Path变量：";
            // 
            // otherOK
            // 
            this.otherOK.Location = new System.Drawing.Point(126, 169);
            this.otherOK.Name = "otherOK";
            this.otherOK.Size = new System.Drawing.Size(75, 23);
            this.otherOK.TabIndex = 7;
            this.otherOK.Text = "设定";
            this.otherOK.UseVisualStyleBackColor = true;
            this.otherOK.Click += new System.EventHandler(this.otherOK_Click);
            // 
            // otherSetButton
            // 
            this.otherSetButton.Location = new System.Drawing.Point(228, 107);
            this.otherSetButton.Name = "otherSetButton";
            this.otherSetButton.Size = new System.Drawing.Size(75, 23);
            this.otherSetButton.TabIndex = 6;
            this.otherSetButton.Text = "浏览";
            this.otherSetButton.UseVisualStyleBackColor = true;
            this.otherSetButton.Click += new System.EventHandler(this.otherSetButton_Click);
            // 
            // otherSetValue
            // 
            this.otherSetValue.Location = new System.Drawing.Point(30, 108);
            this.otherSetValue.Name = "otherSetValue";
            this.otherSetValue.Size = new System.Drawing.Size(179, 21);
            this.otherSetValue.TabIndex = 5;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 257);
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
    }
}

