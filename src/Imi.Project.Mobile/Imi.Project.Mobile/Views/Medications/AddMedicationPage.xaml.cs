using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views.Medications
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMedicationPage : ContentPage
    {
        IMedicationService medicationService;
        public AddMedicationPage()
        {
            InitializeComponent();
            medicationService = new MockMedicationService();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Medication newMedication = new Medication
            {
                Id = new Guid(),
                Name = entrName.Text,
                Usage = entrUsage.Text

            };
            await medicationService.AddMedication(newMedication);
            await Navigation.PopAsync();
        }
    }
}