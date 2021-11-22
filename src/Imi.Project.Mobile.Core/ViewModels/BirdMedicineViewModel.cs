using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.ViewModels
{
    public class BirdMedicineViewModel
    {

        public Medication Medication { get; set; }

        public BirdMedicineViewModel(Medication medication)
        {
            Medication = medication;

        }
    }
}
