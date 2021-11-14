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

        public Cage Cage { get; set; }

        public CageDetailViewModel()
        {
          
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

        public ICommand EditCageCommand => new Command(
         async () =>
         {
             await CoreMethods.PushPageModel<EditCageViewModel>(Cage);
         });
    }

        
}
