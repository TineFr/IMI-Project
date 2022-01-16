using Imi.Project.WPF.Core.Models;
using System;
using System.ComponentModel;

namespace Imi.Project.WPF.ViewModels
{
    public class BirdDetailViewModel : INotifyPropertyChanged
    {
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
        private string food;
        public string Food
        {
            get { return food; }
            set
            {
                food = value;
                RaisePropertyChanged(nameof(Food));
            }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                RaisePropertyChanged(nameof(Gender));
            }
        }
        private string image;

        public string Image 
        {
            get { return image; }
            set
            {
                image = value;
                RaisePropertyChanged(nameof(Image));
            }
        }

        private string cage;
        public string Cage
        {
            get { return cage; }
            set
            {
                cage = value;
                RaisePropertyChanged(nameof(Cage));
            }
        }
        private string species;
        public string Species
        {
            get { return species; }
            set
            {
                species = value;
                RaisePropertyChanged(nameof(Species));
            }
        }
        private string hatchDate;


        public string HatchDate
        {
            get { return hatchDate; }
            set
            {
                hatchDate = value;
                RaisePropertyChanged(nameof(HatchDate));
            }
        }

        public BirdDetailViewModel(BirdModel bird)
        {
            Name = bird.Name;
            HatchDate = bird.HatchDate.ToString();
            Food = bird.Food;
            Gender = bird.Gender.ToString();
            Species = bird.Species?.Name;
            Cage = bird.Cage?.Name;
            Image = bird.Image;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
