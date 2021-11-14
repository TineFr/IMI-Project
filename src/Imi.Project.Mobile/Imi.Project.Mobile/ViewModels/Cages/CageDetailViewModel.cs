using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
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

        MockDailyTaskService dailytaskService = new MockDailyTaskService();


        private ObservableCollection<DailyTask> tasks;

        public ObservableCollection<DailyTask> Tasks
        {
            get { return tasks; }
            set
            { 
                tasks = value;
                RaisePropertyChanged(nameof(Tasks));
            }
        }


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

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            await RefreshTasks();
            base.ViewIsAppearing(sender, e);
        }

        private async Task RefreshTasks()
        {
            var tasks = dailytaskService.GetDailyTaskByCageId(Cage.Id);
            Tasks = null;
            Tasks = new ObservableCollection<DailyTask>(tasks);
        }

        public async override void Init(object initData)
        {
            Cage = initData as Cage;
            await RefreshTasks();
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
        public ICommand EditTaskCommand => new Command<DailyTask>(
             async (DailyTask dailyTask) =>
             {
                 if (dailyTask == null) return;
                 var edit = await Application.Current.MainPage.DisplayPromptAsync("Edit Task", null, "Save", "Cancel", null, 50, null, dailyTask.Name);

                 if (edit != null)
                 {
                     var taskToUpdate = await dailytaskService.GetDailyTaskById(dailyTask.Id);
                     taskToUpdate.Name = edit;
                     await dailytaskService.UpdateDailyTask(taskToUpdate);
                     await RefreshTasks();
                 }
             });
        public ICommand DeleteTaskCommand => new Command<DailyTask>(
             async (DailyTask dailyTask) =>
             {
                 var action = await Application.Current.MainPage.DisplayAlert("Do you wish to delete this task?", null, "YES", "CANCEL");
                 if (action)
                 {
                     await dailytaskService.DeleteDailyTask(dailyTask.Id);
                     await RefreshTasks();
                 }
             });

        public ICommand AddTaskCommand => new Command<DailyTask>(
             async (DailyTask dailyTask) =>
             {
                 var add = await Application.Current.MainPage.DisplayPromptAsync("Add Task", null, "Save", "Cancel", "ex:Refill water");

                 if (add != null)
                 {
                     DailyTask newTask = new DailyTask
                     {
                         Id = new Guid(),
                         Name = add,
                         IsDone = false,
                         CageId = Cage.Id
                     };
                     await dailytaskService.AddDailyTask(newTask);
                     await RefreshTasks();
                 };
             });

    }


}
