using AxMapWinGIS;
using MapWinGIS;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Monitor.Classes;
using System.Threading;
using Monitor.DataTransfer;
using System.Data;
using Monitor.Map;
using Monitor.Core;
using System.IO;
using File;

namespace Monitor.Map
{

    public partial class MapForm : DockContent
    {

		private static MapForm _mapform = null;
		private  File.File  m_FileControl = null;


		//用于判断是否已经显示label
		private int labelFlag_MouseMove;
		private int labelFlag_MouseDown;

		//ais图层句柄
		public  int  AISHandle = -1;

		//定时器计时Flag
		private int  mapCheck = 0;

		private string[] mapPath = { @"D:\光纤传感监测系统\Monitor\Monitor\data\test4.shp" } ;

		public IAddLayer mapLayer;
		public IDrawLine drawLine ;
		public IDrawPoint drawPoint;
		public MapDraw mapDraw;
		public AISData ais = null;
		public IDrawPoint drawPoint_Ais = null;

		public MouseMoveOperator mouseMoveOperate;
		public MouseDownOperator mouseDownOperate;



		public static MapForm MapFormAttri
		{
			get { return _mapform; }
		}

		public File.File FileControl
		{
			get { return m_FileControl; }
		}

		public string[] MapPath
		{
			set
			{
				mapPath = value;
			}
		}

		public MapForm()
        {
            InitializeComponent();
			_mapform = this;

			//File控件动态加载
			m_FileControl = new File.File();
			this.Controls.Add(m_FileControl);
			m_FileControl.Location = new System.Drawing.Point(60, 10);
			m_FileControl.Size = new System.Drawing.Size(147, 50);
			//		m_FileControl.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
			m_FileControl.Dock = DockStyle.None;
			m_FileControl.BringToFront();


		}

        public AxMap Map
        {
            get { return axMap1; }
        }

		public void UiInitAndInvoke()
		{

			MapInit();
			RegisterEventHandlers();
			timerCheck.Tick += new EventHandler(checkTimer_Tick);
			timerCheck.Start();
		}



		private void MapInit()
        {
            axMap1.GrabProjectionFromData = true;
          //  axMap1.CursorMode = tkCursorMode.cmNone;
            axMap1.SendSelectBoxFinal = true;
            axMap1.SendMouseDown = true;
            axMap1.SendMouseUp = true;
            axMap1.InertiaOnPanning = tkCustomState.csAuto;
            axMap1.ShowRedrawTime = false;
            Map.Identifier.IdentifierMode = tkIdentifierMode.imSingleLayer;
            Map.Identifier.HotTracking = true;
            Map.ShapeEditor.HighlightVertices = tkLayerSelection.lsNoLayer;
            Map.ShapeEditor.SnapBehavior = tkLayerSelection.lsNoLayer;
            axMap1.Measuring.UndoButton = tkUndoShortcut.usCtrlZ;
			axMap1.Projection = tkMapProjection.PROJECTION_WGS84;
			axMap1.TileProvider = tkTileProvider.ProviderNone;  //没有任何背景图
		}


		private void RegisterEventHandlers()
		{
			axMap1.MouseMoveEvent += axMap1_MouseMoveEvent;
			axMap1.MouseDownEvent += axMap1_MouseDownEvent;
		}


		private void checkTimer_Tick(object sender, EventArgs e)
		{
			mapCheck++;
			
			if(10 ==  mapCheck)
			{
				startWork();
				Debug.Write("null, Start Check Map\n");
			}
		
		}


