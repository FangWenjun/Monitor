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
using System.Collections.Generic;
using ToolBar;

namespace Monitor.Map
{

    public partial class ControlMapForm : DockContent
    {

		private  ControlMapForm _mapform = null;
		private  ToolControl  m_toolControl = null;
	

		//用于判断是否已经显示label
		private int labelFlag_MouseMove;
		private int labelFlag_MouseDown;

		//ais图层句柄
		public  int  AISHandle = -1;

		

		private string[] mapPath = { @"D:\光纤传感监测系统\Monitor\Monitor\data\test4.shp", @"D:\光纤传感监测系统\Monitor\Monitor\data\省界WGS 84.shp" } ;

		public IAddLayer mapLayer;
		public IDrawLine drawLine ;
		public IDrawPoint drawPoint;

		public AISData ais = null;
		public IDrawPoint drawPoint_Ais = null;
		public List<Shapefile> sfMouseMove;
		public List<Shapefile> sfMouseDown;

		public MouseMoveOperator mouseMoveOperate;
		public MouseDownOperator mouseDownOperate;



		public  ControlMapForm MapForm
		{
			get { return _mapform; }
			set { _mapform = value; }
		}

		public ToolControl toolControl
		{
			get { return m_toolControl; }
		}

		public string[] MapPath
		{
			set
			{
				mapPath = value;
			}
		}

		public List<Shapefile> SfMouseMove
		{
			set { sfMouseMove = value; }
			get { return sfMouseMove; }
		}

		public List<Shapefile> SfMouseDown
		{
			set { sfMouseDown = value; }
			get { return sfMouseDown; }
		}

		public  MouseMoveOperator MouseMoveOperate
		{
			set { mouseMoveOperate = value; }
			get { return mouseMoveOperate; }
		}



		public ControlMapForm()
        {
            InitializeComponent();
			_mapform = this;

			

		}

        public AxMap Map
        {
            get { return axMap1; }
        }

		public void UiInitAndInvoke()
		{

			MapInit();
			RegisterEventHandlers();
			//ToolControl控件动态加载
			m_toolControl = new ToolControl();
			this.Controls.Add(m_toolControl);
			m_toolControl.Location = new System.Drawing.Point(60, 10);
			m_toolControl.Size = new System.Drawing.Size(147, 50);
			m_toolControl.Dock = DockStyle.None;
			m_toolControl.BringToFront();

			m_toolControl.Map = Map;
			m_toolControl.MapForm = this;
			m_toolControl.InitAttri();
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
		//	mouseMoveOperate = new MouseMoveOperator(Operation.AddLabel);
		//	mouseDownOperate = new MouseDownOperator(Operation.AddLabel);
		}







		private void axMap1_MouseMoveEvent(object sender, _DMapEvents_MouseMoveEvent e)
        {
			if(sfMouseMove != null)
			{
				foreach(Shapefile sf in sfMouseMove)
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
							mouseMoveOperate(ais, labels, projX, projY);
							labelFlag_MouseMove = 1;
						}
						else
						{
							sf.Labels.Clear();
							labelFlag_MouseMove = 0;
						}
						Map.Redraw();
				}
			}

		}



		private void axMap1_MouseDownEvent(object sender, _DMapEvents_MouseDownEvent e)
		{
			if(SfMouseDown != null)
			{
				foreach(Shapefile sf in sfMouseDown)
				{
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
						ext.SetBounds(projX - 0.0004, projY - 0.0004, 0.0, projX + 0.0004, projY + 0.0004, 0.0);
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
				

				}
			

			}
			
	
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
