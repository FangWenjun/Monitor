using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapWinGIS;
using AxMapWinGIS;
using Monitor.Map;
using System.IO;

namespace Monitor
{
    public static class App
    {
		public  static List<GisPoint> m_PointList = new List<GisPoint>(); //用于保存数据库中温度点数据
		//sqlite数据库路径
		public static string dbname = "Data Source=" + new DirectoryInfo("../../../../").FullName + 
			"Monitor\\Monitor\\data\\data.db";//sqlite数据库路径


		
	
	}
}