		private void startWork()
		{
			#region	加载gis地图
			mapLayer = new MapLayer();
			mapLayer.AddLayer(MapForm.MapFormAttri.Map, mapPath);
			#endregion

			#region	 在地图上划线
			GisPoint.connectToDB(App.dbname);
			GisPoint.readData();
			GisPoint.SortList();
			
			drawLine = new DrawLine(MapForm.MapFormAttri.Map);
			drawLine.WriteLine(App.m_PointList[0].X, App.m_PointList[0].Y,
				App.m_PointList[10].X, App.m_PointList[10].Y, -256);
			#endregion

			#region	  在gis地图中添加ais数据
			//1、获取数据库中数据
			SqliteData sqlite = new SqliteData(App.dbname);
			DataTable gisData = sqlite.readData("Point");
			mouseMoveOperate = new MouseMoveOperator(Operation.AddLabel);
		
			//2、实例化AISData类
			ais = new AISData(MapForm.MapFormAttri.Map, gisData);
			drawPoint_Ais = new DrawPoint(MapForm.MapFormAttri.Map);
			//3、在地图上加载ais数据
			PointSet pointSet = new PointSet("AisReal", tkDefaultPointSymbol.dpsTriangleUp, tkMapColor.Red, 16);
			drawPoint_Ais.CreatPoint(ais.point, pointSet);
			#endregion

			#region	在地图上加载图片
			drawPoint = new DrawPoint(MapForm.MapFormAttri.Map);
			var pnt = new MapWinGIS.Point();
			mouseDownOperate = new MouseDownOperator(Operation.AddLabel);
			pnt.x = 121.902567181871;
			pnt.y = 30.8729913928844;
			string path = new DirectoryInfo("../../../../").FullName +"Monitor\\Monitor\\data\\ship3.png";
			drawPoint.AddPicture(pnt, path);
			#endregion


		}





		private void axMap1_MouseMoveEvent(object sender, _DMapEvents_MouseMoveEvent e)
        {
			#region 显示ais数据标签详情
			Shapefile sf = drawPoint_Ais.Shp;
			if(sf != null)
			{
				Labels labels = sf.Labels;
				labels.FontSize = 15;
				labels.FontBold = true;
				labels.FrameVisible = true;
				labels.FrameType = tkLabelFrameType.lfRectangle;
				labels.AutoOffset = false;
				labels.OffsetX = 40;

				LabelCategory cat = labels.AddCategory("Red");
				cat.FontColor = 255;

				double projX = 0.0;
				double projY = 0.0;
				Map.PixelToProj(e.x, e.y, ref projX, ref projY);
				object result = null;
				var ext = new Extents();
				ext.SetBounds(projX, projY, 0.0, projX, projY, 0.0);
				if(sf.SelectShapes(ext, 0.00009, SelectMode.INTERSECTION, ref result) && (labelFlag_MouseMove == 0))
				{
					mouseMoveOperate(MapForm.MapFormAttri.ais, labels, projX, projY);	
					labelFlag_MouseMove = 1;
				}
				else
				{
					sf.Labels.Clear();
					labelFlag_MouseMove = 0;
				}
				Map.Redraw();
			}
			#endregion
		}



		private void axMap1_MouseDownEvent(object sender, _DMapEvents_MouseDownEvent e)
		{
			#region 显示ais数据标签详情
			Shapefile sf = drawPoint.Shp;
			if(sf != null)
			{
				Labels labels = sf.Labels;
				labels.FontSize = 15;
				labels.FontBold = true;
				labels.FrameVisible = true;
				labels.FrameType = tkLabelFrameType.lfRectangle;
				labels.AutoOffset = false;
				labels.OffsetX = 40;

				LabelCategory cat = labels.AddCategory("Red");
				cat.FontColor = 255;

				double projX = 0.0;
				double projY = 0.0;
				Map.PixelToProj(e.x, e.y, ref projX, ref projY);
				object result = null;
				var ext = new Extents();
				ext.SetBounds(projX-0.0004, projY - 0.0004, 0.0, projX + 0.0004, projY + 0.0004, 0.0);
				if(sf.SelectShapes(ext, 0.0001, SelectMode.INTERSECTION, ref result) && (labelFlag_MouseDown == 0))
				{
					mouseDownOperate(labels, projX, projY);
					labelFlag_MouseDown = 1;
				}
				else
				{
					sf.Labels.Clear();
					labelFlag_MouseDown = 0;
				}
				Map.Redraw();
			}
			#endregion

		}

		private void axMap1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if(e.KeyCode == Keys.Q)
			{
		
					axMap1.CursorMode = tkCursorMode.cmNone;
				

			}

		}

	
	}
}
