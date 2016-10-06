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
            this._tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXPLAIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STARTPOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDPOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REASON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this._tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // _tabControl
            // 
            this._tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tabControl.Controls.Add(this.tabPage1);
            this._tabControl.Controls.Add(this.tabPage2);
            this._tabControl.Controls.Add(this.tabPage3);
            this._tabControl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._tabControl.Location = new System.Drawing.Point(0, 28);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1390, 560);
            this._tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1382, 532);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "运行信息总览";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1382, 532);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "报警信息显示";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1382, 532);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "预警设置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TIME,
            this.NUMBER,
            this.EXPLAIN,
            this.STARTPOS,
            this.ENDPOS,
            this.CODE,
            this.REASON,
            this.STATUS});
            this.dataGridView1.Location = new System.Drawing.Point(0, 590);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(945, 201);
            this.dataGridView1.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.HeaderText = "报警ID";
            this.ID.Name = "ID";
            // 
            // TIME
            // 
            this.TIME.HeaderText = "报警时间";
            this.TIME.Name = "TIME";
            // 
            // NUMBER
            // 
            this.NUMBER.HeaderText = "线路编号";
            this.NUMBER.Name = "NUMBER";
            // 
            // EXPLAIN
            // 
            this.EXPLAIN.HeaderText = "线路说明";
            this.EXPLAIN.Name = "EXPLAIN";
            // 
            // STARTPOS
            // 
            this.STARTPOS.HeaderText = "起始位置";
            this.STARTPOS.Name = "STARTPOS";
            // 
            // ENDPOS
            // 
            this.ENDPOS.HeaderText = "结束位置";
            this.ENDPOS.Name = "ENDPOS";
            // 
            // CODE
            // 
            this.CODE.HeaderText = "类型码";
            this.CODE.Name = "CODE";
            // 
            // REASON
            // 
            this.REASON.HeaderText = "报警原因说明";
            this.REASON.Name = "REASON";
            // 
            // STATUS
            // 
            this.STATUS.HeaderText = "处理状态";
            this.STATUS.Name = "STATUS";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox1.Location = new System.Drawing.Point(0, 611);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(41, 180);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "      实时报警";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(951, 594);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 197);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "实时报警信息处理";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "查看详情";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(145, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "单项处理";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "报警输出";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(145, 124);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 38);
            this.button4.TabIndex = 3;
            this.button4.Text = "全部处理";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(1218, 594);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 197);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "安全状态";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1390, 905);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "光纤周界安防在线监测系统";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this._tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXPLAIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn STARTPOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDPOS;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REASON;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

