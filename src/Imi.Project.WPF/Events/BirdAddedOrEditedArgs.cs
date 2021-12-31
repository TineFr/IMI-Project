using Imi.Project.Common.Dtos;
using Imi.Project.WPF.Models.Birds;
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
