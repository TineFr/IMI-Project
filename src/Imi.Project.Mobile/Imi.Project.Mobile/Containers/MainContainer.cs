using Imi.Project.Mobile.Customs;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.ViewModels.Birds;
using Imi.Project.Mobile.ViewModels.Cages;
using Imi.Project.Mobile.ViewModels.Prescriptions;
using Imi.Project.Mobile.ViewModels.SpeciesGuide;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Imi.Project.Mobile.Containers
{
    public static class MainContainer
    {
        public static CustomContainer Get()
        {
            var mainPage = new CustomContainer
            {
                BarBackgroundColor = Color.White,
                BarTextColor = Color.Black
            };
            mainPage.AddTab<HomeViewModel>("home", "home24.png");
            mainPage.AddTab<CagesViewModel>("cages", "cage24.png");
            mainPage.AddTab<BirdsViewModel>("birds", "bird24.png");
            mainPage.AddTab<PrescriptionsViewModel>("meds", "medication24.png");
            mainPage.AddTab<SpeciesViewModel>("guide", "guide24.png");
            return mainPage;
        }
    }
}
