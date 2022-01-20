using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Models.Api.Prescription;
using Imi.Project.Mobile.Core.Services.Api;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Validators;
using Imi.Project.Mobile.ViewModels;
using Xamarin.Forms;

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
            FreshIOC.Container.Register<IBaseApiService<CageRequestModel, CageModel>, CageApiService>();
            FreshIOC.Container.Register<IBaseApiService<SpeciesModel, SpeciesModel>, BaseApiService<SpeciesModel, SpeciesModel>>();
            FreshIOC.Container.Register<IBaseApiService<DailyTaskModel, DailyTaskModel>, BaseApiService<DailyTaskModel, DailyTaskModel>>();
            FreshIOC.Container.Register<IBaseApiService<PrescriptionModel, PrescriptionModel>, BaseApiService<PrescriptionModel, PrescriptionModel>>();
            FreshIOC.Container.Register<IBaseApiService<MedicineModel, MedicineModel>, BaseApiService<MedicineModel, MedicineModel>>();


            // validators
            FreshIOC.Container.Register<IValidator<LoginRequestModel>, LoginModelValidator>();
            FreshIOC.Container.Register<IValidator<RegisterModel>, RegisterModelValidator>();

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
