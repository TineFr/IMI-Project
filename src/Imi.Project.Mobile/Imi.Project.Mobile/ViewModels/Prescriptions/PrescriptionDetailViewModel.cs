using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class PrescriptionDetailViewModel : FreshBasePageModel
    {
        MockBirdService birdService = new MockBirdService();
        MockPrescriptionService prescriptionService = new MockPrescriptionService();
        #region properties
        public Prescription prescription { get; set; }
        public Prescription Prescription
        {
            get { return prescription; }
            set
            {
                prescription = value;
                RaisePropertyChanged(nameof(Prescription));
            }
        }

        public override void Init(object initData)
        {
            Prescription = initData as Prescription;
            base.Init(initData);
        }

        #endregion

        #region commands

        public ICommand RemoveBirdCommand => new Command<Bird>(
             async (Bird bird) =>
             {
                 var updateBird = await birdService.GetBirdById(bird.Id);
                 updateBird.Prescriptions.Remove(Prescription.Id);
                 await birdService.UpdateBird(updateBird);


                 Prescription.Birds.ToList().Remove(bird);

                 //var birdList = birdService.GetBirdsByPrescription(Prescription);
                 //if (birdList.Count() == 0)
                 //{
                 //    await prescriptionService.DeletePrescription(Prescription.Id);
                 //    await Navigation.PopAsync();
                 //}
                 //else
                 //{
                 //    colvBirds.ItemsSource = birdList;
                 //}
             });
        public ICommand DeleteCommand => new Command(
             async () =>
             {
                 var action = await CoreMethods.DisplayAlert("Do you wish to delete this prescription?", null, "YES", "NO");
                 if (action)
                 {
                     await prescriptionService.DeletePrescription(prescription.Id);
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
