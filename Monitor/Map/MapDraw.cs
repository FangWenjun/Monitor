
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using AxMapWinGIS;
using System.Data;
using System.IO;
using Monitor.Help;
using Monitor.Core;

namespace Monitor.Map
{

	public class classDrawLine: IDrawLine
	{
		private  AxMap map ;
		private  Shapefile sf = new Shapefile();
		private  int layerHandle;

		public AxMap Map
		{
			get
			{
				return map;
			}

			set
			{
				map = value;
			}
		}

		public Shapefile Shp
		{
			get
			{
				return sf;
			}
		}

		public classDrawLine(AxMap map)
		{
			this.map = map;
		} 


		public  void WriteLineFromData(List<LineParaSetStru> data)
		{

			for(int i = 0;i < data.Count; i++)
			{
				WriteLine(data[i].startPoint.x, data[i].startPoint.y, data[i].endPoint.x, data[i].endPoint.y, data[i].color);
			}


		}

		/// <summary>
		/// 根据坐标在地图上划线
		/// </summary>
		/// <param name="Xstart"></param>
		/// <param name="Ystart"></param>
		/// <param name="Xend"></param>
		/// <param name="Yend"></param>
		public int WriteLine(double Xstart, double Ystart, double Xend, double Yend, int color)
		{
			var axMap1 = map;
			var sf = CreateLines(Xstart,Ystart,Xend,Yend);
			layerHandle = axMap1.AddLayer(sf, true);
			var utils = new Utils();
			LinePattern pattern = new LinePattern();
			pattern.AddLine(utils.ColorByName((tkMapColor)(color)), 6.0f, tkDashStyle.dsSolid);
			ShapefileCategory ct = sf.Categories.Add("Railroad");
			ct.DrawingOptions.LinePattern = pattern;
			ct.DrawingOptions.UseLinePattern = true;
			sf.set_ShapeCategory(0, 0);
			return layerHandle; 
		}


		// <summary>
		// This function creates a number of parallel polylines (segments)
		// </summary>
		private  Shapefile CreateLines(double Xstart, double Ystart, double Xend, double Yend)
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

		public void RemoveLayer()
		{
			map.RemoveLayer(layerHandle);
			sf = new Shapefile();
			
		}



	}

	public class classDrawPoint: IDrawPoint
	{
		private  AxMap map;
		//	public static Shapefile sf = new Shapefile();
		private Shapefile sf = new Shapefile() ;

		private int layerHandle;

		private int shapindex = -1;



		public AxMap Map
		{
			get
			{
				return map;
			}

			set
			{
				map = value;
			}
		}

		public Shapefile Shp
		{
			get
			{
				return sf;
			}
		}

		public classDrawPoint(AxMap map)
		{
			this.map = map;
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

			layerHandle = Map.AddLayer(sf, true);
			Map.SendMouseMove = true;
			return layerHandle;

		}



		/// <summary>
		/// 在地图上添加图片
		/// </summary>
		/// <param name="data"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		public int AddPicture(Point data, string path)
		{
			
			Shape shp = new Shape(); //创建shp图层
			shp.Create(ShpfileType.SHP_MULTIPOINT);
			var pnt = new Point();
			pnt.x = data.x;
			pnt.y = data.y;
			int index = 0;
			shp.InsertPoint(pnt, ref index);
			sf.EditInsertShape(shp, ref shapindex);

			ShapefileCategory ct = sf.Categories.Add("0");
			var utils = new Utils();
			ct.DrawingOptions = sf.DefaultDrawingOptions;
			ct.DrawingOptions.PointType = tkPointSymbolType.ptSymbolPicture;
			Image img = new Image();
			img.Open(path);
			ct.DrawingOptions.Picture = img;
			ct.DrawingOptions.PointRotation = 45.0;
			sf.CollisionMode = tkCollisionMode.AllowCollisions;
			sf.set_ShapeCategory2(shapindex, "0");

			layerHandle = Map.AddLayer(sf, true);
			return layerHandle;

		}


		public void RemoveLayer()
		{
			map.RemoveLayer(layerHandle);
			sf = new Shapefile();
			sf.CreateNewWithShapeID("", ShpfileType.SHP_MULTIPOINT);

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
