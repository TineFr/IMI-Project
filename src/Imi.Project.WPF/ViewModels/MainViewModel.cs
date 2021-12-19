using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Imi.Project.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IBirdApiService _apiService;

        public MainViewModel(IBirdApiService apiService)
        {
            _apiService = apiService;
            FillMyBirds();
        }

        private async void FillMyBirds()
        {
            MyBirds = null;
            var myBirds = await _apiService.GetBirds();
            MyBirds = new ObservableCollection<BirdApiResponse>(myBirds);
        }

        private ObservableCollection<BirdApiResponse> myBirds;

        public ObservableCollection<BirdApiResponse> MyBirds
        {
            get { return myBirds; }
            set 
            {
                myBirds = value;
                RaisePropertyChanged(nameof(MyBirds));
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
