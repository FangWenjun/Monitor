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
            
                case AppCommand.Pan:
                    return SetMapCursor(tkCursorMode.cmPan);
                case AppCommand.Click:
					LayerHelper.MouseClickMode(map, MapForm);
					return true;
				case AppCommand.Help:
					string str = "1.拖动按妞可上下左右拖动地图\r\n2.还原地图按钮可还原地图至最初大小\r\n3.点击模式按钮可将鼠标设置成点击模式";
					MessageBox.Show(str);
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
