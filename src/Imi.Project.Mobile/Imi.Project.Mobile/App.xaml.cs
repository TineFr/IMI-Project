using FreshMvvm;
using Imi.Project.Mobile.Core.Services;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Imi.Project.Mobile.ViewModels.Cages;
using Imi.Project.Mobile.ViewModels.Birds;
using Imi.Project.Mobile.ViewModels.Prescriptions;
using Imi.Project.Mobile.ViewModels.SpeciesGuide;
using Xamarin.Forms.PlatformConfiguration;


namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var mainPage = new FreshTabbedNavigationContainer();
            mainPage.AddTab<CagesViewModel>("Cages", null);
            mainPage.AddTab<BirdsViewModel>("Birds", null);
            mainPage.AddTab<HomeViewModel>("Home", null);
            mainPage.AddTab<PrescriptionsViewModel>("Medicines", null);
            mainPage.AddTab<SpeciesViewModel>("Species guide", null);
            MainPage = mainPage;


            //new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginViewModel>());

        }

        

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
