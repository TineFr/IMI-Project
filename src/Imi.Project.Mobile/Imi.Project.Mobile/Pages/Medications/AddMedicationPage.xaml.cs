﻿using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Medications
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMedicationPage : ContentPage
    {
        public AddMedicationPage()
        {
            InitializeComponent();
        }
    }
}