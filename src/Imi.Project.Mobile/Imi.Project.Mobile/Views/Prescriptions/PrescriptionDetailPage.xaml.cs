using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views.Prescriptions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrescriptionDetailPage : ContentPage
    {

        public Prescription Prescription { get; set; }
        IBirdService birdservice;
        IPrescriptionService prescriptionservice;

        public PrescriptionDetailPage(Prescription prescription)
        {
            InitializeComponent();
            Prescription = prescription;
            birdservice = new MockBirdService();
            prescriptionservice = new MockPrescriptionService();
        }


        protected override void OnAppearing()
        {
            BindingContext = new PrescriptionDetailViewModel(Prescription);
            colvBirds.ItemsSource = Prescription.Birds;
        }

        private async void btnRemoveBird_Clicked(object sender, EventArgs e)
        {
            var selection = (ImageButton)sender;
            var bird = selection.CommandParameter as Bird;
            bird.Prescriptions.Remove(Prescription.Id);
            var birdList = birdservice.GetBirdsByPrescription(Prescription);



            if (birdList.Count() == 0)
            {
                await prescriptionservice.DeletePrescription(Prescription.Id);
                await Navigation.PopAsync();
            }
            else
            {
                colvBirds.ItemsSource = birdList;
            }
        }

        private async void btnRemove_Clicked(object sender, EventArgs e)
        {
            var selection = (Button)sender;
            var prescription = selection.CommandParameter as Prescription;
            await prescriptionservice.DeletePrescription(prescription.Id);
            birdservice.GetBirdsByPrescription(prescription).ToList().ForEach(b => b.Prescriptions.Remove(prescription.Id));
            await Navigation.PopAsync();
        }
    }
}

