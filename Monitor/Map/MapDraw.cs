
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using AxMapWinGIS;
using System.Data;

namespace Monitor.Map
{
	public  class MapDraw
	{
		private AxMap MapHandle;
		private int AisHandle;

		public MapDraw(AxMap map, int handle)
		{
			MapHandle = map;
			AisHandle = handle; 
		}

		public static void WriteLineFromData(LineData data)
		{
			
			for(int i=0; i<data.x.Length-1; i++)
			{
				LinePattern(data.x[i],data.y[i],data.x[i+1],data.y[i+1]);
			}
			

		}

		/// <summary>
		/// 根据坐标在地图上划线
		/// </summary>
		/// <param name="Xstart"></param>
		/// <param name="Ystart"></param>
		/// <param name="Xend"></param>
		/// <param name="Yend"></param>
		public static void LinePattern(double Xstart, double Ystart, double Xend, double Yend)
		{
			var axMap1 = MapForm.MapFormAttri.Map;
			axMap1.Projection = tkMapProjection.PROJECTION_NONE;

			var sf = CreateLines(Xstart,Ystart,Xend,Yend);
			axMap1.AddLayer(sf, true);

			var utils = new Utils();

			// railroad pattern
			LinePattern pattern = new LinePattern();
			pattern.AddLine(utils.ColorByName(tkMapColor.DarkBlue), 6.0f, tkDashStyle.dsSolid);
		//	pattern.AddLine(utils.ColorByName(tkMapColor.White), 5.0f, tkDashStyle.dsSolid);

			ShapefileCategory ct = sf.Categories.Add("Railroad");
			ct.DrawingOptions.LinePattern = pattern;
			ct.DrawingOptions.UseLinePattern = true;
			sf.set_ShapeCategory(0, 0);

			//// river pattern
			//pattern = new LinePattern();
			//pattern.AddLine(utils.ColorByName(tkMapColor.DarkBlue), 6.0f, tkDashStyle.dsSolid);
			//pattern.AddLine(utils.ColorByName(tkMapColor.LightBlue), 4.0f, tkDashStyle.dsSolid);

			//ct = sf.Categories.Add("River");
			//ct.DrawingOptions.LinePattern = pattern;
			//ct.DrawingOptions.UseLinePattern = true;
			//sf.set_ShapeCategory(1, 1);

			//// road with direction
			//pattern = new LinePattern();
			//pattern.AddLine(utils.ColorByName(tkMapColor.Gray), 8.0f, tkDashStyle.dsSolid);
			//pattern.AddLine(utils.ColorByName(tkMapColor.Yellow), 7.0f, tkDashStyle.dsSolid);
			//LineSegment segm = pattern.AddMarker(tkDefaultPointSymbol.dpsArrowRight);
			//segm.Color = utils.ColorByName(tkMapColor.Orange);
			//segm.MarkerSize = 10;
			//segm.MarkerInterval = 32;

			//ct = sf.Categories.Add("Direction");
			//ct.DrawingOptions.LinePattern = pattern;
			//ct.DrawingOptions.UseLinePattern = true;
			//sf.set_ShapeCategory(2, 2);
		}


		// <summary>
		// This function creates a number of parallel polylines (segments)
		// </summary>
		public static Shapefile CreateLines(double Xstart, double Ystart, double Xend, double Yend)
		{
			Shapefile sf = new Shapefile();
			sf.CreateNew("", ShpfileType.SHP_POLYLINE);

			Shape shp = new Shape();
			shp.Create(ShpfileType.SHP_POLYLINE);

			Point pnt = new Point();
			pnt.x = Xstart;
			pnt.y = Ystart;
			int index = shp.numPoints;
			shp.InsertPoint(pnt, ref index);

			pnt = new Point();
			pnt.x = Xend;
			pnt.y = Yend;
			index = shp.numPoints;
			shp.InsertPoint(pnt, ref index);

			index = sf.NumShapes;
			sf.EditInsertShape(shp, ref index);

			return sf;
		}


		/// <summary>
		/// 在地图上画三角点
		/// </summary>
		/// <param name="data"></param>data参数为ais数据
		public int CreatePointShapefile(AISData data)
		{
			MapHandle.Projection = tkMapProjection.PROJECTION_NONE;
			var sf = new Shapefile(); //创建一个新的shp文件
			bool result = sf.CreateNewWithShapeID("", ShpfileType.SHP_MULTIPOINT);  //初始化shp文件

			Shape shp = new Shape(); //创建shp图层
			shp.Create(ShpfileType.SHP_MULTIPOINT);
			for(int i = 0; i < data.aisData.Length; i++)
			{
			

				var pnt = new Point();
				
				pnt.x = data.aisData[i].longitude;
				pnt.y = data.aisData[i].latitude;

				
				int index = 0;
				shp.InsertPoint(pnt, ref index);
			//	sf.EditInsertShape(shp, ref i);
			}
			sf.EditAddShape(shp);

			var utils = new Utils();						
			ShapefileCategory ct = sf.Categories.Add("0");
			ct.DrawingOptions.PointSize = 10;
			ct.DrawingOptions.FillColor = utils.ColorByName(tkMapColor.Red);
			ct.DrawingOptions.SetDefaultPointSymbol(tkDefaultPointSymbol.dpsTriangleUp);
			sf.set_ShapeCategory2(0,"0");

		
			int handle = MapHandle.AddLayer(sf, true);
			MapHandle.SendMouseMove = true;
			return handle;
		}

		/// <summary>
		/// 在地图上加载ais数据
		/// </summary>
		/// <param name="data"></param>ais数据
		/// <returns></returns>
		public int LoadAISData(AISData data)
		{
			Shapefile sf = MapHandle.get_Shapefile(AisHandle);
			if(sf != null)
				sf.Close();
			int aisHandle = CreatePointShapefile(data);
			return aisHandle;
		}

	}
}
