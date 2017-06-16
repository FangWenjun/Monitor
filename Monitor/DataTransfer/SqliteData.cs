using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using Monitor.Map;

namespace Monitor.DataTransfer
{
	public class SqliteData
	{
		private SQLiteConnection dbConnection;

		private string path;

		public DataTable datatable = new DataTable();

		public SqliteData(string path)
		{
			this.path = path;

		}
		public DataTable readData(string tablename)
		{
			dbConnection = new SQLiteConnection(path);
			string sql = "select * from "+ tablename;
			try
			{
				dbConnection.Open();
				SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, dbConnection);
				adapter.Fill(datatable);
				dbConnection.Close();

			}
			catch(Exception e)
			{
				MessageHelper.Info("slite数据库连接失败！" + e.ToString());
			}
			return datatable;

		}
	}
}
