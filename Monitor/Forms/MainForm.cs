using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Monitor.Classes;
using WeifenLuo.WinFormsUI.Docking;
using Monitor.Map;			  
using Monitor.DataTransfer;
using System.IO;
using AxMapWinGIS;
using MapWinGIS;
using Monitor.Core;


namespace Monitor
{
    public partial class MainForm : DockContent
    {
        /// <summary>
        /// 实例化AppDispatcher类为_dispatcher
        /// </summary>
        private AppDispatcher _dispatcher = new AppDispatcher();
		private ControlMapForm _mapForm = null;
		public AISData ais = null;
		public classDrawLine drawLine ;
		public classDrawPoint drawPoint;

		public MapLayer mapLayer;
		public classDrawPoint drawPoint_Ais;

		private int MainLayerHandle;   //底图句柄（需要缩放的地图级别）

		private PointSet pointSet;
		private List<Shapefile> sf_mouseMove = new List<Shapefile>();
		private List<Shapefile> sf_mouseDown = new List<Shapefile>();






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

		public ControlMapForm MapForm
		{
			get { return _mapForm; }
			set { _mapForm = value; }
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
         //   this.InitUdp();
     

     
        }

		private void InitDockLayout()
		{
			
			_mapForm = new ControlMapForm();
			_mapForm.Text = "GIS地图";
			_mapForm.Show(dockPanel1, DockState.Document);
			_mapForm.CloseButton = false;
			_mapForm.UiInitAndInvoke();
			_mapForm.Activate();
			

			

			MouseMoveOperator mouseMoveOperate;
			MouseDownOperator mouseDownOperate;

			#region	加载gis地图
			string[] str = { @"D:\光纤传感监测系统\Monitor\Monitor\data\底图.shp",@"D:\光纤传感监测系统\Monitor\Monitor\data\省界WGS 84.shp" };
			mapLayer = new MapLayer();
			MainLayerHandle = mapLayer.AddLayer(_mapForm.Map,str);
			#endregion


			//	_mapForm.Map.ZoomToMaxExtents();
			//	_mapForm.Map.ZoomToLayer(MainLayerHandle);




			#region	 在地图上划线
			ClassLine line = new ClassLine();
			GisPoint gisPoint = new GisPoint();
			LineSet lineSet = new LineSet(tkMapColor.Yellow, 6.0f, tkDashStyle.dsSolid);
			gisPoint.connectToDB("Data Source=" + new DirectoryInfo("../../../../").FullName +"Monitor\\Monitor\\data\\data.db");
			gisPoint.readData();
			gisPoint.InitLineData(line);
			drawLine = new classDrawLine(_mapForm.Map);
			drawLine.WriteLine(line, lineSet);
			#endregion

			#region	  在gis地图中添加ais数据
			//1、获取数据库中数据
			SqliteData sqlite = new SqliteData("Data Source=" + new DirectoryInfo("../../../../").FullName +
			"Monitor\\Monitor\\data\\data.db");
			DataTable gisData = sqlite.readData("Point");

			//2、实例化AISData类
			ais = new AISData(_mapForm.Map, gisData);
			drawPoint_Ais = new classDrawPoint(MapForm.Map);

			//3、在地图上加载ais数据
			pointSet = new PointSet("AisReal", tkDefaultPointSymbol.dpsTriangleUp, tkMapColor.Red, 16);
		//	drawPoint_Ais.CreatPoint(ais.point, pointSet);
		//	sf_mouseMove.Add(drawPoint_Ais.Shp);





			#endregion


			#region
			drawPoint = new classDrawPoint(_mapForm.Map);
			var pnt = new ClassPoint();
			pnt.x = 121.907567728461;
			pnt.y = 30.8729913928844;
			string path = new DirectoryInfo("../../../../").FullName +"Monitor\\Monitor\\data\\ship3.png";
			drawPoint.AddPicture(pnt, path);
			sf_mouseDown.Add(drawPoint.Shp);
			#endregion


			_mapForm.SfMouseMove = sf_mouseMove;
			_mapForm.SfMouseDown = sf_mouseDown;

			mouseMoveOperate = new MouseMoveOperator(Operation.AddLabel);
			mouseDownOperate = new MouseDownOperator(Operation.AddLabel);

			//传入委托
			MapForm.MouseMoveOperate = mouseMoveOperate;
			MapForm.mouseDownOperate = mouseDownOperate;


		



			








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

		private void timerTick(object sender, EventArgs e)
		{
			drawPoint_Ais.RemoveLayer();
			drawPoint_Ais.CreatPoint(ais.point, pointSet);
			sf_mouseMove.Add(drawPoint_Ais.Shp);

			

		}
	}
}
