namespace Swsk33.EVTools.Dialog
{
	partial class UpdateDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDialog));
			this.ok = new System.Windows.Forms.Button();
			this.text = new System.Windows.Forms.Label();
			this.tip = new System.Windows.Forms.Label();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.ok.Location = new System.Drawing.Point(53, 83);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 28);
			this.ok.TabIndex = 0;
			this.ok.Text = "确定";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// text
			// 
			this.text.AutoSize = true;
			this.text.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.text.ForeColor = System.Drawing.Color.Indigo;
			this.text.Location = new System.Drawing.Point(54, 18);
			this.text.Name = "text";
			this.text.Size = new System.Drawing.Size(215, 16);
			this.text.TabIndex = 1;
			this.text.Text = "发现新版本！是否前往下载？";
			// 
			// tip
			// 
			this.tip.AutoSize = true;
			this.tip.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tip.ForeColor = System.Drawing.Color.Blue;
			this.tip.Location = new System.Drawing.Point(37, 49);
			this.tip.Name = "tip";
			this.tip.Size = new System.Drawing.Size(252, 14);
			this.tip.TabIndex = 1;
			this.tip.Text = "推荐下载新版本，新版本通常会修复bug";
			// 
			// cancel
			// 
			this.cancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cancel.Location = new System.Drawing.Point(190, 83);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 28);
			this.cancel.TabIndex = 0;
			this.cancel.Text = "取消";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// UpdateDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 128);
			this.Controls.Add(this.tip);
			this.Controls.Add(this.text);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdateDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "更新提示";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Label text;
		private System.Windows.Forms.Label tip;
		private System.Windows.Forms.Button cancel;
	}
}