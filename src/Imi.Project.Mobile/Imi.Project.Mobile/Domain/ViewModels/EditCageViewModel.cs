using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.ViewModels
{
    class EditCageViewModel
    {
        public Cage Cage { get; set; }

        public EditCageViewModel(Cage cage)
        {
            Cage = cage;
        }
    }
}
