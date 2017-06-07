using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using Monitor.Map;
using MapWinGIS;


namespace Monitor.Core
{
	public interface IAddLayer
	{
		int AddLayer(AxMap Map, string[] LayerRoute);

	}

	public interface IDrawLine
	{
		AxMap Map { get; set;}
		Shapefile Shp { get; set;}

		int WriteLine(double Xstart, double Ystart, double Xend, double Yend, int color);

	}

	public interface IDrawPoint
	{
		AxMap Map { get; set; }
		Shapefile Shp { get; set; }
		int CreatPoint(Point[] data, PointSet pointSet);
		int AddPicture(Point data, string path);
	}


	public delegate void MouseMoveOperator(AISData ais, Labels labels, double projX, double projY);
}
