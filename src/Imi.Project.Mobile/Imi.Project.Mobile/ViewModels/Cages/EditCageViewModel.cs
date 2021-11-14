using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class EditCageViewModel : FreshBasePageModel
    {
        MockCageService cageservice = new MockCageService();
        private Cage cageToEdit;

        #region properties

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

        private string location;
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }

        #endregion

        public EditCageViewModel(Cage cage)
        {
            cageToEdit = cage;
            Name = cage.Name;
            Location = cage.Location;
            Image = cage.Image;
        }

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 cageToEdit.Name = Name;
                 cageToEdit.Location = Location;
                 cageToEdit.Image = Image;
                 await cageservice.UpdateCage(cageToEdit);
                 await CoreMethods.PopPageModel(cageToEdit);
             });



    }
}
