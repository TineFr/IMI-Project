using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.SpeciesGuide
{
    public class SpeciesViewModel : FreshBasePageModel
    {

        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesService;

        public SpeciesViewModel(IBaseApiService<SpeciesModel, SpeciesModel> speciesService)
        {
            _speciesService = speciesService;
        }

        #region properties


        private ObservableCollection<SpeciesModel> species;
        public ObservableCollection<SpeciesModel> Species
        {
            get { return species; }
            set
            {
                species = value;
                RaisePropertyChanged(nameof(Species));
            }
        }


        private bool search = false;

        public bool Search
        {
            get { return search; }
            set
            {
                search = value;
                RaisePropertyChanged(nameof(Search));
            }
        }
        #endregion
        public override void Init(object initData)
        {
            base.Init(initData);
            ShowSpeciesCommand.Execute(null);
        }
        private async Task RefreshBirds()
        {
            Species = null;
            var species = await _speciesService.GetAllAsync("species?ItemsPerPage=1000");
            Species = new ObservableCollection<SpeciesModel>(species);
        }

        #region commands
        public ICommand ShowSpeciesCommand => new Command(
         async () =>
         {
             Species = new ObservableCollection<SpeciesModel>(await _speciesService.GetAllAsync("species"));
         });

        public ICommand ViewSpeciesCommand => new Command<SpeciesModel>(
            async (SpeciesModel species) =>
            {
                await CoreMethods.PushPageModel<SpeciesDetailViewModel>(species);
            });
        public ICommand OpenSearchCommand => new Command(
           async () =>
           {
               Search = !Search;
               if (!Search) await RefreshBirds();
           });

        public ICommand FilterListCommand => new Command<string>(async (string query) =>
        {
            Species = null;
            var species = await _speciesService.GetAllAsync($"species?Search={query}");
            Species = new ObservableCollection<SpeciesModel>(species);
        });
        #endregion
    }
}
