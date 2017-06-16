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

            if (HandleProject(command)) return;

         //   if (HandleContextMenu(command)) return;
        }

        private bool HandleProject(AppCommand command)
        {
            switch (command)
            {
                case AppCommand.LoadProject:
                    {
                        string filename;
                        if (FileHelper.ShowOpenDialog(FileType.Project, out filename))
                        {
                            App.Project.Load(filename);
                        }
                    }
                    return true;
                case AppCommand.SaveProject:
                    {
                        if (App.Project.Save())
                            MessageHelper.Info("Project was saved: ");
                    }
                    return true;
                case AppCommand.SaveProjectAs:
                    App.Project.SaveAs();
                    return true;
                case AppCommand.CloseProject:
                    App.Project.TryClose();
                    return true;
                case AppCommand.SetProjection:
                    {
                        if (App.Map.NumLayers > 0)
                        {
                            MessageHelper.Info("It's not allowed to change map projection when there are layers on the map.");
                        }
                        else
                        {
                          
                        }
                    }
                    return true;
            }
            return false;
        }

        private bool HandleLayers(AppCommand command)
        {
            switch (command)
            {
                case AppCommand.AddDatabase:
                    //    LayerHelper.OpenOgrLayer();
                    return true;
                case AppCommand.Open:
                    LayerHelper.AddLayer(LayerType.All);
                    return true;
                case AppCommand.AddRaster:
                    //LayerHelper.AddLayer(LayerType.Raster);
                    return true;
                case AppCommand.AddVector:
                    //LayerHelper.AddLayer(LayerType.Vector);
                    return true;
                case AppCommand.RemoveLayer:
                    //LayerHelper.RemoveLayer();
                    return true;
                case AppCommand.ZoomToLayer:
                    LayerHelper.ZoomToLayer(map, layerHandle);
                    return true;
                case AppCommand.CreateLayer:
                    //Editor.RunCommand(EditorCommand.CreateLayer);
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
                case AppCommand.ClearSelection:
                   // LayerHelper.ClearSelection();
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
