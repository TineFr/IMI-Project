using Imi.Project.Common.Enums;
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
using Imi.Project.WPF.Models.Cages;
using Imi.Project.WPF.Models.Species;
using Imi.Project.WPF.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Imi.Project.WPF
{
    /// <summary>
    /// Interaction logic for AddBird.xaml
    /// </summary>
    public partial class AddBird : Window
    {
        private readonly IBirdApiService _birdApiService;
        private readonly ISpeciesApiService _speciesApiService;
        private readonly ICageApiService _cageApiService;
        public AddBird(IBirdApiService apiService, ISpeciesApiService speciesApiService, ICageApiService cageApiService)
        {
            InitializeComponent();
            _birdApiService = apiService;
            _speciesApiService = speciesApiService;
            _cageApiService = cageApiService;
            SetData();
        }

        private async void SetData()
        {
            cmbSpecies.ItemsSource = await _speciesApiService.GetSpecies();
            cmbCages.ItemsSource = await _cageApiService.GetCages();
            cmbGender.ItemsSource = Enum.GetValues(typeof(Gender));
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newBird = new Bird
            {
                Name = txtName.Text,
                HatchDate = DateTime.Parse(pkrDate.Text),
                CageId = ((CageApiResponse)cmbCages.SelectedItem).Id,
                SpeciesId = ((SpeciesApiResponse)cmbSpecies.SelectedItem).Id,
                Gender = (Gender)cmbGender.SelectedValue,
                Food = txtFood.Text,
            };

            var result = await _birdApiService.AddBird(newBird);
            if (!ReferenceEquals(result, null)) MessageBox.Show($"Something went wrong\n{result}", null,
                                                                     MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBox.Show("Bird was succesfully added!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                ClearBoxes();
            }
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();  
        }

        private void ClearBoxes()
        {
            txtName.Text = "";
            txtFood.Text = "";
            pkrDate.Text = DateTime.Now.ToString();
            cmbCages.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;
            cmbSpecies.SelectedIndex = -1;
        }
    }
}
