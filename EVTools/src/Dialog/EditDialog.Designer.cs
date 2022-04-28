
namespace Swsk33.EVTools.Dialog
{
	partial class EditDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDialog));
			this.editValue = new System.Windows.Forms.TextBox();
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// editValue
			// 
			this.editValue.Location = new System.Drawing.Point(34, 30);
			this.editValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.editValue.Name = "editValue";
			this.editValue.Size = new System.Drawing.Size(253, 21);
			this.editValue.TabIndex = 0;
			this.editValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editValue_KeyDown);
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(65, 70);
			this.ok.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(57, 22);
			this.ok.TabIndex = 1;
			this.ok.Text = "确定";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(194, 70);
			this.cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(57, 22);
			this.cancel.TabIndex = 1;
			this.cancel.Text = "取消";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// EditDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(320, 115);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.editValue);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "编辑该条目";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox editValue;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
	}
}