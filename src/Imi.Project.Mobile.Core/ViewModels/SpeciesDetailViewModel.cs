using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.ViewModels
{
    public class SpeciesDetailViewModel
    {
        public Species Species { get; set; }

        public SpeciesDetailViewModel(Species species)
        {
            Species = species;
        }
    }
}
