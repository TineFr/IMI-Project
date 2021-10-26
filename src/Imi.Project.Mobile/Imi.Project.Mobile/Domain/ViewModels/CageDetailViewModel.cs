using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.ViewModels
{
    class CageDetailViewModel
    {
        public Cage Cage { get; set; }

        public CageDetailViewModel(Cage cage)
        {
            Cage = cage;
        }
    }
}
