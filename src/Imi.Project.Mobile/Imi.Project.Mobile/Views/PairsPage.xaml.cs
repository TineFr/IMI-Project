﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PairsPage : ContentPage
    {
        public PairsPage()
        {
            InitializeComponent();
        }

        private void colvPairs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}