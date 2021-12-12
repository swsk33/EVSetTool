
namespace Swsk33.EVTools.Dialog
{
	partial class ManagePathDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePathDialog));
			this.pathContentLabel = new System.Windows.Forms.Label();
			this.pathContentValue = new System.Windows.Forms.ListBox();
			this.save = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.up = new System.Windows.Forms.Button();
			this.down = new System.Windows.Forms.Button();
			this.remove = new System.Windows.Forms.Button();
			this.add = new System.Windows.Forms.Button();
			this.edit = new System.Windows.Forms.Button();
			this.buttonToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.applyTip = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pathContentLabel
			// 
			this.pathContentLabel.AutoSize = true;
			this.pathContentLabel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pathContentLabel.Location = new System.Drawing.Point(18, 18);
			this.pathContentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.pathContentLabel.Name = "pathContentLabel";
			this.pathContentLabel.Size = new System.Drawing.Size(84, 15);
			this.pathContentLabel.TabIndex = 0;
			this.pathContentLabel.Text = "Path内容：";
			// 
			// pathContentValue
			// 
			this.pathContentValue.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pathContentValue.FormattingEnabled = true;
			this.pathContentValue.HorizontalScrollbar = true;
			this.pathContentValue.IntegralHeight = false;
			this.pathContentValue.ItemHeight = 14;
			this.pathContentValue.Location = new System.Drawing.Point(21, 45);
			this.pathContentValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pathContentValue.Name = "pathContentValue";
			this.pathContentValue.Size = new System.Drawing.Size(298, 300);
			this.pathContentValue.TabIndex = 1;
			this.pathContentValue.DoubleClick += new System.EventHandler(this.pathContentValue_DoubleClick);
			// 
			// save
			// 
			this.save.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.save.Location = new System.Drawing.Point(80, 362);
			this.save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(54, 25);
			this.save.TabIndex = 2;
			this.save.Text = "保存";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// cancel
			// 
			this.cancel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cancel.Location = new System.Drawing.Point(206, 362);
			this.cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(54, 25);
			this.cancel.TabIndex = 2;
			this.cancel.Text = "取消";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// up
			// 
			this.up.Location = new System.Drawing.Point(322, 48);
			this.up.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.up.Name = "up";
			this.up.Size = new System.Drawing.Size(22, 24);
			this.up.TabIndex = 3;
			this.up.Text = "▲";
			this.up.UseVisualStyleBackColor = true;
			this.up.Click += new System.EventHandler(this.up_Click);
			// 
			// down
			// 
			this.down.Location = new System.Drawing.Point(322, 78);
			this.down.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.down.Name = "down";
			this.down.Size = new System.Drawing.Size(22, 24);
			this.down.TabIndex = 3;
			this.down.Text = "▼";
			this.down.UseVisualStyleBackColor = true;
			this.down.Click += new System.EventHandler(this.down_Click);
			// 
			// remove
			// 
			this.remove.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.remove.Location = new System.Drawing.Point(322, 106);
			this.remove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.remove.Name = "remove";
			this.remove.Size = new System.Drawing.Size(22, 24);
			this.remove.TabIndex = 3;
			this.remove.Text = "x";
			this.remove.UseVisualStyleBackColor = true;
			this.remove.Click += new System.EventHandler(this.remove_Click);
			// 
			// add
			// 
			this.add.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.add.Location = new System.Drawing.Point(322, 135);
			this.add.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(22, 24);
			this.add.TabIndex = 3;
			this.add.Text = "+";
			this.add.UseVisualStyleBackColor = true;
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// edit
			// 
			this.edit.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edit.Location = new System.Drawing.Point(322, 164);
			this.edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.edit.Name = "edit";
			this.edit.Size = new System.Drawing.Size(22, 24);
			this.edit.TabIndex = 3;
			this.edit.Text = "✎";
			this.edit.UseVisualStyleBackColor = true;
			this.edit.Click += new System.EventHandler(this.edit_Click);
			// 
			// applyTip
			// 
			this.applyTip.AutoSize = true;
			this.applyTip.ForeColor = System.Drawing.Color.Red;
			this.applyTip.Location = new System.Drawing.Point(5, 394);
			this.applyTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.applyTip.Name = "applyTip";
			this.applyTip.Size = new System.Drawing.Size(83, 12);
			this.applyTip.TabIndex = 4;
			this.applyTip.Text = "应用更改中...";
			this.applyTip.Visible = false;
			// 
			// ManagePathForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 411);
			this.Controls.Add(this.applyTip);
			this.Controls.Add(this.edit);
			this.Controls.Add(this.add);
			this.Controls.Add(this.remove);
			this.Controls.Add(this.down);
			this.Controls.Add(this.up);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.save);
			this.Controls.Add(this.pathContentValue);
			this.Controls.Add(this.pathContentLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManagePathForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "管理Path变量";
			this.Load += new System.EventHandler(this.ManagePathForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label pathContentLabel;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button up;
		private System.Windows.Forms.Button down;
		private System.Windows.Forms.Button remove;
		private System.Windows.Forms.Button add;
		private System.Windows.Forms.Button edit;
		public System.Windows.Forms.ListBox pathContentValue;
		private System.Windows.Forms.ToolTip buttonToolTip;
		private System.Windows.Forms.Label applyTip;
	}
}