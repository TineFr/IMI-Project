using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.ViewModels.Cages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Cages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class CageDetailPage : ContentPage
    {
        public CageDetailPage(Cage cage)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
