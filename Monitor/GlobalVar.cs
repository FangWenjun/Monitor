using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Classes
{
	public static class GlobalVar
	{

		private static string sqlconn = "Database='disturb';Data source='127.0.0.1';User Id='root';Password='Hlxm123456';charset='utf8';pooling=true";
		public static string SqlConn
		{
			get { return sqlconn; }
			set { sqlconn = value; }
		}
		private static string ip;//主机ip
        public static string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        //远程数据库连接信息
     

        //本地用户名密码数据库连接信息
        private static string loginconn ="Database='disturb';Data Source='127.0.0.1';User Id='root';Password='Hlxm123456';charset='utf8';pooling=true";
        public static string LoginConn
        {
            get{return loginconn;}
            set{loginconn = value;}
        }

        private static GetDataFromSql disturb_sys_configure = new GetDataFromSql();  //基本配置信息
        public static GetDataFromSql Disturb_Sys_Configure
        {
            get { return disturb_sys_configure; }
        }

        private static GetDataFromSql map_image_configure = new GetDataFromSql();      //地图图片信息
        public static GetDataFromSql Map_Image_Configure
        {
            get { return map_image_configure; }
        }

        private static GetDataFromSql map_travel = new GetDataFromSql();           //地图轨迹信息
        public static GetDataFromSql Map_Travel
        {
            get { return map_travel; }
        }

        private static GetDataFromSql map_text_configure = new GetDataFromSql();     //地图标示信息
        public static GetDataFromSql Map_Text_Configure
        {
            get { return map_text_configure; }
        }
	}
}
