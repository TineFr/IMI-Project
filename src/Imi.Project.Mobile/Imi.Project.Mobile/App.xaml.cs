using FreshMvvm;
using Imi.Project.Mobile.Core.Services;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Imi.Project.Mobile.Core;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //var loginPage = FreshPageModelResolver.ResolvePageModel<LoginViewModel>();
            //var loginContainer = new FreshNavigationContainer(loginPage, ContainerNames.AuthenticationContainer);
            //var mainpageContainer = new FreshTabbedNavigationContainer(ContainerNames.MainContainer);  

            //MainPage = loginContainer;
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
