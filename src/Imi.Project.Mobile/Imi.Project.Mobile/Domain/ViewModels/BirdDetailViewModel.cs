using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.ViewModels
{
    class BirdDetailViewModel
    {
        public Bird Bird { get; set; }

        public BirdDetailViewModel(Bird bird)
        {
            Bird = bird;
        }
    }
}
