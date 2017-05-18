using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monitor.Map
{
	public class MapAlgori
	{
		/// <summary>
		/// 在ais数据中找到鼠标位置的那组数据
		/// </summary>
		/// <param name="ais"></param>
		/// <param name="x"></param>经度
		/// <param name="y"></param>纬度
		/// <returns></returns>
		public static AISDataStru  FindAisPoint(AISData ais, double x, double y)
		{
			int num = ais.aisData.Length;
			double ais_x, ais_y;
			double[] ais_min = new double[num];
			for(int i = 0;i < num;i++)
			{
				ais_x = ais.aisData[i].longitude;
				ais_y = ais.aisData[i].latitude;
				ais_min[i] = Math.Abs(x - ais_x) + Math.Abs(y - ais_y);
			}
			int index = MinOfArray(ais_min);
			return ais.aisData[index];

		}


		/// <summary>
		/// 求一个double数组中的最小值的位置
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static int MinOfArray(double[] array)
		{
			double  temp = array[0];
			int index = 0;
			for(int i=1; i<array.Length; i++)
			{
				if(temp > array[i])
				{
					temp = array[i];
					index = i;
				}

			}
			return index;
			


		}
	}
}
