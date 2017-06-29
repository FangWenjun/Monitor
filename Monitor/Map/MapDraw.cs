
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using AxMapWinGIS;
using System.Data;
using System.IO;
using Monitor.Map;
using Monitor.Core;
using System.Windows.Forms;

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
			sf.CreateNew("", ShpfileType.SHP_POLYLINE);

			this.map = map;
		} 


		public  void WriteLineFromData(List<LineParaSetStru> data)
		{

			for(int i = 0;i < data.Count; i++)
			{
				//WriteLine(data[i].startPoint.x, data[i].startPoint.y, data[i].endPoint.x, data[i].endPoint.y, data[i].color);
			}


		}

		/// <summary>
		/// 根据坐标在地图上划线
		/// </summary>
		/// <param name="Xstart"></param>
		/// <param name="Ystart"></param>
		/// <param name="Xend"></param>
		/// <param name="Yend"></param>
		public int WriteLine(ClassLine line, LineSet lineSet)
		{
			Shape shp = new Shape();
			shp.Create(ShpfileType.SHP_POLYLINE);

			Point pnt = new Point();
			pnt.x = line.startX;
			pnt.y = line.startY;
			int index = shp.numPoints;
			shp.InsertPoint(pnt, ref index);

			pnt = new Point();
			pnt.x = line.endX;
			pnt.y = line.endY;
			index = shp.numPoints;
			shp.InsertPoint(pnt, ref index);

			index = sf.NumShapes;
			sf.EditInsertShape(shp, ref index);

			layerHandle = map.AddLayer(sf, true);
			var utils = new Utils();
			LinePattern pattern = new LinePattern();
			pattern.AddLine(utils.ColorByName(lineSet.color), lineSet.Width, lineSet.style);
			ShapefileCategory ct = sf.Categories.Add("Railroad");
			ct.DrawingOptions.LinePattern = pattern;
			ct.DrawingOptions.UseLinePattern = true;
			sf.set_ShapeCategory(0, 0);
			return layerHandle; 
		}


		public void RemoveLayer()
		{
			if(layerHandle != -1)
			{
				map.RemoveLayer(layerHandle);

				sf = new Shapefile();
				sf.CreateNew("", ShpfileType.SHP_POLYLINE);
				layerHandle = -1;

			}


		}



	}

	public class classDrawPoint: IDrawPoint
	{
		private  AxMap map;
		private Shapefile sf = new Shapefile() ;
	//	private Shape sonshp = new Shape();
		private int layerHandle = -1;
		private int shapindex = -1;
		private ClassPoint[] pointData;

		public int LayerHandle
		{
			get { return layerHandle; }
		}



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

		public ClassPoint[] PointData
		{
			set { pointData = value; }
			get { return pointData; }
		}

		public classDrawPoint(AxMap map)
		{
			this.map = map;
			sf.CreateNewWithShapeID("", ShpfileType.SHP_POINT);
			//sonshp.Create(ShpfileType.SHP_MULTIPOINT);
		}

	  
		


		public int CreatPoint(ClassPoint[] data, PointSet pointSet)
		{
			pointData = data;

			for(int i = 0;i < data.Length;i++)
			{

				var pnt = new Point();
				pnt.x = data[i].x;
				pnt.y = data[i].y;
				Shape shp = new Shape();
				shp.Create(ShpfileType.SHP_POINT);

				int index = 0;
				shp.InsertPoint(pnt, ref index);
				sf.EditInsertShape(shp, ref shapindex);

			}

			var utils = new Utils();
			sf.DefaultDrawingOptions.SetDefaultPointSymbol(pointSet.shape);
			sf.DefaultDrawingOptions.PointSize = pointSet.size;
			sf.DefaultDrawingOptions.FillColor = utils.ColorByName(pointSet.color);
			layerHandle = Map.AddLayer(sf, true);
			return layerHandle;

		}

		public  void EditAttribute()
		{
			if(!sf.StartEditingShapes(true, null))
			{
				MessageBox.Show("Failed to start edit mode: " + sf.ErrorMsg[sf.LastErrorCode]);
			}
			else
			{
				int fieldIndex = sf.EditAddField("shapeStr", FieldType.STRING_FIELD, 0, 0);
				for(int i = 0;i < sf.NumShapes;i++)
					sf.EditCellValue(fieldIndex, i, pointData[i].str);
			}
		}




		/// <summary>
		/// 在地图上添加图片
		/// </summary>
		/// <param name="data"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		public int AddPicture(ClassPoint data, string path)
		{
			pointData = new ClassPoint[1];
			PointData[0] = new ClassPoint();
			pointData[0] = data;
			
			Shape shp = new Shape(); //创建shp图层
			shp.Create(ShpfileType.SHP_POINT);
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
			if(layerHandle != -1)
			{
				map.RemoveLayer(layerHandle);
				
				sf = new Shapefile();
				sf.CreateNewWithShapeID("", ShpfileType.SHP_POINT);
				layerHandle = -1;

			}
		

		}

	}

	public class  classAddText
	{
		private Labels labels = new Labels();
		private AxMap map;
		private Shapefile sf = new Shapefile();

		public classAddText(AxMap map, int layerHandle)
		{
			this.map = map;
			this.sf = map.get_Shapefile(layerHandle);

		}

		public Shapefile Shp
		{
			set { sf = value; }
			get { return sf; }
		}


		public void AddText(double x, double y )
		{
			Labels labels = sf.Labels;
			labels.FontSize = 15;
			labels.FontBold = true;
			labels.FrameVisible = false;
			labels.FrameType = tkLabelFrameType.lfRectangle;
			labels.AutoOffset = false;
			labels.OffsetX = 40;

			LabelCategory cat = labels.AddCategory("wenzi");
			cat.FontColor = 255;
			

			string aisLabel = "文字部分";
			labels.AddLabel(aisLabel, x, y, 0.0, -1);

		}


			

	}

	
}
