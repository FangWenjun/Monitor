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

   
	}
}
