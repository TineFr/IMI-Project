using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class CageDetailViewModel : FreshBasePageModel
    {

        private readonly IBaseApiService<DailyTaskModel, DailyTaskModel> _dailyTaskService;

        public CageDetailViewModel(IBaseApiService<DailyTaskModel, DailyTaskModel> dailyTaskService)
        {
            _dailyTaskService = dailyTaskService;
        }

        private ObservableCollection<DailyTaskModel> tasks;

        public ObservableCollection<DailyTaskModel> Tasks
        {
            get { return tasks; }
            set
            { 
                tasks = value;
                RaisePropertyChanged(nameof(Tasks));
            }
        }


        private CageModel cage;
        public CageModel Cage
        {
            get { return cage; }
            set
            {
                cage = value;
                RaisePropertyChanged(nameof(Cage));
            }
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            await RefreshTasks();
            base.ViewIsAppearing(sender, e);
        }

        private async Task RefreshTasks()
        {
            var tasks = await _dailyTaskService.GetAllAsync($"cages/{Cage.Id}/dailytasks");
            Tasks = null;
            Tasks = new ObservableCollection<DailyTaskModel>(tasks);
        }

        public async override void Init(object initData)
        {
            Cage = initData as CageModel;
            await RefreshTasks();
            base.Init(initData);
        }
        public override void ReverseInit(object value)
        {
            var updatedCage = value as CageModel;
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

        public ICommand EditTaskCommand => new Command<DailyTaskModel>(
             async (DailyTaskModel dailyTask) =>
             {
                 if (dailyTask == null) return;
                 var edit = await Application.Current.MainPage.DisplayPromptAsync("Edit Task", null, "Save", "Cancel", null, 50, null, dailyTask.Description);

                 if (edit != null)
                 {
                     dailyTask.Description = edit;
                     dailyTask.CageId = Cage.Id;
                     var result = await _dailyTaskService.UpdateAsync($"dailytasks/{dailyTask.Id}", dailyTask);
                     await RefreshTasks();
                 }
             });
        public ICommand DeleteTaskCommand => new Command<DailyTaskModel>(
             async (DailyTaskModel dailyTask) =>
             {
                 var action = await Application.Current.MainPage.DisplayAlert("Do you wish to delete this task?", null, "YES", "CANCEL");
                 if (action)
                 {
                     await _dailyTaskService.DeleteAsync($"dailytasks/{dailyTask.Id}");
                     await RefreshTasks();
                 }
             });

        public ICommand AddTaskCommand => new Command(
             async () =>
             {
                 var add = await Application.Current.MainPage.DisplayPromptAsync("Add Task", null, "Save", "Cancel", "ex:Refill water");

                 if (add != null)
                 {
                     DailyTaskModel newTask = new DailyTaskModel
                     {
                         Id = new Guid(),
                         Description = add,
                         IsDone = false,
                         CageId = Cage.Id
                     };
                     await _dailyTaskService.AddAsync("dailytasks", newTask);
                     await RefreshTasks();
                 };
             });

    }


}
