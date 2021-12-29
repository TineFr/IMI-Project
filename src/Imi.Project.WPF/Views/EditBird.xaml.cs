using Imi.Project.Common.Enums;
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
using Imi.Project.WPF.Models.Cages;
using Imi.Project.WPF.Models.Species;
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

namespace Imi.Project.WPF.Views
{
    /// <summary>
    /// Interaction logic for EditBird.xaml
    /// </summary>
    public partial class EditBird : Window
    {
        private readonly IBirdApiService _birdApiService;
        private readonly ISpeciesApiService _speciesApiService;
        private readonly ICageApiService _cageApiService;
        private readonly BirdApiResponse _birdToUpdate;
        public EditBird(IBirdApiService apiService,
                       ISpeciesApiService speciesApiService,
                       ICageApiService cageApiService,
                       BirdApiResponse birdToUpdate)
        {
            InitializeComponent();
            _birdApiService = apiService;
            _speciesApiService = speciesApiService;
            _cageApiService = cageApiService;
            _birdToUpdate = birdToUpdate;
            SetData();
        }

        private async void SetData()
        {
            cmbSpecies.ItemsSource = await _speciesApiService.GetSpecies();
            cmbCages.ItemsSource = await _cageApiService.GetCages();
            cmbGender.ItemsSource = Enum.GetValues(typeof(Gender));

            txtName.Text = _birdToUpdate.Name;
            txtFood.Text = _birdToUpdate.Food;
            cmbCages.Text = _birdToUpdate.Cage.Name;
            cmbSpecies.Text = _birdToUpdate.Species.Name;
            cmbGender.Text = _birdToUpdate.Gender.ToString();
            pkrDate.Text = _birdToUpdate.HatchDate.ToString();
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var editedBird = new Bird
            {
                Name = txtName.Text,
                HatchDate = DateTime.Parse(pkrDate.Text),
                CageId = ((CageApiResponse)cmbCages.SelectedItem).Id,
                SpeciesId = ((SpeciesApiResponse)cmbSpecies.SelectedItem).Id,
                Gender = (Gender)cmbGender.SelectedValue,
                Food = txtFood.Text,
            };

            var result = await _birdApiService.EditBird(_birdToUpdate.Id, editedBird);
            if (!ReferenceEquals(result, null)) MessageBox.Show($"Something went wrong\n{result}", null,
                                                                     MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBox.Show("Bird was succesfully updated!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
