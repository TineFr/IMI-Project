using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Medicines
{
    public class MedicinesViewModel : FreshBasePageModel
    {
        private const string medicinesMessage = "There are no medicines yet. Add a new medicine!";
        private readonly IBaseApiService<MedicineModel, MedicineModel> _medicinesService;

        public MedicinesViewModel(IBaseApiService<MedicineModel, MedicineModel> medicineService)
        {
            _medicinesService = medicineService;
        }

        #region properties


        private ObservableCollection<MedicineModel> medicines;
        public ObservableCollection<MedicineModel> Medicines
        {
            get { return medicines; }
            set
            {
                medicines = value;
                RaisePropertyChanged(nameof(Medicines));
            }
        }

        private string noMedicinessMessage;

        public string NoMedicinessMessage
        {
            get { return noMedicinessMessage; }
            set
            {
                noMedicinessMessage = value;
                RaisePropertyChanged(nameof(NoMedicinessMessage));
            }
        }

        #endregion

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await RefreshMedicines();
        }


        private async Task RefreshMedicines()
        {
            Medicines = null;
            var medicines = await _medicinesService.GetAllAsync("me/medicines?ItemsPerPage=100");
            if (medicines.ToList()[0].ErrorMessage is object) NoMedicinessMessage = medicinesMessage;
            else Medicines = new ObservableCollection<MedicineModel>(medicines);
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            ShowMedicationsCommand.Execute(null);
        }


        #region commands
        public ICommand ShowMedicationsCommand => new Command(
             async () =>
             {
                 await RefreshMedicines();
             });
        public ICommand EditMeddicationCommand => new Command<MedicineModel>(
             async (medication) =>
             {
                 await CoreMethods.PushPageModel<EditMedicineViewModel>(medication);
             });

        public ICommand DeleteMedicationCommand => new Command<MedicineModel>(
             async (medicine) =>
             {
                 var action = await Application.Current.MainPage.DisplayAlert("Do you wish to delete this medication?", null, "YES", "CANCEL");
                 if (action)
                 {
                     await _medicinesService.DeleteAsync($"medicines/{medicine.Id}");
                     await RefreshMedicines();
                 }
             });

        public ICommand AddMedicationCommand => new Command<MedicineModel>(
             async (medication) =>
             {
                 await CoreMethods.PushPageModel<AddMedicineViewModel>(medication);
             });

        #endregion
    }
}
