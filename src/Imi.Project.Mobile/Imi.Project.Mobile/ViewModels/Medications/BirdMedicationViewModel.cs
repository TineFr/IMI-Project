using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.ViewModels
{
    public class BirdMedicationViewModel : FreshBasePageModel
    {

        public MedicineModel Medication { get; set; }

        public BirdMedicationViewModel(MedicineModel medication)
        {
            Medication = medication;

        }
    }
}
