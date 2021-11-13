using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.ViewModels
{
    public class AddBirdViewModel
    {
        public IEnumerable<Core.Models.Species> Species { get; set; }
        public IEnumerable<Cage> Cages { get; set; }

        public AddBirdViewModel(IEnumerable<Core.Models.Species> species, IEnumerable<Cage> cages)
        {
            Species = species;
            Cages = cages;
        }
    }
}
