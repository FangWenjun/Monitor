using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using File.Classes;
using System.IO;
using MapWinGIS;
using AxMapWinGIS;
using Monitor;
using Monitor.Map;

namespace File
{
    public partial class File: UserControl
    {
        private AxMap filemap = null;

        public const string WINDOW_TITLE = "MWLite";

        private readonly AppDispatcher _dispatcher = new AppDispatcher();
        protected string Filename { get; set; }

        private static File _file = null;

        public  AxMap FileMap
        {
            get
            {
                return filemap;
            }
            set
            {
                filemap = value;
            }
        }

        public File()
        {
			filemap = MapForm.MapFormAttri.Map;
            InitializeComponent();
            _file = this;
            InitMenus();
            Dispatcher.InitMoveEvent();
     
        }

        public static File Instance
        {
            get { return _file; }
        }

        private void InitMenus()
        {
            Dispatcher.InitMenu(_toolStripLayer.Items);
        }

        internal AppDispatcher Dispatcher
        {
            get { return _dispatcher; }
        }

     
    }
}
