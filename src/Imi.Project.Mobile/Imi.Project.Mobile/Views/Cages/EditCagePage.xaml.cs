﻿using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Mocking;
using Imi.Project.Mobile.Domain.Services.Mocking.Services;
using Imi.Project.Mobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views.Cages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCagePage : ContentPage
    {
        private static Cage cageToEdit;
        ICageService cageservice;
        public EditCagePage(Cage cage)
        {
            InitializeComponent();
            cageToEdit = cage;
            cageservice = new MockCageService();
            BindingContext = new EditCageViewModel(cageToEdit);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnRemove_Clicked(object sender, EventArgs e)
        {
            await cageservice.DeleteCage(cageToEdit.Id);
            await Navigation.PopToRootAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            await cageservice.UpdateCage(cageToEdit);
            await Navigation.PopAsync();
        }
    }
}

