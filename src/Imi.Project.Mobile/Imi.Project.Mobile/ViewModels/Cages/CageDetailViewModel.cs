using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.ViewModels
{
    public class CageDetailViewModel
    {
        public Cage Cage { get; set; }

        public CageDetailViewModel(Cage cage)
        {
            Cage = cage;
        }
    }
}
