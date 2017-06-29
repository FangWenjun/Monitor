namespace ToolBar
{
	partial class ToolControl
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
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this._toolStripLayer = new System.Windows.Forms.ToolStrip();
            this.toolPan = new System.Windows.Forms.ToolStripButton();
            this.toolZoomToLayer = new System.Windows.Forms.ToolStripButton();
            this.toolClick = new System.Windows.Forms.ToolStripButton();
            this.toolHelp = new System.Windows.Forms.ToolStripButton();
            this._toolStripLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolStripLayer
            // 
            this._toolStripLayer.AutoSize = false;
            this._toolStripLayer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._toolStripLayer.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStripLayer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._toolStripLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPan,
            this.toolZoomToLayer,
            this.toolClick,
            this.toolHelp});
            this._toolStripLayer.Location = new System.Drawing.Point(0, 0);
            this._toolStripLayer.Name = "_toolStripLayer";
            this._toolStripLayer.Size = new System.Drawing.Size(122, 28);
            this._toolStripLayer.TabIndex = 0;
            // 
            // toolPan
            // 
            this.toolPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPan.Image = global::Monitor.Properties.Resources.pan1;
            this.toolPan.Name = "toolPan";
            this.toolPan.Size = new System.Drawing.Size(23, 25);
            this.toolPan.ToolTipText = "拖动\\滚轮放大缩小";
            // 
            // toolZoomToLayer
            // 
            this.toolZoomToLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomToLayer.Image = global::Monitor.Properties.Resources.zoom_layer;
            this.toolZoomToLayer.Name = "toolZoomToLayer";
            this.toolZoomToLayer.Size = new System.Drawing.Size(23, 25);
            this.toolZoomToLayer.ToolTipText = "还原地图大小";
            // 
            // toolClick
            // 
            this.toolClick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClick.Image = global::Monitor.Properties.Resources.click;
            this.toolClick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClick.Name = "toolClick";
            this.toolClick.Size = new System.Drawing.Size(23, 25);
            this.toolClick.ToolTipText = "鼠标点击模式";
            // 
            // toolHelp
            // 
            this.toolHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolHelp.Image = global::Monitor.Properties.Resources.help;
            this.toolHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolHelp.Name = "toolHelp";
            this.toolHelp.Size = new System.Drawing.Size(23, 25);
            this.toolHelp.Text = "toolStripButton1";
            this.toolHelp.ToolTipText = "帮助";
            // 
            // ToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._toolStripLayer);
            this.Name = "ToolControl";
            this.Size = new System.Drawing.Size(122, 28);
            this._toolStripLayer.ResumeLayout(false);
            this._toolStripLayer.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolStripButton toolZoomToLayer;
		private System.Windows.Forms.ToolStripButton toolPan;
		private System.Windows.Forms.ToolStrip _toolStripLayer;
		private System.Windows.Forms.ToolStripButton toolClick;
		private System.Windows.Forms.ToolStripButton toolHelp;
	}
}
