using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.ViewModels.Cages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Cages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class CageDetailPage : ContentPage
    {
        public CageDetailPage(Cage cage)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        //private async void btnEditCage_Clicked(object sender, EventArgs e)
        //{
        //    //await Navigation.PushAsync(new EditCagePage(cagedetail));
        //}

        //private async void btnBack_Clicked(object sender, EventArgs e)
        //{
        //   await Navigation.PopAsync();
        //}

        //private async void btnEditTask_Clicked(object sender, EventArgs e)
        //{
        //    //var selection = (ImageButton)sender;
        //    //var dailyTask = selection.CommandParameter as DailyTask;
        //    //if (dailyTask == null) return;
        //    //var edit = await DisplayPromptAsync("Edit Task", null ,"Save", "Cancel", null , 50, null, dailyTask.Name);

        //    //if (edit != null)
        //    //{
        //    //    var taskToUpdate = await taskservice.GetDailyTaskById(dailyTask.Id);
        //    //    taskToUpdate.Name = edit;
        //    //    await taskservice.UpdateDailyTask(taskToUpdate);
        //    //    lstTasks.ItemsSource = taskservice.GetDailyTaskByCageId(cagedetail.Id);
            



        //}

        //private void chkTask_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{


        //}

        //private async void btnAddTask_Clicked(object sender, EventArgs e)
        //{
        //    //var add = await DisplayPromptAsync("Add Task", null, "Save", "Cancel", "ex:Refill water");

        //    //if (add != null)
        //    //{
        //    //    DailyTask newTask = new DailyTask
        //    //    {
        //    //        Id = new Guid(),
        //    //        Name = add,
        //    //        IsDone = false,
        //    //        CageId = cagedetail.Id
                    
        //    //    };
        //    //    await taskservice.AddDailyTask(newTask);
        //    //    lstTasks.ItemsSource = taskservice.GetDailyTaskByCageId(cagedetail.Id);
        //    //}


        //}

        //private async void btnDeleteTask_Clicked(object sender, EventArgs e)
        //{
        //    //   var action =  await DisplayAlert("Do you wish to delete this task?", null, "YES", "CANCEL");
        //    //    if (action)
        //    //    {
        //    //        var selection = (ImageButton)sender;
        //    //        var dailyTask = selection.CommandParameter as DailyTask;
        //    //        await taskservice.DeleteDailyTask(dailyTask.Id);
        //    //        lstTasks.ItemsSource = taskservice.GetDailyTaskByCageId(cagedetail.Id);
        //    //    }


        //    //}
        //}
    }
}
