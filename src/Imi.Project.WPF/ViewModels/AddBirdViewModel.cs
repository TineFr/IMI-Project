
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Cages;
using Imi.Project.WPF.Models.Species;
using System.Collections.Generic;
using System.ComponentModel;

namespace Imi.Project.WPF.ViewModels
{
    public class AddBirdViewModel : INotifyPropertyChanged
    {
        private readonly IBirdApiService _birdApiService;
        private readonly ISpeciesApiService _speciesApiService;
        private readonly ICageApiService _cageApiService;
        public AddBirdViewModel(IBirdApiService apiService, ISpeciesApiService speciesApiService, ICageApiService cageApiService)
        {
            _birdApiService = apiService;
            _speciesApiService = speciesApiService;
            _cageApiService = cageApiService;
            InitData();
        }

        private async void InitData()
        {
            Species = null;
            Species = await _speciesApiService.GetSpecies();
            Cages = null;
            Cages = await _cageApiService.GetCages();
        }

        private IEnumerable<SpeciesApiResponse> species;

        public IEnumerable<SpeciesApiResponse> Species
        {
            get { return species; }
            set
            {
                species = value;
                RaisePropertyChanged(nameof(Species));
            }
        }

        private IEnumerable<CageApiResponse> cages;

        public IEnumerable<CageApiResponse> Cages
        {
            get { return cages; }
            set
            {
                cages = value;
                RaisePropertyChanged(nameof(Cages));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
