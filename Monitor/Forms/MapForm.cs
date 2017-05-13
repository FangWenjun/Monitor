using AxMapWinGIS;
using MapWinGIS;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Monitor.Classes;

namespace Monitor.Map
{

    public partial class MapForm : DockContent
    {

		private static MapForm _mapform = null;
		//用于判断是否已经显示label
		private int labelFlag;

		//ais图层句柄
		public  int  AISHandle = -1;

		public static MapForm MapFormAttri
		{
			get { return _mapform; }
		}

		public MapForm()
        {
            InitializeComponent();
			_mapform = this;
			RegisterEventHandlers();
			InitMap();
        }

        public AxMap Map
        {
            get { return axMap1; }
        }

   

        private void InitMap()
        {
          
            axMap1.GrabProjectionFromData = true;
            axMap1.CursorMode = tkCursorMode.cmZoomIn;
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
		}




        private void axMap1_MouseMoveEvent(object sender, _DMapEvents_MouseMoveEvent e)
        {
			//if (!axMap1.Focused)
			//    axMap1.Focus();

			#region 显示ais数据标签详情
			Shapefile sf = Map.get_Shapefile(MapForm.MapFormAttri.AISHandle);
		//	sf.Close();
		
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
				if(sf.SelectShapes(ext, 0.00005, SelectMode.INTERSECTION, ref result) && (labelFlag == 0))
				{															 
					AISDataStru aisPointData = MapAlgori.FindAisPoint(MainForm.MainFormAttri.ais, projX, projY);
					string aisLabel = "x=" + aisPointData.longitude.ToString() + "      "  +
						"y=" + aisPointData.latitude.ToString();
					labels.AddLabel(aisLabel, projX, projY, 0.0, -1);
					labelFlag = 1;
				}
				else
				{
					sf.Labels.Clear();
					labelFlag = 0;
				}
				Map.Redraw();
			}
			#endregion
		}
	  
	}
}
