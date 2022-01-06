using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
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
        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdApiService;

        public BirdsViewModel(IBaseApiService<BirdRequestModel, BirdModel> birdApiService)
        {
            _birdApiService = birdApiService;
        }


        #region properties


        private ObservableCollection<BirdModel> birds;
        public ObservableCollection<BirdModel> Birds
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
            var birds = await _birdApiService.GetAllAsync("me/birds");
            Birds = null;
            Birds = new ObservableCollection<BirdModel>(birds);
        }

        #region commands
        public ICommand ShowBirdsCommand => new Command(
         async () => {
             Birds = new ObservableCollection<BirdModel>(await _birdApiService.GetAllAsync("birds"));
         });

        public ICommand ViewBirdCommand => new Command<BirdModel>(
            async (BirdModel bird) =>
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
