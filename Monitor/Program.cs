using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitor.Forms;

namespace Monitor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //1、先启动登陆窗口，输入用户名和密码  
            //Sign form1 = new Sign();
            //DialogResult isOk = form1.ShowDialog();
            //if (isOk == DialogResult.OK || isOk == DialogResult.Yes)
            //{
            //2、用户名密码验证后，启动主窗口
                Application.Run(new MainForm());
            //}
        }
    }
}
