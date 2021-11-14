using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
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

        public async override void Init(object initData)
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


    }
}
