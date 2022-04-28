namespace Swsk33.EVTools.Dialog
{
	partial class UtilitiesDialog
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilitiesDialog));
			this.replaceSystemRoot = new System.Windows.Forms.Button();
			this.formatPathValue = new System.Windows.Forms.Button();
			this.removeDuplicate = new System.Windows.Forms.Button();
			this.processTipLabel = new System.Windows.Forms.Label();
			this.buttonToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipLabel = new System.Windows.Forms.Label();
			this.removeNotExist = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// replaceSystemRoot
			// 
			this.replaceSystemRoot.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.replaceSystemRoot.Location = new System.Drawing.Point(12, 32);
			this.replaceSystemRoot.Name = "replaceSystemRoot";
			this.replaceSystemRoot.Size = new System.Drawing.Size(218, 29);
			this.replaceSystemRoot.TabIndex = 0;
			this.replaceSystemRoot.Text = "将Path的系统路径改为系统引用";
			this.replaceSystemRoot.UseVisualStyleBackColor = true;
			this.replaceSystemRoot.Click += new System.EventHandler(this.replaceSystemRoot_Click);
			// 
			// formatPathValue
			// 
			this.formatPathValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.formatPathValue.Location = new System.Drawing.Point(12, 68);
			this.formatPathValue.Name = "formatPathValue";
			this.formatPathValue.Size = new System.Drawing.Size(218, 29);
			this.formatPathValue.TabIndex = 0;
			this.formatPathValue.Text = "格式化Path环境变量";
			this.formatPathValue.UseVisualStyleBackColor = true;
			this.formatPathValue.Click += new System.EventHandler(this.formatPathValue_Click);
			// 
			// removeDuplicate
			// 
			this.removeDuplicate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.removeDuplicate.Location = new System.Drawing.Point(12, 104);
			this.removeDuplicate.Name = "removeDuplicate";
			this.removeDuplicate.Size = new System.Drawing.Size(218, 29);
			this.removeDuplicate.TabIndex = 0;
			this.removeDuplicate.Text = "去除Path环境变量中的重复值";
			this.removeDuplicate.UseVisualStyleBackColor = true;
			this.removeDuplicate.Click += new System.EventHandler(this.removeDuplicate_Click);
			// 
			// processTipLabel
			// 
			this.processTipLabel.AutoSize = true;
			this.processTipLabel.ForeColor = System.Drawing.Color.Blue;
			this.processTipLabel.Location = new System.Drawing.Point(7, 181);
			this.processTipLabel.Name = "processTipLabel";
			this.processTipLabel.Size = new System.Drawing.Size(95, 12);
			this.processTipLabel.TabIndex = 1;
			this.processTipLabel.Text = "正在执行操作...";
			this.processTipLabel.Visible = false;
			// 
			// toolTipLabel
			// 
			this.toolTipLabel.AutoSize = true;
			this.toolTipLabel.Location = new System.Drawing.Point(27, 10);
			this.toolTipLabel.Name = "toolTipLabel";
			this.toolTipLabel.Size = new System.Drawing.Size(185, 12);
			this.toolTipLabel.TabIndex = 2;
			this.toolTipLabel.Text = "把鼠标放在按钮上以显示详细功能";
			// 
			// removeNotExist
			// 
			this.removeNotExist.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.removeNotExist.Location = new System.Drawing.Point(12, 139);
			this.removeNotExist.Name = "removeNotExist";
			this.removeNotExist.Size = new System.Drawing.Size(218, 29);
			this.removeNotExist.TabIndex = 0;
			this.removeNotExist.Text = "去除Path环境变量中不存在的路径";
			this.removeNotExist.UseVisualStyleBackColor = true;
			this.removeNotExist.Click += new System.EventHandler(this.removeNotExist_Click);
			// 
			// UtilitiesDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(240, 201);
			this.Controls.Add(this.toolTipLabel);
			this.Controls.Add(this.processTipLabel);
			this.Controls.Add(this.removeNotExist);
			this.Controls.Add(this.removeDuplicate);
			this.Controls.Add(this.formatPathValue);
			this.Controls.Add(this.replaceSystemRoot);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UtilitiesDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "实用工具";
			this.Load += new System.EventHandler(this.UtilitiesDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button replaceSystemRoot;
		private System.Windows.Forms.Button formatPathValue;
		private System.Windows.Forms.Button removeDuplicate;
		private System.Windows.Forms.Label processTipLabel;
		private System.Windows.Forms.ToolTip buttonToolTip;
		private System.Windows.Forms.Label toolTipLabel;
		private System.Windows.Forms.Button removeNotExist;
	}
}