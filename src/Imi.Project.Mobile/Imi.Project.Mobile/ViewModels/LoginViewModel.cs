using FreshMvvm;
using Imi.Project.Mobile.Customs;
using Imi.Project.Mobile.ViewModels.Birds;
using Imi.Project.Mobile.ViewModels.Cages;
using Imi.Project.Mobile.ViewModels.Prescriptions;
using Imi.Project.Mobile.ViewModels.SpeciesGuide;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        public ICommand LoginCommand => new Command(() =>
        {
            var mainPage = new CustomContainer();
            mainPage.FixedMode = true;
            mainPage.BarBackgroundColor = Color.White;
            mainPage.BarTextColor = Color.Black;
            mainPage.AddTab<HomeViewModel>("home", "home24.png");
            mainPage.AddTab<CagesViewModel>("cages", "cage24.png");
            mainPage.AddTab<BirdsViewModel>("birds", "bird24.png");
            mainPage.AddTab<PrescriptionsViewModel>("meds", "medication24.png");
            mainPage.AddTab<SpeciesViewModel>("guide", "guide24.png");
            Application.Current.MainPage = mainPage;
        });
    }
}
