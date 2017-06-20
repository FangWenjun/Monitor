using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MapWinGIS;

namespace Monitor.Map
{
	public class Operation
	{
		//public static void AddLabel(string  str, Labels labels, double projX, double projY)
		//{

		//	int[] i = (int[])result;
		//	Shape shp  = sf.Shape[i[0]];

		//	//	string temp = sf.CellValue[0, i[0]].ToString();
		//	string temp = sf.get_CellValue(1,i[0]).ToString();
		//	Point pnt = shp.Centroid;

		//	string aisLabel = "x=" + "121" + "      "  +
		//				"y=" + "30";
		//	labels.AddLabel(aisLabel, projX, projY, 0.0, -1);
		////	labels.InsertLabel(0, aisLabel, projX, projY, 0.0, -1);

		//}

		public static void AddLabel(object result, Shapefile sf, Labels labels, double projX, double projY)
		{
			int[] i = (int[])result;
			Shape shp  = sf.Shape[i[0]];
			string temp = sf.get_CellValue(1,i[0]).ToString();
			Point pnt = shp.Centroid;
			labels.AddLabel(temp, projX, projY);

		}

	//	public static void AddLabel(string str, Labels labels, double projX, double projY)
	//	{
	//		string aisLabel = "图片label";
	////		labels.AddLabel(aisLabel, projX, projY, 0.0, -1);
	//		labels.InsertLabel(0, aisLabel,projX, projY,0.0,-1);

	//	}



	}
}
