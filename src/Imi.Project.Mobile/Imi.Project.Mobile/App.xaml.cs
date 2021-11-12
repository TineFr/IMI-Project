using FreshMvvm;
using Imi.Project.Mobile.Core.Services;
using Imi.Project.Mobile.Core.ViewModels;
using Imi.Project.Mobile.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            FreshPageModelResolver.PageModelMapper = new CustomFreshPageModelMapper( typeof(LoginPage).Namespace, typeof(LoginPage).Assembly.ToString());
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
