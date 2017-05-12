using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitor.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using Monitor.Help;

namespace Monitor.Classes
{
    public class GetDataFromSql
    {
        string mIP = GlobalVar.IP;
        public DataSet data = new DataSet();
        MySqlConnection myCon;
        public void GetFormData(string Conn, string pSqlTable)
        {
            myCon = new MySqlConnection(Conn);
            try
            {
                myCon.Open();
                MySqlCommand cmd = myCon.CreateCommand();
                cmd.CommandText = string.Format("select * from {0}", pSqlTable);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(data);
               
            }
            catch
            {
                MessageHelper.Info("数据库连接失败！");

            }

        }

        public bool ReadBlobToFile(string Conn, string pSqlTable,string idValue, string idField,
            string blobField, string outFileFullName)
        {
            int PictureCol = 0;  
  
            outFileFullName = outFileFullName.Trim();
            myCon = new MySqlConnection(Conn);
            try  
            {
                myCon.Open();
                MySqlCommand cmd = myCon.CreateCommand();
                cmd.CommandText = string.Format("select " + blobField + " from " + 
                    pSqlTable + " where " + idField + " = '" + idValue + "'");
                MySqlDataReader myReader = cmd.ExecuteReader();  
                myReader.Read();  
  
                if (myReader.HasRows == false)  
                {  
                    return false;  
                }  
  
                byte[] b = new byte[myReader.GetBytes(PictureCol, 0, null, 0, int.MaxValue) - 1];  
                myReader.GetBytes(PictureCol, 0, b, 0, b.Length);  
                myReader.Close();  
  
                System.IO.FileStream fileStream = new System.IO.FileStream(  
                    outFileFullName, System.IO.FileMode.Create, System.IO.FileAccess.Write);  
                fileStream.Write(b, 0, b.Length);  
                fileStream.Close();  
            }  
            catch  
            {  
                return false;  
            }  
  
            return true;  
        }

        ~GetDataFromSql()
        {
            if(myCon!=null)
                myCon.Close();
        }

        public static GetDataFromSql[] GetMapTravelData()
        {
            int i = 0;
            GetDataFromSql Disturb_Cable_Configure = new GetDataFromSql();  //路线配置信息
            Disturb_Cable_Configure.GetFormData(GlobalVar.SqlConn, "disturb_cable_configure");
            int MapNum = Disturb_Cable_Configure.data.Tables[0].Rows.Count;
            string[] TableName = new string[MapNum];
            foreach (DataRow row in Disturb_Cable_Configure.data.Tables[0].Rows)
            {
                TableName[i] = row[9].ToString() + "map_travel";
                i++;
            }
            GetDataFromSql[] MapTravel = new GetDataFromSql[MapNum];
            for (i = 0; i < MapNum; i++)
            {
                MapTravel[i] = new GetDataFromSql();
            }

            // GetDataFromSql[] MapTravel = new GetDataFromSql[]{new GetDataFromSql(),};
            for (i = 0; i < MapNum; i++)
            {
                MapTravel[i].GetFormData(GlobalVar.SqlConn, TableName[i]);
            }
            return MapTravel;
        }

    }
}
