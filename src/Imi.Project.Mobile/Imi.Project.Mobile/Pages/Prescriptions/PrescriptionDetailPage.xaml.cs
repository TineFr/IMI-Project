﻿using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Prescriptions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrescriptionDetailPage : ContentPage
    {
        public PrescriptionDetailPage(Prescription prescription)
        {
            InitializeComponent();
        }

    }
}

