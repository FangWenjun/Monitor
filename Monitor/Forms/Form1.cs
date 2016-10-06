using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitor.Classes;

namespace Monitor
{
    public partial class MainForm : Form
    {
        private readonly AppDispatcher _dispatcher = new AppDispatcher();
        private static MainForm _form = null;
        public MainForm()
        {
            InitializeComponent();
            _form = this;
            Init();
        }
        private void Init()
        {
            this.InitMenus();
        }

        /// <summary>
        /// 初始化menu
        /// </summary>
        private void InitMenus()
        {
            Dispatcher.InitMenu(mnuControl.DropDownItems);
            Dispatcher.InitMenu(mnuWarnSetting.DropDownItems);
            Dispatcher.InitMenu(mnuRunSetup.DropDownItems);
            Dispatcher.InitMenu(mnuDeviceManage.DropDownItems);
            Dispatcher.InitMenu(mnuHelp.DropDownItems);
        }

        internal AppDispatcher Dispatcher
        {
            get { return _dispatcher; }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }




    }
}
