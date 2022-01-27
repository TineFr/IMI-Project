using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services;
using Imi.Project.Mobile.Validators;
using Imi.Project.Mobile.ViewModels;
using Plugin.FirebasePushNotification;
using Xamarin.Forms;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // api services

            FreshIOC.Container.Register<IAuthApiService, AuthApiService>();
            FreshIOC.Container.Register<IBaseApiService<BirdRequestModel, BirdModel>, BirdApiService>();
            FreshIOC.Container.Register<IBaseApiService<CageRequestModel, CageModel>, CageApiService>();
            FreshIOC.Container.Register<IBaseApiService<SpeciesModel, SpeciesModel>, BaseApiService<SpeciesModel, SpeciesModel>>();
            FreshIOC.Container.Register<IBaseApiService<DailyTaskModel, DailyTaskModel>, BaseApiService<DailyTaskModel, DailyTaskModel>>();
            FreshIOC.Container.Register<IBaseApiService<PrescriptionRequestModel, PrescriptionModel>, BaseApiService<PrescriptionRequestModel, PrescriptionModel>>();
            FreshIOC.Container.Register<IBaseApiService<MedicineModel, MedicineModel>, BaseApiService<MedicineModel, MedicineModel>>();


            // validators
            FreshIOC.Container.Register<IValidator<LoginRequestModel>, LoginModelValidator>();
            FreshIOC.Container.Register<IValidator<RegisterModel>, RegisterModelValidator>();
            FreshIOC.Container.Register<IValidator<PrescriptionRequestModel>, PrescriptionRequestModelValidator>();
            FreshIOC.Container.Register<IValidator<BirdRequestModel>, BirdRequestModelValidator>();
            FreshIOC.Container.Register<IValidator<CageRequestModel>, CageRequestModelValidator>();
            FreshIOC.Container.Register<IValidator<MedicineModel>, MedicineModelValidator>();


            // dependency services
            FreshIOC.Container.Register(DependencyService.Get<IImageService>());
            FreshIOC.Container.Register(DependencyService.Get<ISoundService>());

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginViewModel>());

            //    CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            //    CrossFirebasePushNotification.Current.OnNotificationOpened += Current_OnNotificationOpened;
        }

        //private void Current_OnNotificationOpened(object source, FirebasePushNotificationResponseEventArgs e)
        //{
        //    System.Diagnostics.Debug.WriteLine("Received");

        //}

        //private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        //{
        //    System.Diagnostics.Debug.WriteLine($"TOKEN : {e.Token}");
        //}

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
