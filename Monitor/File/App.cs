using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using File;
using MapWinGIS;


namespace File.Classes
{
    public static class App
    {
        private static Project _project = new Project();

        public static AxMap Map			   
        {
            get { return File.Instance.FileMap; }
        }

        public static Project Project
        {
            get { return _project; }
        }

        public static void LoadMapState(string filename)
        {
            App.Map.LockWindow(tkLockMode.lmLock);
            try
            {
                App.Map.LoadMapState(filename, null);
           //     InitMap();
            }
            finally
            {
                App.Map.LockWindow(tkLockMode.lmUnlock);
            }
        }

   
   

    }
}
