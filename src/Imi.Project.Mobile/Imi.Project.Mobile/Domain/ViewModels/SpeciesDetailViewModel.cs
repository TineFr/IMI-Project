using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.ViewModels
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
