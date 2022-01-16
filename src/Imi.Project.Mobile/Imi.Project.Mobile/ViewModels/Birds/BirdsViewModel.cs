﻿using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Birds
{
    public class BirdsViewModel : FreshBasePageModel
    {
        private const string birdsMessage = "There are no birds yet. Add a new bird!";
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

        private string noBirdsMessage;

        public string NoBirdsMessage
        {
            get { return noBirdsMessage; }
            set
            {
                noBirdsMessage = value;
                RaisePropertyChanged(nameof(NoBirdsMessage));
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
            Birds = null;
            NoBirdsMessage = null;
            var birds = await _birdApiService.GetAllAsync("me/birds");
            if (birds.ToList()[0].ErrorMessage is object) NoBirdsMessage = birdsMessage;
            else Birds = new ObservableCollection<BirdModel>(birds);
        }

        #region commands
        public ICommand ShowBirdsCommand => new Command(
         async () =>
         {
             await RefreshBirds();
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
