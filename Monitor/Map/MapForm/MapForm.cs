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
		private  Labels labels;
		private  int movemoveenter = 0;
		private  int mainLayerHandle;
	

		//用于判断是否已经显示label
		private int labelFlag_MouseMove;
		private int labelFlag_MouseDown;

		private Dictionary<string,Shapefile> sfMouseMove = new Dictionary<string, Shapefile>();
		private Dictionary<string,Shapefile> sfMouseDown = new Dictionary<string, Shapefile>();

		//ais图层句柄
		public  int  AISHandle = -1;

		private int res = -1; 




		private string[] mapPath = { @"D:\光纤传感监测系统\Monitor\Monitor\data\test4.shp", @"D:\光纤传感监测系统\Monitor\Monitor\data\省界WGS 84.shp" } ;

		public IAddLayer mapLayer;
		public IDrawLine drawLine ;
		public IDrawPoint drawPoint;

		public AISData ais = null;
		public IDrawPoint drawPoint_Ais = null;

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

		public int MainLayerHandle
		{
			set { mainLayerHandle = value; }
		}

		public string[] MapPath
		{
			set
			{
				mapPath = value;
			}
		}

		public Dictionary<string ,Shapefile> Sf_MouseMove
		{
			set
			{
				sfMouseMove = value;
			}
		}

		public Dictionary<string, Shapefile> Sf_MouseDown
		{
			set
			{
				sfMouseDown = value;
			}

		}

	

		public MouseMoveOperator MouseMoveOperate
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

		public void SetMainLayerHandle()
		{
			m_toolControl.MainLayerHandle = mainLayerHandle;
			m_toolControl.SetMainLayerHandle();

		}



		private void MapInit()
        {
         axMap1.GrabProjectionFromData = true;
			axMap1.SendMouseMove = true;
     //       axMap1.SendSelectBoxFinal = true;
            axMap1.SendMouseDown = true;
            axMap1.SendMouseUp = true;
    //        axMap1.InertiaOnPanning = tkCustomState.csAuto;
          axMap1.ShowRedrawTime = true;
            //Map.Identifier.IdentifierMode = tkIdentifierMode.imSingleLayer;
           //Map.Identifier.HotTracking = true;
           //Map.ShapeEditor.HighlightVertices = tkLayerSelection.lsNoLayer;
            //Map.ShapeEditor.SnapBehavior = tkLayerSelection.lsNoLayer;
            //axMap1.Measuring.UndoButton = tkUndoShortcut.usCtrlZ;
		//	axMap1.Projection = tkMapProjection.PROJECTION_WGS84;
			axMap1.TileProvider = tkTileProvider.ProviderNone;  //没有任何背景图
			axMap1.CursorMode = tkCursorMode.cmPan;
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
			#region 原版添加标签
			if(sfMouseMove != null)
			{
				foreach(Shapefile sf in sfMouseMove.Values)
				{

					labels = sf.Labels;
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
					if(sf.SelectShapes(ext, 0.00007, SelectMode.INTERSECTION, ref result))
					{
					
							if( labelFlag_MouseMove == 0 )
							{

									mouseMoveOperate(result, sf, labels, projX, projY);

									Map.Redraw();
									movemoveenter++;
									string tStr = "aaa:" + movemoveenter;
									int str = labels.Count;
									Debug.Print("labels：" + str);
									labelFlag_MouseMove = 1;

							}
						
					}
					else
					{
						if (labelFlag_MouseMove == 1)
						{
							sf.Labels.Clear();
							labelFlag_MouseMove = 0;
							Map.Redraw();
							movemoveenter++;
							string tStr = "bbb:" + movemoveenter;
							int str = labels.Count;
							Debug.Print("labels：" + str);
						}
		
					}

				}

			}
			#endregion
	 

		}



		private void axMap1_MouseDownEvent(object sender, _DMapEvents_MouseDownEvent e)
		{

			if(sfMouseDown != null)
			{
				foreach(Shapefile sf in sfMouseDown.Values)
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
						if(sf.SelectShapes(ext, 0.0001, SelectMode.INTERSECTION, ref result))
						{
							if(labelFlag_MouseDown == 0)
							{

								mouseDownOperate(result, sf, labels, projX, projY);
								Map.Redraw();
								labelFlag_MouseDown = 1;
								

							}
							
						}
						else
						{
							if(labelFlag_MouseDown == 1)
							{
								sf.Labels.Clear();
								Map.Redraw();
								labelFlag_MouseDown = 0;

							}

							
						}
						
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
