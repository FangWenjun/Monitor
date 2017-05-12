namespace Monitor
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
			WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuControl = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStartMonitor = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStopMonitor = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCloseSystem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWarnSetting = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDisturbMonitor = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRunSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDeviceManage = new System.Windows.Forms.ToolStripMenuItem();
			this.设备连接状况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuControl,
            this.mnuWarnSetting,
            this.mnuRunSetup,
            this.mnuDeviceManage,
            this.mnuHelp});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(324, 25);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnuControl
			// 
			this.mnuControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartMonitor,
            this.mnuStopMonitor,
            this.mnuCloseSystem});
			this.mnuControl.Name = "mnuControl";
			this.mnuControl.Size = new System.Drawing.Size(68, 21);
			this.mnuControl.Text = "监测控制";
			// 
			// mnuStartMonitor
			// 
			this.mnuStartMonitor.Name = "mnuStartMonitor";
			this.mnuStartMonitor.Size = new System.Drawing.Size(124, 22);
			this.mnuStartMonitor.Text = "启动监测";
			// 
			// mnuStopMonitor
			// 
			this.mnuStopMonitor.Name = "mnuStopMonitor";
			this.mnuStopMonitor.Size = new System.Drawing.Size(124, 22);
			this.mnuStopMonitor.Text = "停止监测";
			// 
			// mnuCloseSystem
			// 
			this.mnuCloseSystem.Name = "mnuCloseSystem";
			this.mnuCloseSystem.Size = new System.Drawing.Size(124, 22);
			this.mnuCloseSystem.Text = "关闭系统";
			// 
			// mnuWarnSetting
			// 
			this.mnuWarnSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDisturbMonitor});
			this.mnuWarnSetting.Name = "mnuWarnSetting";
			this.mnuWarnSetting.Size = new System.Drawing.Size(68, 21);
			this.mnuWarnSetting.Text = "预警设置";
			// 
			// mnuDisturbMonitor
			// 
			this.mnuDisturbMonitor.Name = "mnuDisturbMonitor";
			this.mnuDisturbMonitor.Size = new System.Drawing.Size(124, 22);
			this.mnuDisturbMonitor.Text = "振动监测";
			// 
			// mnuRunSetup
			// 
			this.mnuRunSetup.Name = "mnuRunSetup";
			this.mnuRunSetup.Size = new System.Drawing.Size(68, 21);
			this.mnuRunSetup.Text = "运行设置";
			// 
			// mnuDeviceManage
			// 
			this.mnuDeviceManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备连接状况ToolStripMenuItem});
			this.mnuDeviceManage.Name = "mnuDeviceManage";
			this.mnuDeviceManage.Size = new System.Drawing.Size(68, 21);
			this.mnuDeviceManage.Text = "设备管理";
			// 
			// 设备连接状况ToolStripMenuItem
			// 
			this.设备连接状况ToolStripMenuItem.Name = "设备连接状况ToolStripMenuItem";
			this.设备连接状况ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.设备连接状况ToolStripMenuItem.Text = "设备连接状况";
			// 
			// mnuHelp
			// 
			this.mnuHelp.Name = "mnuHelp";
			this.mnuHelp.Size = new System.Drawing.Size(44, 21);
			this.mnuHelp.Text = "帮助";
			// 
			// dockPanel1
			// 
			this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
			this.dockPanel1.ImeMode = System.Windows.Forms.ImeMode.On;
			this.dockPanel1.Location = new System.Drawing.Point(12, 28);
			this.dockPanel1.Name = "dockPanel1";
			this.dockPanel1.Size = new System.Drawing.Size(1880, 517);
			dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
			autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
			tabGradient1.EndColor = System.Drawing.SystemColors.Control;
			tabGradient1.StartColor = System.Drawing.SystemColors.Control;
			tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			autoHideStripSkin1.TabGradient = tabGradient1;
			autoHideStripSkin1.TextFont = new System.Drawing.Font("微软雅黑", 9F);
			dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
			tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
			dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
			dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
			dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
			tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
			dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
			dockPaneStripSkin1.TextFont = new System.Drawing.Font("微软雅黑", 9F);
			tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
			tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
			tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
			tabGradient5.EndColor = System.Drawing.SystemColors.Control;
			tabGradient5.StartColor = System.Drawing.SystemColors.Control;
			tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
			dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
			dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
			tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
			tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
			tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
			dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
			tabGradient7.EndColor = System.Drawing.Color.Transparent;
			tabGradient7.StartColor = System.Drawing.Color.Transparent;
			tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
			dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
			dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
			this.dockPanel1.Skin = dockPanelSkin1;
			this.dockPanel1.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.AutoScroll = true;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.ClientSize = new System.Drawing.Size(1904, 1042);
			this.Controls.Add(this.dockPanel1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "光纤周界安防在线监测系统";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.System_Closing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuControl;
        private System.Windows.Forms.ToolStripMenuItem mnuWarnSetting;
        private System.Windows.Forms.ToolStripMenuItem mnuRunSetup;
        private System.Windows.Forms.ToolStripMenuItem mnuDeviceManage;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuStartMonitor;
        private System.Windows.Forms.ToolStripMenuItem mnuStopMonitor;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuDisturbMonitor;
        private System.Windows.Forms.ToolStripMenuItem 设备连接状况ToolStripMenuItem;
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
	}
}

