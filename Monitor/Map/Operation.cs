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
		public void AddLabel(AISData ais, Labels labels, double projX, double projY)
		{
			AISDataStru aisPointData = MapAlgori.FindAisPoint(ais, projX, projY);
			string aisLabel = "x=" + aisPointData.longitude.ToString() + "      "  +
						"y=" + aisPointData.latitude.ToString();
			labels.AddLabel(aisLabel, projX, projY, 0.0, -1);

		}

	}
}
