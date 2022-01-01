
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Cages;
using Imi.Project.WPF.Models.Species;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Imi.Project.WPF.ViewModels
{
    public class AddBirdViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IBirdApiService _birdApiService;
        private readonly ISpeciesApiService _speciesApiService;
        private readonly ICageApiService _cageApiService;
        public AddBirdViewModel()
        {
        }

        private int canAdd;

        public int CanAdd
        {
            get { return canAdd; }
            set 
            { 
                canAdd = value; 
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set
            {

                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                        return "Name is Required";
                }
                return null;
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
