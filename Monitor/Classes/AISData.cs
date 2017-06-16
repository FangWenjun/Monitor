using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using MapWinGIS;
using AxMapWinGIS;

namespace Monitor.Map
{
	/// <summary>
	/// 存储ais数据
	/// </summary>
	public class AISData
	{
		private AxMap map;

		public AISDataStru[] aisData;
		public ClassPoint[] point;
		public int AisHandle = -1;
		//public MapDraw mapDraw = null;
		public classDrawPoint drawPoint = null;
	


		
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="table"></param>ais数据库表
		/// <param name="handle"></param>shapefile句柄
		public AISData(AxMap map, DataTable table)
		{
			this.map = map;
			IntoAisData(table);
			IntoPointData();
			drawPoint = new classDrawPoint(map);

		}

		/// <summary>
		/// 讲datatable数据转换成aisdatastru类型数据
		/// </summary>
		/// <param name="table"></param>
		private void IntoAisData(DataTable table)
		{
			int num = table.Rows.Count;
			aisData = new AISDataStru[num];
			//实例化数据
			for(int i = 0; i < num; i++)
			{
				aisData[i] = new AISDataStru();
			}
			for(int i=0; i<num; i++)
			{
				aisData[i].longitude = (double)table.Rows[i][1];
				aisData[i].latitude = ( double ) table.Rows[i][2];
			}
		}



		/// <summary>
		/// 讲ais类型数据转成point类型数据
		/// </summary>
		private void IntoPointData()
		{
			int num = aisData.Length;
			point = new ClassPoint[num];
			for(int i=0; i<num; i++)
			{
				point[i] = new ClassPoint(); 
				point[i].x = aisData[i].longitude;
				point[i].y = aisData[i].latitude;
			}
		}


		public void LoadImg(string path)
		{
			//drawPoint.AddPicture(point[0], path);

		}




		/// <summary>
		/// 在地图上加载ais数据
		/// </summary>
		/// <param name="data"></param>ais数据
		/// <returns></returns>
		public void LoadAISData( PointSet pointSet)
		{
			//Shapefile sf = map.get_Shapefile(AisHandle);
			//if(sf != null)
			//	sf.Close();
			//AisHandle = drawPoint.CreatPoint(point, pointSet);
			 
		}
	}

	/// <summary>
	/// ais数据结构
	/// </summary>
	public class AISDataStru
	{
		public double longitude;
		public double latitude;
		public DateTime time;
	}


	public class AISPointTrail
	{
		private AxMap map;
		private classDrawPoint drawPoint = null;	 

		public AISDataStru[] aisPointTrail;
		public Point[] point;
		public int shapfileHandle = -1;

		public AISPointTrail(AxMap map, AISDataStru[] trail)
		{
			this.map = map;
			aisPointTrail = trail;
			drawPoint = new classDrawPoint(map);
		}

		private void IntoPointData()
		{
			int num = aisPointTrail.Length;
			point = new Point[num];
			for(int i = 0;i < num;i++)
			{
				point[i] = new Point();
				point[i].x = aisPointTrail[i].longitude;
				point[i].y = aisPointTrail[i].latitude;
			}
		}

		public void LoadAisTrail(PointSet pointSet)
		{
			Shapefile sf = map.get_Shapefile(shapfileHandle);
			if(sf != null)
				sf.Close();
			//shapfileHandle = drawPoint.CreatPoint(point, pointSet);
		}

	}

}
