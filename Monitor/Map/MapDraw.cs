﻿
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


		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="map"></param> 地图句柄
		public MapDraw(AxMap map)
		{
			MapHandle = map;
			
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


		
	

	}

	public class DrawLine
	{
		private static AxMap Map ;
		public static Shapefile sf = new Shapefile();

		public DrawLine()
		{
			Map = MapForm.MapFormAttri.Map;
		}


		public  void WriteLineFromData(LineData data)
		{

			for(int i = 0;i < data.x.Length - 1;i++)
			{
				LinePattern(data.x[i], data.y[i], data.x[i + 1], data.y[i + 1]);
			}


		}

		/// <summary>
		/// 根据坐标在地图上划线
		/// </summary>
		/// <param name="Xstart"></param>
		/// <param name="Ystart"></param>
		/// <param name="Xend"></param>
		/// <param name="Yend"></param>
		public  void LinePattern(double Xstart, double Ystart, double Xend, double Yend)
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



	}

	public class DrawPoint
	{
		private static AxMap Map ;
		public static Shapefile sf = new Shapefile();

		public int shapindex = -1;

		static DrawPoint()
		{
			Map = MapForm.MapFormAttri.Map;
			sf.CreateNewWithShapeID("", ShpfileType.SHP_MULTIPOINT);
		}	
		
					  
		/// <summary>
		/// 在地图上画点
		/// </summary>
		/// <param name="data"></param>
		/// <param name="pointSet"></param>
		/// <returns></returns>
		public int CreatPoint(Point[] data, PointSet pointSet)
		{
			Shape shp = new Shape(); //创建shp图层
			shp.Create(ShpfileType.SHP_MULTIPOINT);
			for(int i = 0;i < data.Length;i++)
			{

				var pnt = new Point();
				pnt.x = data[i].x;
				pnt.y = data[i].y;

				int index = 0;
				shp.InsertPoint(pnt, ref index);

			}
			sf.EditInsertShape(shp, ref shapindex);

			ShapefileCategory ct = sf.Categories.Add(pointSet.categroyName);
			var utils = new Utils();
			ct.DrawingOptions.PointSize = pointSet.size;
			ct.DrawingOptions.FillColor = utils.ColorByName(pointSet.color);
			ct.DrawingOptions.SetDefaultPointSymbol(pointSet.shape);
			sf.set_ShapeCategory2(shapindex, pointSet.categroyName);

			int handle = Map.AddLayer(sf, true);
			Map.SendMouseMove = true;
			return handle;

		}

	}

	public struct PointSet
	{
		public string categroyName;
		public tkDefaultPointSymbol shape;
		public  tkMapColor color;
		public  float size;

		public PointSet(string categroyName, tkDefaultPointSymbol shape, tkMapColor color, float size)
		{
			this.categroyName = categroyName;
			this.shape = shape;
			this.color = color;
			this.size = size;

		}

	}
}