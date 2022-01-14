
using FreshMvvm;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.ViewModels.Birds;
using Imi.Project.Mobile.ViewModels.Cages;
using Imi.Project.Mobile.ViewModels.Prescriptions;
using Imi.Project.Mobile.ViewModels.SpeciesGuide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var mainPage = new FreshTabbedNavigationContainer();
            mainPage.AddTab<CagesViewModel>("Cages", null);
            mainPage.AddTab<BirdsViewModel>("Birds", null);
            mainPage.AddTab<HomeViewModel>("Home", null);
            mainPage.AddTab<PrescriptionsViewModel>("Medicines", null);
            mainPage.AddTab<SpeciesViewModel>("Species guide", null);

            //var test = mainPage.Children[2];
            var test = Children[2];
            CurrentPage = Children[2];


            //Application.Current.MainPage = mainPage;
        }



    }


}