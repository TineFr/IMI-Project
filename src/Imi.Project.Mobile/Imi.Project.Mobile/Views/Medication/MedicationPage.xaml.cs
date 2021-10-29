﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Interfaces;

namespace Imi.Project.Mobile.Views.Medication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedicationPage : ContentPage
    {
        IMedicationService medicationservice;
        IBirdService birdservice;
        public MedicationPage()
        {
            InitializeComponent();
            medicationservice = new MockMedicationService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var medications = await medicationservice.GetAllMedications();
            colvMedication.ItemsSource = medications;
        }

        private void colvMedication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void btnShowBirds_Clicked(object sender, EventArgs e)
        {
            var selection = (Button)sender;
            var medication = selection.CommandParameter as Core.Models.Medication;
            if (medication == null) return;

            var birdlist = birdservice.GetBirdsByMedication(medication);
            await Navigation.PushAsync(new MedicationBirdsPage(birdlist));
        }
    }
}