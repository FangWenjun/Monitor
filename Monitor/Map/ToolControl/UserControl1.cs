using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MapWinGIS;
using AxMapWinGIS;
using Monitor;
using Monitor.Map;
using ToolBar.Classes;

namespace ToolBar
{
    public partial class ToolControl: UserControl
    {
        private AxMap map = null;
		private ControlMapForm mapform;
		private int mainLayerHandle;


        private readonly AppDispatcher _dispatcher = new AppDispatcher();
        protected string Filename { get; set; }

        private static ToolControl _file = null;

        public  AxMap Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
            }
        }

		public int MainLayerHandle
		{
			set { mainLayerHandle = value; }
		}

		public ControlMapForm MapForm
		{
			set { mapform = value; }
			get { return mapform; }
		}

	

        public ToolControl()
        {
			
            InitializeComponent();
            _file = this;
            InitMenus();
     //       Dispatcher.InitMoveEvent();
			
     
        }

        public static ToolControl Instance
        {
            get { return _file; }
        }

        private void InitMenus()
        {
			
            Dispatcher.InitMenu(_toolStripLayer.Items);
			
        }

		public void SetMainLayerHandle()
		{
			Dispatcher.LayerHandle = mainLayerHandle;

		}

		public void InitAttri()
		{
			Dispatcher.Map = Map;
			Dispatcher.MapForm = MapForm;

		}

        internal AppDispatcher Dispatcher
        {
            get { return _dispatcher; }
        }

     
    }
}
