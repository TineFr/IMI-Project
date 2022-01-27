using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.SpeciesGuide
{
    public class SpeciesDetailViewModel : FreshBasePageModel
    {
        private readonly ISoundService _soundService;
        private bool isPlaying;
        public SpeciesDetailViewModel(ISoundService soundService)
        {
            _soundService = soundService; 
        }
        private SpeciesModel species;
        public SpeciesModel Species
        {
            get { return species; }
            set
            {
                species = value;
                RaisePropertyChanged(nameof(Species));
            }
        }
        public override void Init(object initData)
        {
            Species = initData as SpeciesModel;
            base.Init(initData);
        }
        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                _soundService.StopSound();
                isPlaying = false;
            }

        }
        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });

        public ICommand PlaySoundCommand => new Command(
             async () =>
             {
                 if (isPlaying)
                 {
                      _soundService.StopSound();
                        isPlaying = false;
                 }
                 else {
                     isPlaying = true;
                     await _soundService.PlayBirdSound(Species.Name.ToLower() + ".mp3");
                 }
             });
    
    }
}
