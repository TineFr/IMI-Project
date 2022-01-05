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

namespace Imi.Project.Mobile.ViewModels.SpeciesGuide
{
    public class SpeciesViewModel : FreshBasePageModel
    {
        private readonly ISpeciesService speciesService;

        public SpeciesViewModel(ISpeciesService speciesService)
        {
            this.speciesService = speciesService;
        }

        #region properties


        private ObservableCollection<Species> species;
        public ObservableCollection<Species> Species
        {
            get { return species; }
            set
            {
                species = value;
                RaisePropertyChanged(nameof(Species));
            }
        }
        #endregion
        public override void Init(object initData)
        {
            base.Init(initData);
            ShowSpeciesCommand.Execute(null);
        }


        //  Species (voorlopig) alleen lezen

        //protected async override void ViewIsAppearing(object sender, EventArgs e)
        //{
        //    base.ViewIsAppearing(sender, e);
        //    await RefreshSpecies();
        //}
        //private async Task RefreshSpecies()
        //{
        //    var species = await speciesService.GetAllSpecies();
        //    Species = null;
        //    Species = new ObservableCollection<Species>(species);
        //}

        #region commands
        public ICommand ShowSpeciesCommand => new Command(
         async () => {
             Species = await speciesService.GetAllSpecies();
         });

        public ICommand ViewSpeciesCommand => new Command<Species>(
            async (Species species) =>
            {
                await CoreMethods.PushPageModel<SpeciesDetailViewModel>(species);
            });
        #endregion
    }
}
