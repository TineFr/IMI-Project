using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class CagesViewModel : FreshBasePageModel
    {
        private const string cagesMessage = "There are no cages yet. Add a new cage!";
        private readonly IBaseApiService<CageRequestModel, CageModel> _cageService;

        public CagesViewModel(IBaseApiService<CageRequestModel, CageModel> cageService)
        {
            _cageService = cageService;
        }
        #region properties


        private ObservableCollection<CageModel> cages;
        public ObservableCollection<CageModel> Cages
        {
            get { return cages; }
            set
            {
                cages = value;
                RaisePropertyChanged(nameof(Cages));
            }
        }

        private string noCagesMessage;

        public string NoCagesMessage
        {
            get { return noCagesMessage; }
            set
            {
                noCagesMessage = value;
                RaisePropertyChanged(nameof(NoCagesMessage));
            }
        }

        #endregion
        public override void Init(object initData)
        {
            base.Init(initData);
            ShowCagesCommand.Execute(null);
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            NoCagesMessage = null;
            await RefreshCages();
        }


        private async Task RefreshCages()
        {
            Cages = null;
            var cages = await _cageService.GetAllAsync("me/cages");
            if (cages.ToList()[0].ErrorMessage is object) NoCagesMessage = cagesMessage;
            else Cages = new ObservableCollection<CageModel>(cages);

        }

        #region commands
        public ICommand ShowCagesCommand => new Command(
         async () =>
         {

             await RefreshCages();
         });

        public ICommand ViewCageCommand => new Command<CageModel>(
            async (CageModel cage) =>
            {
                await CoreMethods.PushPageModel<CageDetailViewModel>(cage);
            });
        public ICommand AddCageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<AddCageViewModel>();
            });
        #endregion

    }
}
