namespace Swsk33.EVTools.Dialog
{
	partial class BackupDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupDialog));
			this.pathBackupButton = new System.Windows.Forms.Button();
			this.backupTitle = new System.Windows.Forms.Label();
			this.allBackupButton = new System.Windows.Forms.Button();
			this.backupTip = new System.Windows.Forms.Label();
			this.expandVarCheckBox = new System.Windows.Forms.CheckBox();
			this.encodingLabel = new System.Windows.Forms.Label();
			this.encodingBox = new System.Windows.Forms.ComboBox();
			this.encodingTip = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pathBackupButton
			// 
			this.pathBackupButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pathBackupButton.Location = new System.Drawing.Point(12, 81);
			this.pathBackupButton.Name = "pathBackupButton";
			this.pathBackupButton.Size = new System.Drawing.Size(272, 29);
			this.pathBackupButton.TabIndex = 0;
			this.pathBackupButton.Text = "备份Path变量";
			this.pathBackupButton.UseVisualStyleBackColor = true;
			this.pathBackupButton.Click += new System.EventHandler(this.pathBackupButton_Click);
			// 
			// backupTitle
			// 
			this.backupTitle.AutoSize = true;
			this.backupTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.backupTitle.Location = new System.Drawing.Point(68, 9);
			this.backupTitle.Name = "backupTitle";
			this.backupTitle.Size = new System.Drawing.Size(151, 16);
			this.backupTitle.TabIndex = 1;
			this.backupTitle.Text = "导出为备份还原脚本";
			// 
			// allBackupButton
			// 
			this.allBackupButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.allBackupButton.Location = new System.Drawing.Point(12, 115);
			this.allBackupButton.Name = "allBackupButton";
			this.allBackupButton.Size = new System.Drawing.Size(272, 29);
			this.allBackupButton.TabIndex = 0;
			this.allBackupButton.Text = "备份全部系统环境变量";
			this.allBackupButton.UseVisualStyleBackColor = true;
			this.allBackupButton.Click += new System.EventHandler(this.allBackupButton_Click);
			// 
			// backupTip
			// 
			this.backupTip.AutoSize = true;
			this.backupTip.ForeColor = System.Drawing.Color.Blue;
			this.backupTip.Location = new System.Drawing.Point(4, 151);
			this.backupTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.backupTip.Name = "backupTip";
			this.backupTip.Size = new System.Drawing.Size(95, 12);
			this.backupTip.TabIndex = 10;
			this.backupTip.Text = "正在导出备份...";
			this.backupTip.Visible = false;
			// 
			// expandVarCheckBox
			// 
			this.expandVarCheckBox.AutoSize = true;
			this.expandVarCheckBox.Location = new System.Drawing.Point(12, 35);
			this.expandVarCheckBox.Name = "expandVarCheckBox";
			this.expandVarCheckBox.Size = new System.Drawing.Size(96, 16);
			this.expandVarCheckBox.TabIndex = 11;
			this.expandVarCheckBox.Text = "展开变量引用";
			this.expandVarCheckBox.UseVisualStyleBackColor = true;
			// 
			// encodingLabel
			// 
			this.encodingLabel.AutoSize = true;
			this.encodingLabel.Location = new System.Drawing.Point(113, 36);
			this.encodingLabel.Name = "encodingLabel";
			this.encodingLabel.Size = new System.Drawing.Size(65, 12);
			this.encodingLabel.TabIndex = 12;
			this.encodingLabel.Text = "脚本编码：";
			// 
			// encodingBox
			// 
			this.encodingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.encodingBox.FormattingEnabled = true;
			this.encodingBox.Location = new System.Drawing.Point(176, 32);
			this.encodingBox.Name = "encodingBox";
			this.encodingBox.Size = new System.Drawing.Size(108, 20);
			this.encodingBox.TabIndex = 13;
			// 
			// encodingTip
			// 
			this.encodingTip.AutoSize = true;
			this.encodingTip.ForeColor = System.Drawing.Color.Magenta;
			this.encodingTip.Location = new System.Drawing.Point(13, 59);
			this.encodingTip.Name = "encodingTip";
			this.encodingTip.Size = new System.Drawing.Size(245, 12);
			this.encodingTip.TabIndex = 14;
			this.encodingTip.Text = "编码需要与系统一致，否则会导致中文乱码！";
			// 
			// BackupDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 167);
			this.Controls.Add(this.encodingTip);
			this.Controls.Add(this.encodingBox);
			this.Controls.Add(this.encodingLabel);
			this.Controls.Add(this.expandVarCheckBox);
			this.Controls.Add(this.backupTip);
			this.Controls.Add(this.backupTitle);
			this.Controls.Add(this.allBackupButton);
			this.Controls.Add(this.pathBackupButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BackupDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "备份还原";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button pathBackupButton;
		private System.Windows.Forms.Label backupTitle;
		private System.Windows.Forms.Button allBackupButton;
		private System.Windows.Forms.Label backupTip;
		private System.Windows.Forms.CheckBox expandVarCheckBox;
		private System.Windows.Forms.Label encodingLabel;
		private System.Windows.Forms.ComboBox encodingBox;
		private System.Windows.Forms.Label encodingTip;
	}
}