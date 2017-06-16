using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using AxMapWinGIS;
using Monitor.Classes;
using Monitor.Map;
using System.Diagnostics;
using Monitor.Core;

namespace Monitor.Map
{
	public class MapLayer: IAddLayer
	{

		private int Add(AxMap map, object layer, bool Visible)
		{
			if(layer == null) return -1;
			if(map == null)
				throw new System.Exception("MapWinGIS.Map Object not yet set. Set Map Property before adding layers");

			map.LockWindow(MapWinGIS.tkLockMode.lmLock);
			int MapLayerHandle = map.AddLayer(layer, Visible);

			if(MapLayerHandle < 0)
			{
				map.LockWindow(MapWinGIS.tkLockMode.lmUnlock);
				return MapLayerHandle;
			}

	//		MapWinGIS.Shapefile sf = (layer as MapWinGIS.Shapefile);

			map.LockWindow(MapWinGIS.tkLockMode.lmUnlock);

			// FireLayerAdded(MapLayerHandle);

			return MapLayerHandle;
		}

		/// <summary>
		/// 在gis中添加layer,其中layerroute是存.shp文件的路径
		/// </summary>
		/// <param name="LayerRoute"></param>
		public static void AddLayerSta(AxMap map, string[] LayerRoute)
		{
		
			map.LockWindow(tkLockMode.lmLock);

			string layerName = "";
			try
			{
				var fm = new FileManager();
				foreach(var name in LayerRoute)
				{
					layerName = name;
					var layer = fm.Open(name);
					if(layer == null)
					{
						string msg = string.Format("Failed to open datasource: {0} \n {1}", name, fm.ErrorMsg[fm.LastErrorCode]);
						MessageHelper.Warn(msg);
					}
					else
					{
					//	MapLayer.Add(map, layer, true);
					}
				}
			}
			catch
			{
				MessageHelper.Warn("There was a problem opening layer: " + layerName);
			}
			finally
			{
				map.LockWindow(tkLockMode.lmUnlock);
			}
		}

		public int AddLayer(AxMap map, string[] LayerRoute)
		{
			int layerHandle = 1;
			map.LockWindow(tkLockMode.lmLock);

			string layerName = "";
			try
			{
				var fm = new FileManager();
				foreach(var name in LayerRoute)
				{
					layerName = name;
					string str_filename = layerName.Substring(layerName.LastIndexOf("\\") + 
						1, layerName.LastIndexOf(".") - (layerName.LastIndexOf("\\") + 1)); //文件名称
					var layer = fm.Open(name);
					if(layer == null)
					{
						string msg = string.Format("Failed to open datasource: {0} \n {1}", name, fm.ErrorMsg[fm.LastErrorCode]);
						MessageHelper.Warn(msg);
					}
					else
					{
						if(str_filename == "底图")
						{
							layerHandle = Add(map, layer, true);

						}
						else
						{
							Add(map, layer, true);
						}

					}
				
				}
			}
			catch
			{
				MessageHelper.Warn("There was a problem opening layer: " + layerName);
			}
			finally
			{
				map.LockWindow(tkLockMode.lmUnlock);
			}
			return 0;
		}
	}
}
