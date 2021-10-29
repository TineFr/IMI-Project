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

namespace Imi.Project.Mobile.Views.Medication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedicationBirdsPage : ContentPage
    {
        private static IEnumerable<Bird> Birds;
        private static Core.Models.Medication Medication;
        IBirdService birdservice;

       
        public MedicationBirdsPage(Core.Models.Medication medication, IEnumerable<Bird> birds)
        {
            InitializeComponent();
            Birds = birds;
            Medication = medication;
            birdservice = new MockBirdService();

        }

        protected override void OnAppearing()
        {
            BindingContext = new BirdMedicineViewModel(Medication);
            colvBirds.ItemsSource = Birds;
        }
        private async void colvBirds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void btnRemoveBird_Clicked(object sender, EventArgs e)
        {
            var selection = (ImageButton)sender;
            var bird = selection.CommandParameter as Bird;
            bird.Medications.Remove(Medication.Id);
            var birdList = birdservice.GetBirdsByMedication(Medication);
            

            if (birdList.Count() == 0)
            {
                await Navigation.PopAsync();
            }
            else
            {
                colvBirds.ItemsSource = birdList;
            }
        }


    }
}