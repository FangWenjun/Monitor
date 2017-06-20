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
		Shapefile Shp { get;}

		int WriteLine(ClassLine line, LineSet lineSet);

	}

	public interface IDrawPoint
	{
		AxMap Map { get; set; }
		Shapefile Shp { get; }
		int CreatPoint(ClassPoint[] data, PointSet pointSet);
		int AddPicture(ClassPoint data, string path);
	}


	public delegate void MouseMoveOperator(object result, Shapefile sf, Labels labels, double projX, double projY);

	public delegate void MouseDownOperator(object result, Shapefile sf, Labels labels, double projX, double projY);
}
