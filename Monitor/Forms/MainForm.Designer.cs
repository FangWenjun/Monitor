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
			this.components = new System.ComponentModel.Container();
			WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin5 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
			WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin5 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient13 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient29 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin5 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient5 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient30 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient14 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient31 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient5 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient32 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient33 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient15 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient34 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient35 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
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
			dockPanelGradient13.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient13.StartColor = System.Drawing.SystemColors.ControlLight;
			autoHideStripSkin5.DockStripGradient = dockPanelGradient13;
			tabGradient29.EndColor = System.Drawing.SystemColors.Control;
			tabGradient29.StartColor = System.Drawing.SystemColors.Control;
			tabGradient29.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			autoHideStripSkin5.TabGradient = tabGradient29;
			autoHideStripSkin5.TextFont = new System.Drawing.Font("微软雅黑", 9F);
			dockPanelSkin5.AutoHideStripSkin = autoHideStripSkin5;
			tabGradient30.EndColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient30.StartColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient30.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient5.ActiveTabGradient = tabGradient30;
			dockPanelGradient14.EndColor = System.Drawing.SystemColors.Control;
			dockPanelGradient14.StartColor = System.Drawing.SystemColors.Control;
			dockPaneStripGradient5.DockStripGradient = dockPanelGradient14;
			tabGradient31.EndColor = System.Drawing.SystemColors.ControlLight;
			tabGradient31.StartColor = System.Drawing.SystemColors.ControlLight;
			tabGradient31.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient5.InactiveTabGradient = tabGradient31;
			dockPaneStripSkin5.DocumentGradient = dockPaneStripGradient5;
			dockPaneStripSkin5.TextFont = new System.Drawing.Font("微软雅黑", 9F);
			tabGradient32.EndColor = System.Drawing.SystemColors.ActiveCaption;
			tabGradient32.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient32.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
			tabGradient32.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient5.ActiveCaptionGradient = tabGradient32;
			tabGradient33.EndColor = System.Drawing.SystemColors.Control;
			tabGradient33.StartColor = System.Drawing.SystemColors.Control;
			tabGradient33.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripToolWindowGradient5.ActiveTabGradient = tabGradient33;
			dockPanelGradient15.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient15.StartColor = System.Drawing.SystemColors.ControlLight;
			dockPaneStripToolWindowGradient5.DockStripGradient = dockPanelGradient15;
			tabGradient34.EndColor = System.Drawing.SystemColors.InactiveCaption;
			tabGradient34.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient34.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
			tabGradient34.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
			dockPaneStripToolWindowGradient5.InactiveCaptionGradient = tabGradient34;
			tabGradient35.EndColor = System.Drawing.Color.Transparent;
			tabGradient35.StartColor = System.Drawing.Color.Transparent;
			tabGradient35.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			dockPaneStripToolWindowGradient5.InactiveTabGradient = tabGradient35;
			dockPaneStripSkin5.ToolWindowGradient = dockPaneStripToolWindowGradient5;
			dockPanelSkin5.DockPaneStripSkin = dockPaneStripSkin5;
			this.dockPanel1.Skin = dockPanelSkin5;
			this.dockPanel1.TabIndex = 7;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10000;
			this.timer1.Tick += new System.EventHandler(this.timerTick);
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
		private System.Windows.Forms.Timer timer1;
	}
}

