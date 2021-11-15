using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.ViewModels.Birds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Birds
{
    public class BirdDetailViewModel : FreshBasePageModel
    {

        private Bird bird;
        public Bird Bird
        {
            get { return bird; }
            set
            {
                bird = value;
                RaisePropertyChanged(nameof(Bird));
            }
        }

        public override void Init(object initData)
        {
            Bird = initData as Bird;
            base.Init(initData);
        }
        public override void ReverseInit(object value)
        {
            var updatedBird = value as Bird;
            Bird = updatedBird;
        }
        
        public ICommand EditBirdCommand => new Command<Bird>(
         async (Bird bird) =>
         {
             await CoreMethods.PushPageModel<EditBirdViewModel>(bird);
         });
        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });


    }
}
