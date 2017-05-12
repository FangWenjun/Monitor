using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Monitor.Classes
{
    public class GetDataFromCSV
    {

        /// <summary>
        /// 将CSV文件的数据读取到DataTable中，包括了开始的标题行
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public static DataTable ReadCSVAddHead(string filePath)
        {
            Encoding encoding = Encoding.ASCII;
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            StreamReader sr = new StreamReader(fs, encoding);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                //strLine = Common.ConvertStringUTF8(strLine, encoding);
                //strLine = Common.ConvertStringUTF8(strLine);

                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
        }

        /// <summary>
        /// 将CSV文件的数据读取到DataTable中，没有开始的标题行
        /// </summary>
        /// <param name="filePath">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public static DataTable ReadCSV(string filePath)
        {
            Encoding encoding = Encoding.ASCII;
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            StreamReader sr = new StreamReader(fs, encoding);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                //strLine = Common.ConvertStringUTF8(strLine, encoding);
                //strLine = Common.ConvertStringUTF8(strLine);
                aryLine = strLine.Split(',');
                columnCount = aryLine.Length;
                for (int i = 0; i < columnCount; i++)
                {
                    DataColumn dc = new DataColumn();
                    dt.Columns.Add(dc);
                } 
                DataRow dr = dt.NewRow();
                for (int j = 0; j < columnCount; j++)
                {
                    dr[j] = aryLine[j];
                }
                dt.Rows.Add(dr);
                
            }
            sr.Close();
            fs.Close();
            return dt;
        }


        public static DataSet ReadCSVFolder(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            DataSet ds = new DataSet();
            //path为某个目录，如： “D:\Program Files”
            FileInfo[] inf = dir.GetFiles();
            string filename;
            foreach (FileInfo finf in inf)
            {
                DataTable dt = new DataTable();
                if (finf.Extension.Equals(".csv"))
                    //如果扩展名为“.xml”
                {
                    filename = finf.FullName ;
                    dt = ReadCSV(filename);

                }
                ds.Tables.Add(dt);
            }
            return ds;

        }


    }
    
}
