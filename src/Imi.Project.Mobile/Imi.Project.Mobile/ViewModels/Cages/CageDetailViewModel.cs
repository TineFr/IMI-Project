using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class CageDetailViewModel : FreshBasePageModel
    {
        private Cage cage;
        public Cage Cage
        {
            get { return cage; }
            set 
            { 
                cage = value;
                RaisePropertyChanged(nameof(Cage));
            }
        }
        public override void Init(object initData)
        {
            Cage = initData as Cage;
            base.Init(initData);
        }
        public override void ReverseInit(object value)
        {
            var updatedCage = value as Cage;
            Cage = updatedCage;
        }

        public ICommand EditCageCommand => new Command<Cage>(
         async (Cage cage) =>
         {
             await CoreMethods.PushPageModel<EditCageViewModel>(cage);
         });

        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });
  
    }

        
}
