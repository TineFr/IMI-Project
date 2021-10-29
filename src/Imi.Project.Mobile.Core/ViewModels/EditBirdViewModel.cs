using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.ViewModels
{
    public class EditBirdViewModel
    {
        public Bird Bird { get; set; }

        public EditBirdViewModel(Bird bird)
        {
            Bird = bird;
        }
    }
}
