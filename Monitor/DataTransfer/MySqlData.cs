using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Monitor.Map;

namespace Monitor.DataTransfer
{
	public static class MySqlData
	{
		public static string ip;
		public static MySqlConnection myCon;
		
		/// <summary>
		/// 从mysql数据库中读取数据；conn是数据库连接信息，psqltable是读取的表名
		/// </summary>
		/// <param name="Conn"></param>
		/// <param name="pSqlTable"></param>
		/// <returns></returns>
		public static DataTable ReadData(string Conn, string pSqlTable)
		{
			DataTable data = new DataTable();
			myCon = new MySqlConnection(Conn);
			try
			{
				myCon.Open();
				MySqlCommand cmd = myCon.CreateCommand();
				cmd.CommandText = string.Format("select * from {0}", pSqlTable);
				MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
				adap.Fill(data);
				myCon.Close();

			}
			catch
			{
				MessageHelper.Info("数据库连接失败！");
			}
			return data;

		}
	}
}
