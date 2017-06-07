namespace File
{
    partial class File
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this._toolStripLayer = new System.Windows.Forms.ToolStrip();
			this.toolZoomIn = new System.Windows.Forms.ToolStripButton();
			this.toolZoomOut = new System.Windows.Forms.ToolStripButton();
			this.toolZoomToLayer = new System.Windows.Forms.ToolStripButton();
			this.toolPan = new System.Windows.Forms.ToolStripButton();
			this._toolStripLayer.SuspendLayout();
			this.SuspendLayout();
			// 
			// _toolStripLayer
			// 
			this._toolStripLayer.AutoSize = false;
			this._toolStripLayer.Dock = System.Windows.Forms.DockStyle.None;
			this._toolStripLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolZoomIn,
            this.toolZoomOut,
            this.toolZoomToLayer,
            this.toolPan});
			this._toolStripLayer.Location = new System.Drawing.Point(0, 0);
			this._toolStripLayer.Name = "_toolStripLayer";
			this._toolStripLayer.Size = new System.Drawing.Size(119, 50);
			this._toolStripLayer.TabIndex = 0;
			// 
			// toolZoomIn
			// 
			this.toolZoomIn.Image = global::Monitor.Properties.Resources.zoom_in;
			this.toolZoomIn.Name = "toolZoomIn";
			this.toolZoomIn.Size = new System.Drawing.Size(23, 47);
			// 
			// toolZoomOut
			// 
			this.toolZoomOut.Image = global::Monitor.Properties.Resources.zoom_out;
			this.toolZoomOut.Name = "toolZoomOut";
			this.toolZoomOut.Size = new System.Drawing.Size(23, 47);
			// 
			// toolZoomToLayer
			// 
			this.toolZoomToLayer.Image = global::Monitor.Properties.Resources.zoom_layer;
			this.toolZoomToLayer.Name = "toolZoomToLayer";
			this.toolZoomToLayer.Size = new System.Drawing.Size(23, 47);
			// 
			// toolPan
			// 
			this.toolPan.Image = global::Monitor.Properties.Resources.pan1;
			this.toolPan.Name = "toolPan";
			this.toolPan.Size = new System.Drawing.Size(23, 47);
			// 
			// File
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._toolStripLayer);
			this.Name = "File";
			this.Size = new System.Drawing.Size(109, 50);
			this._toolStripLayer.ResumeLayout(false);
			this._toolStripLayer.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripButton toolZoomIn;
        private System.Windows.Forms.ToolStripButton toolZoomOut;
        private System.Windows.Forms.ToolStripButton toolZoomToLayer;
        private System.Windows.Forms.ToolStripButton toolPan;
        private System.Windows.Forms.ToolStrip _toolStripLayer;

    }
}
