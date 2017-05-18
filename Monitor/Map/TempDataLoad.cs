using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Map
{
	public class TempDataLoad
	{
		private TempDataClassification tempClassify;
		private DrawLine drawLine;
		private TempClassificationLevel[] level;
		private TempDataStru[] tempDataList;


		public TempDataLoad(TempClassificationLevel[] level, TempDataStru[] tempDataList)
		{
			this.level = level;
			this.tempDataList = tempDataList;

		}

		public void LoadTempData()
		{
			drawLine = new DrawLine();
			tempClassify = new TempDataClassification(level);
			tempClassify.ClassifyTempColor(tempDataList);
			tempClassify.ClassifyCoordinateColor();
			drawLine.WriteLineFromData(tempClassify.coordinateColorList);
		}
	}
}
