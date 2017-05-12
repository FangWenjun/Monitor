using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Monitor.Classes
{
    public abstract class CommandDispatcher<T> where T : struct, IConvertible
    {
        public bool CommandFromName(ToolStripItem item, ref T command)
        {
            string itemName = item.Name;
            itemName = itemName.ToLower();
            var prefixes = new[] { "tool", "mnu", "ctx" };
            foreach (var prefix in prefixes)
            {
                if (itemName.StartsWith(prefix) && itemName.Length > prefix.Length)
                    itemName = itemName.Substring(prefix.Length);
            }

            var dict = Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(v => v.ToString().ToLower(), v => v);
            if (dict.ContainsKey(itemName))
            {
                command = dict[itemName];
                return true;
            }

            Debug.Print("Command not found: " + itemName);

            var menu = item as ToolStripDropDownItem;
            if (menu != null && menu.DropDownItems.Count > 0)
                return false;

            if (item is ToolStripSeparator) return false;

            CommandNotFound(item);
            return false;
        }

        public bool CommandFromName(Button item, ref T command)
        {
            string itemName = item.Name;
            itemName = itemName.ToLower();
            var prefixes = new[] { "gB", "bh", "br" };
            foreach (var prefix in prefixes)
            {
                if (itemName.StartsWith(prefix) && itemName.Length > prefix.Length)
                    itemName = itemName.Substring(prefix.Length);
            }

            var dict = Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(v => v.ToString().ToLower(), v => v);
            if (dict.ContainsKey(itemName))
            {
                command = dict[itemName];
                return true;
            }

            Debug.Print("Command not found: " + itemName);
            return false;
        }
        public abstract void Run(T command);
        protected abstract void CommandNotFound(ToolStripItem item);
        public void InitMenu(ToolStripItemCollection items)
        {
            if (items == null)
                return;

            foreach (ToolStripItem item in items)
            {
                if (item.Tag == null)
                    item.Click += ItemClick;
                var menuItem = item as ToolStripDropDownItem;
                if (menuItem != null)
                {
                    InitMenu(menuItem.DropDownItems);
                }
            }

        }

        public void InitGroupBox(GroupBox items)
        {
            if (items == null)
                return;

            foreach (Button item in items.Controls)
            {
                if (item.Tag == null)
                    item.Click += ItemClick;
            }
        }

        public void RegisterPbEvent(TabPage items)
        {
            if (items == null)
                return;

            foreach (PictureBox item in items.Controls)
            {
                if (item.Tag == null)
                {
                    item.Click += ItemClick;
                    item.Tag = true;
                }
            }
        }

        private void ItemClick(object sender, EventArgs e)
        {
            if(sender is ToolStripItem)
            {
                var item = sender as ToolStripItem;
                if (item == null)
                    return;
                var command = Activator.CreateInstance<T>();
                if (CommandFromName(item, ref command))
                    Run(command);
            }
            else if(sender is Button)
            {
                var item = sender as Button;
                if (item == null)
                    return;
                var command = Activator.CreateInstance<T>();
                if (CommandFromName(item, ref command))
                    Run(command);
                
            }
            else if (sender is PictureBox)
            {
                var item = sender as PictureBox;
                if (item == null)
                    return;
                Debug.Print(item.Name.ToString());
            }
            
        }
    }
}
