using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.ViewModels
{
    public class EditMedicationViewModel
    {

            public Medication Medication { get; set; }

            public EditMedicationViewModel(Medication medication)
            {
                Medication = medication;
            }
        
    }
}
