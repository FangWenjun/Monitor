using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using AxMapWinGIS;
using Monitor.Classes;
using Monitor.Help;
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

			MapWinGIS.Shapefile sf = (layer as MapWinGIS.Shapefile);

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


		public static void AddSqliteLayer(AxMap map)
		{
			string fn = @"d:\data2.sqlite";
			var ds = new OgrDatasource();
			if(!ds.Open(fn))
			{
				Debug.Print("Failed to establish connection: " + ds.GdalLastErrorMsg);
			}
			else
			{
				map.RemoveAllLayers();

				// make sure it matches SRID of the layers (4326 in our case)
				map.Projection = tkMapProjection.PROJECTION_WGS84;

				for(int i = 0;i < ds.LayerCount;i++)
				{
					var layer = ds.GetLayer(i);
					if(layer != null)
					{
						int handle = map.AddLayer(layer, true);
						if(handle == -1)
						{
							Debug.WriteLine("Failed to add layer to the map: " + map.get_ErrorMsg(map.LastErrorCode));
						}
						else
						{
							Debug.WriteLine("Layer was added the map: " + layer.Name);
						}
					}
				}
				map.ZoomToMaxVisibleExtents();
				ds.Close();
				map.Redraw();
			}

		}

		/// <summary>
		/// 在地图上添加图层
		/// </summary>
		/// <param name="Map"></param>
		/// <param name="LayerRoute"></param>
		/// <returns>返回图层句柄</returns>
		public int AddLayer(AxMap Map, string[] LayerRoute)
		{
			int layerHandle= -1;
			var map = Map;
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
						layerHandle = Add(map, layer, true);
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
			return layerHandle;
		}
	}
}
