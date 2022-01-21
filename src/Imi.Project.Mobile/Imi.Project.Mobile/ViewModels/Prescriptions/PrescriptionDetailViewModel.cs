using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Prescriptions
{
    public class PrescriptionDetailViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdService;
        private readonly IBaseApiService<PrescriptionRequestModel, PrescriptionModel> _prescriptionService;

        public PrescriptionDetailViewModel(IBaseApiService<PrescriptionRequestModel, PrescriptionModel> prescriptionService, IBaseApiService<BirdRequestModel, BirdModel> birdService)
        {
            _prescriptionService = prescriptionService;
            _birdService = birdService;
        }

        #region properties
        public PrescriptionModel prescription { get; set; }
        public PrescriptionModel Prescription
        {
            get { return prescription; }
            set
            {
                prescription = value;
                RaisePropertyChanged(nameof(Prescription));
            }
        }

        #endregion

        public override void Init(object initData)
        {
            Prescription = initData as PrescriptionModel;
            base.Init(initData);
        }

        public override void ReverseInit(object value)
        {
            var updatedPrescription = value as PrescriptionModel;
            Prescription = updatedPrescription;
        }

        #region commands

        public ICommand RemoveBirdCommand => new Command<BirdModel>(
             async (BirdModel bird) =>
             {

                 Prescription.BirdIds.ToList().Remove(bird.Id);
                 var result = await _prescriptionService.UpdateAsync($"prescriptions/{Prescription.Id}", Prescription);
                 if (result.BirdIds.Count() == 0)
                 {
                     await _prescriptionService.DeleteAsync($"prescriptions/{prescription.Id}");
                     await CoreMethods.PopToRoot(true);
                 }
             });
        public ICommand DeleteCommand => new Command(
             async () =>
             {
                 var action = await CoreMethods.DisplayAlert("Do you wish to delete this prescription?", null, "YES", "NO");
                 if (action)
                 {
                     await _prescriptionService.DeleteAsync($"prescriptions/{prescription.Id}");
                     await CoreMethods.PopToRoot(true);
                 }
             });

        #endregion


        //private async void btnRemoveBird_Clicked(object sender, EventArgs e)
        //{
        //    var selection = (ImageButton)sender;
        //    var bird = selection.CommandParameter as Bird;
        //    bird.Prescriptions.Remove(Prescription.Id);
        //    var birdList = birdservice.GetBirdsByPrescription(Prescription);



        //    if (birdList.Count() == 0)
        //    {
        //        await prescriptionservice.DeletePrescription(Prescription.Id);
        //        await Navigation.PopAsync();
        //    }
        //    else
        //    {
        //        colvBirds.ItemsSource = birdList;
        //    }
        //}


    }
    
}
