using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Swsk33.EVTools.Dialog
{
	partial class MsysEnvironmentDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsysEnvironmentDialog));
			this.MsysEnvTip = new System.Windows.Forms.Label();
			this.msysOrderTip = new System.Windows.Forms.Label();
			this.msysSelectTip = new System.Windows.Forms.Label();
			this.msysEnvList = new System.Windows.Forms.ListView();
			this.environmentEnabled = new System.Windows.Forms.ColumnHeader();
			this.environmentName = new System.Windows.Forms.ColumnHeader();
			this.ok = new System.Windows.Forms.Button();
			this.down = new System.Windows.Forms.Button();
			this.up = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// MsysEnvTip
			// 
			this.MsysEnvTip.AutoSize = true;
			this.MsysEnvTip.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MsysEnvTip.Location = new System.Drawing.Point(12, 15);
			this.MsysEnvTip.Name = "MsysEnvTip";
			this.MsysEnvTip.Size = new System.Drawing.Size(266, 14);
			this.MsysEnvTip.TabIndex = 0;
			this.MsysEnvTip.Text = "设定要添加到Path环境变量中的Msys2环境";
			// 
			// msysOrderTip
			// 
			this.msysOrderTip.AutoSize = true;
			this.msysOrderTip.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.msysOrderTip.ForeColor = System.Drawing.Color.Blue;
			this.msysOrderTip.Location = new System.Drawing.Point(12, 39);
			this.msysOrderTip.Name = "msysOrderTip";
			this.msysOrderTip.Size = new System.Drawing.Size(176, 13);
			this.msysOrderTip.TabIndex = 0;
			this.msysOrderTip.Text = "上下键调整每个环境的优先级";
			// 
			// msysSelectTip
			// 
			this.msysSelectTip.AutoSize = true;
			this.msysSelectTip.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.msysSelectTip.ForeColor = System.Drawing.Color.Fuchsia;
			this.msysSelectTip.Location = new System.Drawing.Point(12, 56);
			this.msysSelectTip.Name = "msysSelectTip";
			this.msysSelectTip.Size = new System.Drawing.Size(243, 13);
			this.msysSelectTip.TabIndex = 0;
			this.msysSelectTip.Text = "只有勾选启用的环境才会被加入到Path中";
			// 
			// msysEnvList
			// 
			this.msysEnvList.CheckBoxes = true;
			this.msysEnvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.environmentEnabled, this.environmentName });
			this.msysEnvList.Font = new System.Drawing.Font("等线", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.msysEnvList.FullRowSelect = true;
			this.msysEnvList.HideSelection = false;
			this.msysEnvList.Location = new System.Drawing.Point(12, 84);
			this.msysEnvList.MultiSelect = false;
			this.msysEnvList.Name = "msysEnvList";
			this.msysEnvList.Size = new System.Drawing.Size(266, 200);
			this.msysEnvList.TabIndex = 1;
			this.msysEnvList.UseCompatibleStateImageBehavior = false;
			this.msysEnvList.View = System.Windows.Forms.View.Details;
			// 
			// environmentEnabled
			// 
			this.environmentEnabled.DisplayIndex = 1;
			this.environmentEnabled.Text = "启用";
			this.environmentEnabled.Width = 56;
			// 
			// environmentName
			// 
			this.environmentName.DisplayIndex = 0;
			this.environmentName.Text = "环境名称";
			this.environmentName.Width = 116;
			// 
			// ok
			// 
			this.ok.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.ok.Location = new System.Drawing.Point(113, 301);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 28);
			this.ok.TabIndex = 2;
			this.ok.Text = "确定";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// down
			// 
			this.down.Location = new System.Drawing.Point(286, 114);
			this.down.Margin = new System.Windows.Forms.Padding(2);
			this.down.Name = "down";
			this.down.Size = new System.Drawing.Size(22, 24);
			this.down.TabIndex = 4;
			this.down.Text = "▼";
			this.down.UseVisualStyleBackColor = true;
			this.down.Click += new System.EventHandler(this.down_Click);
			// 
			// up
			// 
			this.up.Location = new System.Drawing.Point(286, 84);
			this.up.Margin = new System.Windows.Forms.Padding(2);
			this.up.Name = "up";
			this.up.Size = new System.Drawing.Size(22, 24);
			this.up.TabIndex = 5;
			this.up.Text = "▲";
			this.up.UseVisualStyleBackColor = true;
			this.up.Click += new System.EventHandler(this.up_Click);
			// 
			// MsysEnvironmentDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 341);
			this.Controls.Add(this.down);
			this.Controls.Add(this.up);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.msysEnvList);
			this.Controls.Add(this.msysSelectTip);
			this.Controls.Add(this.msysOrderTip);
			this.Controls.Add(this.MsysEnvTip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MsysEnvironmentDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "启用的Msys2环境";
			this.Load += new System.EventHandler(this.MsysEnvironmentDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Button down;
		private System.Windows.Forms.Button up;

		private System.Windows.Forms.Button ok;

		private System.Windows.Forms.ColumnHeader environmentEnabled;

		private System.Windows.Forms.ColumnHeader environmentName;

		private System.Windows.Forms.ListView msysEnvList;

		private System.Windows.Forms.Label msysOrderTip;

		private System.Windows.Forms.Label msysSelectTip;

		private System.Windows.Forms.Label MsysEnvTip;

		#endregion
	}
}