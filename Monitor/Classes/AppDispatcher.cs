using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Monitor;
using System.Data;
using Monitor.Help;

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
            if (HandleAlarmData(command)) return;
            
        }

        private bool HandleSystem(AppCommand command)
        {
            switch (command)
            {
                case AppCommand.StartMonitor:
                    Debug.Print("ok!");
                    return true;
                case AppCommand.CloseSystem:
               //     MainForm.Instance.Close();
                    return true;
                case AppCommand.StopMonitor:
                    return true;
                case AppCommand.Status:
                    Debug.Print("ok!!!");
                    return true;
            }
            return false;
        }

        private bool HandleAlarmData(AppCommand command)
        {
            switch(command)
            {
                case AppCommand.LoadAlarm:
                    Debug.Print("ok!!!");
                  
                    return true;
                case AppCommand.SeeDetails:
                   
                    return true;

            }
            return false;
        }

       
    }
}
