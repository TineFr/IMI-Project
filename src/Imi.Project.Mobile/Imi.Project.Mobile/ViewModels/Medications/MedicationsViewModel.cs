using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.ViewModels.Medications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Medicines
{
    public class MedicationsViewModel : FreshBasePageModel
    {
        private readonly IMedicationService medicationService;

        public MedicationsViewModel(IMedicationService medicationService)
        {
            this.medicationService = medicationService;
        }

        #region properties


        private ObservableCollection<Medication> medications;
        public ObservableCollection<Medication> Medications
        {
            get { return medications; }
            set
            {
                medications = value;
                RaisePropertyChanged(nameof(Medications));
            }
        }
        #endregion

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await RefreshMedications();
        }


        private async Task RefreshMedications()
        {
            var medications = await medicationService.GetAllMedications();
            Medications = null;
            Medications = new ObservableCollection<Medication>(medications);
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            ShowMedicationsCommand.Execute(null);
        }


        #region commands
        public ICommand ShowMedicationsCommand => new Command(
             async () => {
                 Medications = await medicationService.GetAllMedications();
             });
        public ICommand EditMeddicationCommand => new Command<Medication>(
             async (Medication medication) =>
             {
                 await CoreMethods.PushPageModel<EditMedicationViewModel>(medication);
             });

        public ICommand DeleteMedicationCommand => new Command<Medication>(
             async (Medication medication) =>
             {
                 var action = await Application.Current.MainPage.DisplayAlert("Do you wish to delete this medication?", null, "YES", "CANCEL");
                 if (action)
                 {
                     await medicationService.DeleteMedication(medication.Id);
                     await RefreshMedications();
                 }
             });

        public ICommand AddMedicationCommand => new Command<Medication>(
             async (Medication medication) =>
             {
                 await CoreMethods.PushPageModel<AddMedicationViewMode>(medication);
             });

        #endregion
    }
}
