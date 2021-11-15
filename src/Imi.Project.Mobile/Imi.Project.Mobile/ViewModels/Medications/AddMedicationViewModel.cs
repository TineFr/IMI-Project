using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Medications
{
    class AddMedicationViewMode : FreshBasePageModel
    {
        MockMedicationService medicationService = new MockMedicationService();

        #region properties

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private string usage;

        public string Usage
        {
            get { return usage; }
            set
            {
                usage = value;
                RaisePropertyChanged(nameof(Usage));
            }
        }
        #endregion

        #region commands

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 Medication newMedication = new Medication
                 {
                     Id = new Guid(),
                     Name = this.Name,
                     Usage = this.Usage

                 };
                 await medicationService.AddMedication(newMedication);
                 await CoreMethods.PopPageModel();
             });

        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });

        #endregion
    }
}
