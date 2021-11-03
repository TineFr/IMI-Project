﻿using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views.Medications
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMedicationPage : ContentPage
    {
        private static Medication medicationToEdit;
        IMedicationService medicationservice;
        public EditMedicationPage(Medication medication)
        {
            InitializeComponent();
            medicationToEdit = medication;
            medicationservice = new MockMedicationService();
            BindingContext = new EditMedicationViewModel(medicationToEdit);
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            await medicationservice.UpdateMedication(medicationToEdit);
            await Navigation.PopAsync();
        }
    }
}