using System;

namespace Imi.Project.WPF.Events
{
    public class BirdAddedOrEditedArgs : EventArgs
    {
        public string Bird { get; set; }

        public BirdAddedOrEditedArgs(string bird)
        {
            Bird = bird;
        }
    }
}
