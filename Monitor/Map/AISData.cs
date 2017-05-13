using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace Monitor.Map
{
	public class AISData
	{
		public AISDataStru[] aisData;

		public void IntoAisData(DataTable table)
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
	}

	public class AISDataStru
	{
		public double longitude;
		public double latitude;
	}

}
