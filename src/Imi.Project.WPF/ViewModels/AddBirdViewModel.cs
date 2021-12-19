
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Species;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Imi.Project.WPF.ViewModels
{
    public class AddBirdViewModel : INotifyPropertyChanged
    {
        private readonly IBirdApiService _birdApiService;
        private readonly ISpeciesApiService _speciesApiService;
        public AddBirdViewModel(IBirdApiService apiService, ISpeciesApiService speciesApiService)
        {
            _birdApiService = apiService;
            _speciesApiService = speciesApiService;
            InitData();
        }

        private async void InitData()
        {
            Species = null;
            Species =  await _speciesApiService.GetSpecies();
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
