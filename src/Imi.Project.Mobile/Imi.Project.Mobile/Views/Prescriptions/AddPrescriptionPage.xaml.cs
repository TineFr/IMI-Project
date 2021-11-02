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
    public partial class AddPrescriptionPage : ContentPage
    {
        IBirdService birdService;
        IMedicationService medicationService;
        IPrescriptionService PrescriptionService;
        public AddPrescriptionPage()
        {
            InitializeComponent();
            birdService = new MockBirdService();
            medicationService = new MockMedicationService();
            PrescriptionService = new MockPrescriptionService();
        }

        protected async override void OnAppearing()
        {
            var medications = await medicationService.GetAllMedications();
            var birds = await birdService.GetAllBirds();
            BindingContext = new AddPrescriptionViewModel(medications, birds);
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var medication = await medicationService.GetAllMedications();
            var birds = await birdService.GetAllBirds();

            Prescription newPrescription = new Prescription
            {
                Id = new Guid(),
                MedicationId = medication.ToArray()[pkrMedicine.SelectedIndex].Id,
                BirdIds = new List<Guid>
                {
                    birds.ToArray()[pkrBirds.SelectedIndex].Id
                },
                StartDate = pkrStartDate.Date.ToString("d"),
                EndDate = pkrEndDate.Date.ToString("d")
            };
            await PrescriptionService.AddPrescription(newPrescription);
            await Navigation.PopAsync();
        }
    }
}