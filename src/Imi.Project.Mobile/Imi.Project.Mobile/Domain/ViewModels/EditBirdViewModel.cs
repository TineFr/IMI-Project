using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.ViewModels
{
    class EditBirdViewModel
    {
        public Bird Bird { get; set; }

        public EditBirdViewModel(Bird bird)
        {
            Bird = bird;
        }
    }
}
