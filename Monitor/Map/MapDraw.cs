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
	public static class MapDraw
	{

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
}
