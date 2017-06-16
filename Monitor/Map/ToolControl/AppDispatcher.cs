using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBar.Classes;
using System.Windows.Forms;
using MapWinGIS;
using AxMapWinGIS;
using Monitor.Map;

namespace ToolBar.Classes
{
    internal class AppDispatcher : CommandDispatcher<AppCommand>
    {
		private AxMap map;
		private ControlMapForm mapForm = null;
		private int layerHandle;

		public AxMap Map
		{
			set { map = value; }
			get { return map; }
		}

		public ControlMapForm MapForm
		{
			get { return mapForm; }
			set { mapForm = value; }
		}

		public int LayerHandle
		{
			set { layerHandle = value; }
			get { return layerHandle; }
		}

        public override void Run(AppCommand command)
        {
            if (HandleCursors(command)) return;

            if (HandleLayers(command)) return;

      
 
        }

   

        private bool HandleLayers(AppCommand command)
        {
            switch (command)
            {
                case AppCommand.ZoomToLayer:
                    LayerHelper.ZoomToLayer(map, layerHandle);
                    return true;
            }
            return false;
        }

        private bool SetMapCursor(tkCursorMode mode)
        {
            App.Map.CursorMode = mode;
         
            return true;
        }


        private bool HandleCursors(AppCommand command)
        {
            switch (command)
            {
                case AppCommand.SelectByPolygon:
                    return SetMapCursor(tkCursorMode.cmSelectByPolygon);
                case AppCommand.Identify:
                    return SetMapCursor(tkCursorMode.cmIdentify);
                case AppCommand.Measure:
                    App.Map.Measuring.MeasuringType = tkMeasuringType.MeasureDistance;
                    return SetMapCursor(tkCursorMode.cmMeasure);
                case AppCommand.MeasureArea:
                    App.Map.Measuring.MeasuringType = tkMeasuringType.MeasureArea;
                    return SetMapCursor(tkCursorMode.cmMeasure);
                case AppCommand.Pan:
                    return SetMapCursor(tkCursorMode.cmPan);
                case AppCommand.Select:
                    return SetMapCursor(tkCursorMode.cmSelection);
                case AppCommand.ZoomIn:
                    return SetMapCursor(tkCursorMode.cmZoomIn);

                case AppCommand.ZoomOut:
                    return SetMapCursor(tkCursorMode.cmZoomOut);
                case AppCommand.ZoomToSelected:
                    LayerHelper.ZoomToSelected();
                    break;
      
                case AppCommand.Click:
					LayerHelper.MouseClickMode(map, MapForm);
                    break;
                case AppCommand.None:
                    return true;
            }
            return false;
        }

        protected override void CommandNotFound(ToolStripItem item)
        {
            MessageHelper.Info("No handle is found: " + item.Name);
        }
    }
}
