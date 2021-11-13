using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.ViewModels
{
    public class EditCageViewModel
    {
        public Cage Cage { get; set; }

        public EditCageViewModel(Cage cage)
        {
            Cage = cage;
        }
    }
}
