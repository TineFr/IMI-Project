using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Imi.Project.Mobile.ViewModels.Prescriptions
{
    public class AddPrescriptionViewModel : FreshBasePageModel
    {
        public IEnumerable<Medication> Medications { get; set; }
        public IEnumerable<Bird> Birds { get; set; }

        public AddPrescriptionViewModel(IEnumerable<Medication> medication, IEnumerable<Bird> birds)
        {
            Medications = medication;
            Birds = birds;
        }
    }
}
