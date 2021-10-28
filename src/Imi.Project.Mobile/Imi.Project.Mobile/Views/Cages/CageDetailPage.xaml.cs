using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Mocking;
using Imi.Project.Mobile.Domain.Services.Mocking.Services;
using Imi.Project.Mobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views.Cages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class CageDetailPage : ContentPage
    {
        private static Cage cagedetail;

        IDailyTaskService taskservice;
        public CageDetailPage(Cage cage)
        {
            InitializeComponent();
            cagedetail = cage;
            taskservice = new MockDailyTaskService();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        protected override void OnAppearing()
        {
            BindingContext = new CageDetailViewModel(cagedetail);
            lstTasks.ItemsSource = taskservice.GetDailyTaskByCageId(cagedetail.Id);
        }

        private async void btnEditCage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCagePage(cagedetail));
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }

        private async void btnEditTask_Clicked(object sender, EventArgs e)
        {
            var selection = (ImageButton)sender;
            var dailyTask = selection.CommandParameter as DailyTask;
            if (dailyTask == null) return;
            var edit = await DisplayPromptAsync("Edit Task", null ,"Save", "Cancel", null , 1, null, dailyTask.Name);

            if (edit != null)
            {
                var taskToUpdate = await taskservice.GetDailyTaskById(dailyTask.Id);
                taskToUpdate.Name = edit;
                await taskservice.UpdateDailyTask(taskToUpdate);
                lstTasks.ItemsSource = taskservice.GetDailyTaskByCageId(cagedetail.Id);
            }



        }
    }
}
