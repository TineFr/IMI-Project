using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Medicines
{
    public class EditMedicineViewModel : FreshBasePageModel
    {
        private readonly IMedicationService medicationService;

        public EditMedicineViewModel(IMedicationService medicationService)
        {
            this.medicationService = medicationService;
        }

        private MedicineModel medicationToEdit;

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
        public override void Init(object initData)
        {
            medicationToEdit = initData as MedicineModel;
            Name = medicationToEdit.Name;
            Usage = medicationToEdit.Usage;
            base.Init(initData);
        }
        #region commands

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 medicationToEdit.Name = Name;
                 medicationToEdit.Usage = Usage;
                 await medicationService.UpdateMedication(medicationToEdit);
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
