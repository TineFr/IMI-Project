using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Birds
{
    public class BirdsViewModel :FreshBasePageModel  
    {
        private readonly IBirdService birdService;

        public BirdsViewModel(IBirdService birdService)
        {
            this.birdService = birdService;
        }

        #region properties


        private ObservableCollection<Bird> birds;
        public ObservableCollection<Bird> Birds
        {
            get { return birds; }
            set
            {
                birds = value;
                RaisePropertyChanged(nameof(Birds));
            }
        }
        #endregion
        public override void Init(object initData)
        {
            base.Init(initData);
            ShowBirdsCommand.Execute(null);
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await RefreshBirds();
        }


        private async Task RefreshBirds()
        {
            var birds = await birdService.GetAllBirds();
            Birds = null;
            Birds = new ObservableCollection<Bird>(birds);
        }

        #region commands
        public ICommand ShowBirdsCommand => new Command(
         async () => {
             Birds = await birdService.GetAllBirds();
         });

        public ICommand ViewBirdCommand => new Command<Bird>(
            async (Bird bird) =>
            {
                await CoreMethods.PushPageModel<BirdDetailViewModel>(bird);
            });
        public ICommand AddBirdCommand => new Command(
                async () =>
                {
                    await CoreMethods.PushPageModel<AddBirdViewModel>();
                });

        #endregion
    }
}
