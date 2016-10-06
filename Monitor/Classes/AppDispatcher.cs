using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Monitor.Classes
{
    internal class AppDispatcher : CommandDispatcher<AppCommand>
    {
        protected override void CommandNotFound(ToolStripItem item)
        {
            MessageHelper.Info("No handle is found: " + item.Name);
        }

        public override void Run(AppCommand command)
        {
            if (HandleSystem(command)) return;
            
        }

        private bool HandleSystem(AppCommand command)
        {
            switch (command)
            {
                case AppCommand.StartMonitor:
                    Debug.Print("ok!");
                    return true;
                case AppCommand.CloseSystem:
                    return true;
                case AppCommand.StopMonitor:
                    return true;
            }
            return false;
        }

       
    }
}
