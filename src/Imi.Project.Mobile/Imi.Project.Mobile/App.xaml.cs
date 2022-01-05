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
using Imi.Project.Mobile.Customs;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Services.Api;
using Imi.Project.Mobile.Core.Models;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // mock services

            FreshIOC.Container.Register<IBirdService, MockBirdService>();
            FreshIOC.Container.Register<ISpeciesService, MockSpeciesService>();
            FreshIOC.Container.Register<ICageService, MockCageService>();
            FreshIOC.Container.Register<IMedicationService, MockMedicationService>();
            FreshIOC.Container.Register<IPrescriptionService, MockPrescriptionService>();
            FreshIOC.Container.Register<IDailyTaskService, MockDailyTaskService>();

            // api services

            FreshIOC.Container.Register<IAuthApiService, AuthApiService>();
            FreshIOC.Container.Register<IBaseApiService<BirdRequestModel, BirdModel>, BirdApiService>();
            FreshIOC.Container.Register<IBaseApiService<CageModel, CageModel>, BaseApiService<CageModel, CageModel>>();
            FreshIOC.Container.Register<IBaseApiService<SpeciesModel, SpeciesModel>, BaseApiService<SpeciesModel, SpeciesModel>>();
            FreshIOC.Container.Register<IBaseApiService<DailyTaskModel, DailyTaskModel>, BaseApiService<DailyTaskModel, DailyTaskModel>>();




            //var mainPage = new CustomContainer();
            //mainPage.FixedMode = true;
            //mainPage.BarBackgroundColor = Color.White;
            //mainPage.BarTextColor = Color.Black;
            //mainPage.AddTab<HomeViewModel>("home", "home24.png");
            //mainPage.AddTab<CagesViewModel>("cages", "cage24.png");
            //mainPage.AddTab<BirdsViewModel>("birds", "bird24.png");
            //mainPage.AddTab<PrescriptionsViewModel>("meds", "medication24.png");
            //mainPage.AddTab<SpeciesViewModel>("guide", "guide24.png");
            //MainPage = mainPage;




            //new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginViewModel>());
            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginViewModel>());
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
