using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.ViewModels
{
    public class EditBirdViewModel
    {
        public Bird Bird { get; set; }

        public IEnumerable<Core.Models.Species> Species { get; set; }

        public IEnumerable<Cage> Cages { get; set; }

        public int MyProperty { get; set; }

        public EditBirdViewModel(Bird bird, IEnumerable<Core.Models.Species> species, IEnumerable<Cage> cages)
        {
            Bird = bird;
            Species = species;
            Cages = cages;
        }
    }
}
