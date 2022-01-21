using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Medicines
{
    class AddMedicineViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<MedicineModel, MedicineModel> _medicineService;
        private readonly IValidator<MedicineModel> _medicineModelValidator;

        public AddMedicineViewModel(IBaseApiService<MedicineModel, MedicineModel> medicationService,
                                     IValidator<MedicineModel> validator)
        {
            _medicineService = medicationService;
            _medicineModelValidator = validator;
        }

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

        private string usage;

        public string Usage
        {
            get { return usage; }
            set
            {
                usage = value;
                RaisePropertyChanged(nameof(Usage));
            }
        }
        #endregion

        #region validation properties

        private string nameMessage;
        public string NameMessage
        {
            get { return nameMessage; }
            set
            {
                nameMessage = value;
                RaisePropertyChanged(nameof(NameMessage));
            }
        }

        private string usageMessage;
        public string UsageMessage
        {
            get { return usageMessage; }
            set
            {
                usageMessage = value;
                RaisePropertyChanged(nameof(UsageMessage));
            }
        }

        #endregion

        #region commands

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 MedicineModel model = new MedicineModel
                 {
                     Name = Name,
                     Usage = Usage
                 };
                 var isValid = Validate(model);
                 if (isValid)
                 {
                     var response = await _medicineService.AddAsync($"medicines", model);
                     if (response.ErrorMessage is object)
                     {
                         await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "OK");
                     }
                     else await CoreMethods.PopPageModel(response);
                 }
             });

        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });

        #endregion

        private bool Validate(MedicineModel model)
        {
            ResetErrorMessages();
            var context = new ValidationContext<object>(model);
            var validationResult = _medicineModelValidator.Validate(context);
            foreach (var error in validationResult.Errors)
            {

                if (error.PropertyName == nameof(model.Name))
                {

                    NameMessage = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(model.Usage))
                {
                    UsageMessage = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }

        private void ResetErrorMessages()
        {
            NameMessage = "";
            UsageMessage = "";
        }
    }
}
