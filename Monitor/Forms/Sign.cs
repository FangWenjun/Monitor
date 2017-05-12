using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;
using Monitor.Classes;
using Monitor.Help;

namespace Monitor.Forms
{
    public partial class Sign : Form
    {
        public Sign()
        {
            InitializeComponent();
			//注册登录按钮事件
            SignIn.Click += new EventHandler(btSignInClick);
			//注册关闭按钮事件
            Cancel.Click += new EventHandler(btCancelClick);
        }
		/// <summary>
		/// 登录按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btSignInClick(object sender, EventArgs e)
        {
            string mUserName = tBName.Text; 		
            string mPassword = tBPassword.Text;
            string mIP = tBIP.Text;
            GlobalVar.IP = tBIP.Text;
            int rTmp = 0;
            //1、判断ip、用户名、密码是否输入
            if((mUserName.Length != 0)&&(mPassword.Length != 0)&&(mIP.Length != 0))
            {
                //2、检查数据库中是否有相同用户名和密码
                rTmp = CheckUserPasswordInMysqlDB(GlobalVar.LoginConn, mUserName, mPassword);
                //3、若用户名和密码正确后将标志位设为ok
                if (rTmp > 0)
                    this.DialogResult = DialogResult.OK;
                else
                    MessageHelper.Info("密码不正确!");
            
            }
            else
                MessageHelper.Info("请先输入用户名和密码！");

            
        }
        /// <summary>
		/// 判断用户名密码是否正确
		/// </summary>
		/// <param name="Conn"></param>数据库连接句柄
		/// <param name="pUserName"></param>用户名
		/// <param name="pPassword"></param>密码
		/// <returns></returns>
        private int CheckUserPasswordInMysqlDB(string Conn, string pUserName, string pPassword)
        {
            MySqlConnection myCon = new MySqlConnection(Conn);
            try
            {
                myCon.Open();
                MySqlCommand cmd = myCon.CreateCommand();
                cmd.CommandText = string.Format("select * from user_setting_table where user='{0}' and password='{1}'",
                    pUserName, pPassword);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                myCon.Close();
				//返回数据库中查找到的对应用户名和密码的个数，返回值为1，则用户名和密码正确
				return ds.Tables[0].Rows.Count;
            }
            catch
            {
                MessageHelper.Info("用户登录时MYSQL数据库连接失败！");

            }
            return 0;
        }
		/// <summary>
		/// 关闭登录框事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btCancelClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }




    }
}
