using FreshMvvm;
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

        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });
    }
}
