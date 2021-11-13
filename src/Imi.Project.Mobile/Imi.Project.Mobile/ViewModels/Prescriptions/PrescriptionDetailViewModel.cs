using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.ViewModels
{
    public class PrescriptionDetailViewModel
    {

        public Prescription Prescription { get; set; }

        public PrescriptionDetailViewModel(Prescription prescription)
        {
            Prescription = prescription;

        }
    }
    
}
