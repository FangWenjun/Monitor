using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

namespace Monitor.Map
{
	public class TempDataClassification
	{
		public TempClassificationLevel[] colorLevel;
		public TempColorStru[] tempColor;
		public List<LineParaSetStru> coordinateColorList = new List<LineParaSetStru>();

		public TempDataClassification(TempClassificationLevel[] level)
		{
			this.colorLevel = level;
		}

		public void ClassifyTempColor(TempDataStru[] tempDataList)
		{
			int num = tempDataList.Length;
			tempColor = new TempColorStru[num];
			for(int j=0; j<tempDataList.Length; j++)
			{
				for(int i=0; i<colorLevel.Length; i++)
				{
					if((tempDataList[j].temp >= colorLevel[i].startTemp)&&(tempDataList[j].temp < colorLevel[i].endTemp))
					{
						tempColor[j].tempData = tempDataList[j];
						tempColor[j].color = colorLevel[i].color;
					}
				}
			}


		}


		public void ClassifyCoordinateColor()
		{
			int start = 0, end, j = 0;
			for(int i=0;i<tempColor.Length;i++)
			{
				if(tempColor[i].color != tempColor[i+1].color)
				{
					LineParaSetStru coordinateColor = new LineParaSetStru();
					end = i;
					coordinateColor.startPoint.x = tempColor[start].tempData.x;
					coordinateColor.startPoint.y = tempColor[start].tempData.y;
					coordinateColor.startPoint.x = tempColor[end].tempData.x;
					coordinateColor.startPoint.y = tempColor[end].tempData.x;
					coordinateColor.color = tempColor[start].color;
					start = i + 1;
					coordinateColorList.Add(coordinateColor);
				}
			}

		}
		
	}

	public struct TempClassificationLevel
	{
		public float startTemp;
		public float endTemp;
		public int color;
	}

	public struct TempDataStru
	{
		public double x;
		public double y;
		public float temp;
	}

	public struct TempColorStru
	{
		public TempDataStru tempData;
		public int color;
	}

	public struct LineParaSetStru
	{
		public Point startPoint;
		public Point endPoint;
		public int color;
	}
}
