namespace Swsk33.EVTools.Dialog
{
	partial class ToolboxDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolboxDialog));
			this.toolboxTitle = new System.Windows.Forms.Label();
			this.cleanToolButton = new System.Windows.Forms.Button();
			this.backupToolButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// toolboxTitle
			// 
			this.toolboxTitle.AutoSize = true;
			this.toolboxTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolboxTitle.Location = new System.Drawing.Point(41, 13);
			this.toolboxTitle.Name = "toolboxTitle";
			this.toolboxTitle.Size = new System.Drawing.Size(71, 16);
			this.toolboxTitle.TabIndex = 0;
			this.toolboxTitle.Text = "实用工具";
			// 
			// cleanToolButton
			// 
			this.cleanToolButton.Location = new System.Drawing.Point(12, 42);
			this.cleanToolButton.Name = "cleanToolButton";
			this.cleanToolButton.Size = new System.Drawing.Size(126, 26);
			this.cleanToolButton.TabIndex = 1;
			this.cleanToolButton.Text = "Path强迫症工具";
			this.cleanToolButton.UseVisualStyleBackColor = true;
			this.cleanToolButton.Click += new System.EventHandler(this.cleanToolButton_Click);
			// 
			// backupToolButton
			// 
			this.backupToolButton.Location = new System.Drawing.Point(12, 74);
			this.backupToolButton.Name = "backupToolButton";
			this.backupToolButton.Size = new System.Drawing.Size(126, 26);
			this.backupToolButton.TabIndex = 1;
			this.backupToolButton.Text = "备份还原";
			this.backupToolButton.UseVisualStyleBackColor = true;
			this.backupToolButton.Click += new System.EventHandler(this.backupToolButton_Click);
			// 
			// ToolboxDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(150, 114);
			this.Controls.Add(this.backupToolButton);
			this.Controls.Add(this.cleanToolButton);
			this.Controls.Add(this.toolboxTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ToolboxDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "实用工具箱";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label toolboxTitle;
		private System.Windows.Forms.Button cleanToolButton;
		private System.Windows.Forms.Button backupToolButton;
	}
}