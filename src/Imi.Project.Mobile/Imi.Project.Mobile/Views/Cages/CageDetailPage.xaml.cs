using Imi.Project.Mobile.Domain.Models;
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
    public partial class CageDetailPage : ContentPage
    {
        private static Cage cagedetail;
        public CageDetailPage(Cage cage)
        {
            InitializeComponent();
            cagedetail = cage;
            NavigationPage.SetHasNavigationBar(this, false);
        }


        protected override void OnAppearing()
        {
            BindingContext = new CageDetailViewModel(cagedetail);
        }
    }
}