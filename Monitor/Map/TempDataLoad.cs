using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;

namespace Monitor.Map
{
	public class TempDataLoad
	{
		private TempDataClassification tempClassify;
		private DrawLine drawLine;
		private TempClassificationLevel[] level;
		private TempDataStru[] tempDataList;
		private AxMap map;


		public TempDataLoad(AxMap map, TempClassificationLevel[] level, TempDataStru[] tempDataList)
		{
			this.map = map;
			this.level = level;
			this.tempDataList = tempDataList;

		}

		public void LoadTempData()
		{
			drawLine = new DrawLine(map);
			tempClassify = new TempDataClassification(level);
			tempClassify.ClassifyTempColor(tempDataList);
			tempClassify.ClassifyCoordinateColor();
			drawLine.WriteLineFromData(tempClassify.coordinateColorList);
		}
	}
}
