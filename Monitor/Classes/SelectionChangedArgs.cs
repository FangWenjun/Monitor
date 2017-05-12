using System;

namespace Monitor.Classes
{
    public class SelectionChangedArgs: EventArgs
    {
        public int LayerHandle;
        public int SelectionCount;
    }
}
