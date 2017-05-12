using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor.Help
{
    public static class MessageHelper
    {
        public static string APP_NAME = "光纤周界安防在线监测系统";

        public static void Info(string msg)
        {
            MessageBox.Show(msg, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		public static void Warn(string msg)
		{
			MessageBox.Show(msg, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
