using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using AxMapWinGIS;

namespace Monitor.Map
{
	public class ShapeFileHandle
	{
		private Dictionary<string,Shapefile> sf_mouseDown = new Dictionary<string, Shapefile>();
		private Dictionary<string,Shapefile> sf_mouseMove = new Dictionary<string, Shapefile>();
		private AxMap map;

		public Dictionary<string, Shapefile> Sf_MouseMove
		{
			get { return sf_mouseMove; }
		}

		public Dictionary<string,Shapefile> Sf_MouseDown
		{
			get { return sf_mouseDown; }
		}

		public ShapeFileHandle(AxMap map)
		{
			this.map = map;

		}
					
		public void AddMouseMoveShapeFile( string str, int layerHandle)
		{
			Shapefile sf;
			if(!sf_mouseMove.ContainsKey(str))
			{
				sf = map.get_Shapefile(layerHandle);

				sf_mouseMove.Add(str, sf);

			}
			else
			{
				sf = map.get_Shapefile(layerHandle);

				sf_mouseMove[str] = sf;


			}
		}

		public void AddMouseDownShapeFile(string str, int layerHandle)
		{
			Shapefile sf;
			if(!sf_mouseDown.ContainsKey(str))
			{
				sf = map.get_Shapefile(layerHandle);

				sf_mouseDown.Add(str, sf);

			}
			else
			{
				sf = map.get_Shapefile(layerHandle);

				sf_mouseDown[str] = sf;


			}

		}

	}


}
