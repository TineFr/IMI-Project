using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.ViewModels.SpeciesGuide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.SpeciesGuide
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeciesDetailPage : ContentPage
    {
        public SpeciesDetailPage(Species species)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

    }
}