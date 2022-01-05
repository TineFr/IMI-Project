using Imi.Project.WPF.Core.Interfaces;
using Imi.Project.WPF.Core.Models;
using Imi.Project.WPF.Events;
using Imi.Project.WPF.ViewModels;
using Imi.Project.WPF.Views;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Imi.Project.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAuthApiService _authApiService;
        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdApiService;
        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesApiService;
        private readonly IBaseApiService<CageModel, CageModel> _cageApiService;
        public MainWindow(
                          IBaseApiService<SpeciesModel, SpeciesModel> speciesApiService,
                          IBaseApiService<CageModel, CageModel> cageApiService,
                          IBaseApiService<BirdRequestModel, BirdModel> birdApiService, 
                          IAuthApiService authApiService)
        {
            InitializeComponent();
            _birdApiService = birdApiService;
            _speciesApiService = speciesApiService;
            _cageApiService = cageApiService;
            _authApiService = authApiService;
            SetData();

        }

        private async void SetData()
        {
            var result = await _birdApiService.GetAllAsync("me/birds");
            if (result.ToList()[0].ErrorMessage is object)
            {
                MessageBox.Show(result.ToList()[0].ErrorMessage, null,
                                             MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else lstBirds.ItemsSource = result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stkDetails.Visibility = Visibility.Hidden;
        }

        private void LstBirds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstBirds.SelectedItem != null)
            {
                stkDetails.Visibility = Visibility.Visible;
                stkDetails.DataContext = new BirdDetailViewModel(lstBirds.SelectedItem as BirdModel);
            }
            else stkDetails.Visibility = Visibility.Hidden;
        }

        private void BtnAddBird_Click(object sender, RoutedEventArgs e)
        {
            AddBird addBird = new AddBird(_birdApiService, _speciesApiService, _cageApiService);
            addBird.BirdAdded += RefreshBirdList;
            addBird.Show();
        }

        private void BtnEditBird_Click(object sender, RoutedEventArgs e)
        {
            EditBird editBird = new EditBird(_birdApiService, _speciesApiService, _cageApiService,
                                                            (BirdModel)lstBirds.SelectedItem);
            editBird.BirdEdited += RefreshBirdList;
            editBird.Show();
        }

        private async void BtnDeleteBird_Click(object sender, RoutedEventArgs e)
        {
            var action = MessageBox.Show($"Are you sure you want to delete this bird?", "Hold!",
                                                         MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (action == MessageBoxResult.Yes)
            {
                var birdToDelete = (BirdModel)lstBirds.SelectedItem;
                var result = await _birdApiService.DeleteAsync($"birds/{birdToDelete.Id}");
                if (result is object) MessageBox.Show(result.ErrorMessage, null,
                                             MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                {
                    MessageBox.Show("Bird was succesfully deleted!", "Success",
                                         MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    SetData();
                    lstBirds.SelectedIndex = -1;
                    stkDetails.Visibility = Visibility.Hidden;
                }
            }
        }
        private void RefreshBirdList(object sender, BirdAddedOrEditedArgs e)
        {
            SetData();
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            var action = MessageBox.Show($"Do you wish to log out?", "Hold!",
                                             MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (action == MessageBoxResult.Yes)
            {
                _authApiService.LogOut();
                Login window = new Login(_authApiService, _birdApiService, _cageApiService, _speciesApiService);
                window.Show();
                this.Close();
            }

        }
    }
}
