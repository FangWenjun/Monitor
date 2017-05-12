using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitor.Classes;
using WeifenLuo.WinFormsUI.Docking;
using Monitor.Map;
using Monitor.DataTransfer;

namespace Monitor
{
    public partial class MainForm : DockContent
    {
        /// <summary>
        /// 实例化AppDispatcher类为_dispatcher
        /// </summary>
        private AppDispatcher _dispatcher = new AppDispatcher();
		private MapForm _mapForm = null;

		/// <summary>
		/// 主窗口句柄
		/// </summary>
        private static MainForm _form = null;

        /// <summary>
        /// _dispatcher属性
        /// </summary>
        internal AppDispatcher Dispatcher
        {
            get { return _dispatcher; }
        }
        

        public MainForm()
        {
            InitializeComponent();			
            _form = this; //1、主窗口句柄赋值
            Init();	 //2、主窗口初始化
        }

        /// <summary>
        ///主窗体属性 
        /// </summary>
        public static MainForm MainFormAttri
        {									
            get { return _form; }
        }

      
     
    
	

		/// <summary>
		/// 主窗口初始化
		/// </summary>
        private void Init()
        {
			this.InitDockLayout();
            this.InitMenus();//1、初始化主窗口中的所有按钮
            this.InitUdp();
     

     
        }

		private void InitDockLayout()
		{
			
			_mapForm = new MapForm();
			_mapForm.Show(dockPanel1, DockState.Document);
		//	_mapForm.SelectionChanged += (s, e) => RefreshUI();
			_mapForm.CloseButton = false;
			_mapForm.Activate();

			string[] str = { @"D:\Monitor\Monitor\data\test4.shp" };

			MapLayer.AddLayer(str);

			DataTable LineData = MySqlData.ReadData(GlobalVar.SqlConn,"Point");

			//GisPoint.connectToDB(App.dbname);
			//GisPoint.readData();
			//GisPoint.SortList();

		//	MapDraw.LinePattern(App.m_PointList[0].X,App.m_PointList[0].Y,App.m_PointList[10].X,App.m_PointList[10].Y);
		}

		private void InitMenus()
        {
            //1、初始化菜单栏“监测控制”下所有按钮
            Dispatcher.InitMenu(mnuControl.DropDownItems);

            //2、初始化菜单栏“预警设置”下所有按钮 
            Dispatcher.InitMenu(mnuWarnSetting.DropDownItems);

            //3、初始化菜单栏“运行设置”下所有按钮
            Dispatcher.InitMenu(mnuRunSetup.DropDownItems);

            //4、初始化菜单栏“设备管理”下所有按钮
            Dispatcher.InitMenu(mnuDeviceManage.DropDownItems);

            //5、初始化菜单栏“帮助”下所有按钮
            Dispatcher.InitMenu(mnuHelp.DropDownItems);

        

        }

  


        /// <summary>
        /// 初始化udp
        /// </summary>
        private void InitUdp()
        {
            UDPClient udpRecieve = new UDPClient();
        }

		private void System_Closing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = MessageBox.Show("是否确认关闭？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			e.Cancel = result != DialogResult.Yes;
		}
	}
}
