using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.ViewModels
{
    public class BirdDetailViewModel
    {
        public Bird Bird { get; set; }

        public BirdDetailViewModel(Bird bird)
        {
            Bird = bird;
        }
    }
}
