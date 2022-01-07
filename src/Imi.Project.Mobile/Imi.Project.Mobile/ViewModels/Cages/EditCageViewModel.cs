using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
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
        private readonly IBaseApiService<CageRequestModel, CageModel> _cageService;

        public EditCageViewModel(IBaseApiService<CageRequestModel, CageModel> cageService)
        {
            _cageService = cageService;
        }

        private CageModel cageToEdit;

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
        public override void Init(object initData)
        {
            cageToEdit = initData as CageModel;
            Name = cageToEdit.Name;
            Location = cageToEdit.Location;
            Image = cageToEdit.Image;
            base.Init(initData);
        }

        #region commands
        public ICommand DeleteCommand => new Command(
             async () =>
             {
                 var action = await CoreMethods.DisplayAlert("Do you wish to delete this cage?", null, "YES", "NO");
                 if (action)
                 {
                    var response =  await _cageService.DeleteAsync($"cages/{cageToEdit.Id}");
                     if (response is object)
                     {
                         await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "OK");
                     }
                     else await CoreMethods.PopToRoot(true);
                 }
             });

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 CageRequestModel model = new CageRequestModel
                 {
                     Name = Name,
                     Location = Location,
                 };
                 //cageToEdit.Image = Image;
                 var response = await _cageService.UpdateAsync($"cages/{cageToEdit.Id}", model);
                 if (response.ErrorMessage is object)
                 {
                     await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "OK");
                 }
                 await CoreMethods.PopPageModel(response);
             });

        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });
        #endregion
    }
}
