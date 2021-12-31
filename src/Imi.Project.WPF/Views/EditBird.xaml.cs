using Imi.Project.Common.Dtos;
using Imi.Project.Common.Enums;
using Imi.Project.WPF.Events;
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
using Imi.Project.WPF.Models.Cages;
using Imi.Project.WPF.Models.Species;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;

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

        private Stream image;
        private string _imagePath;

        public delegate void RefreshList(object sender, BirdAddedOrEditedArgs e);
        public event RefreshList BirdEdited;
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

            if (image == null)
            {

            }
            else
            {
                editedBird.Image = image;
                editedBird.FileName = _imagePath;
            }




            var result = await _birdApiService.EditBird(_birdToUpdate.Id, editedBird);
            if (!ReferenceEquals(result, null)) MessageBox.Show($"Something went wrong\n{result}", null,
                                                                     MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBox.Show("Bird was succesfully updated!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                _birdToUpdate.Name = txtName.Text;
                BirdEdited?.Invoke(this, new BirdAddedOrEditedArgs(editedBird.Name));
                this.Close();
            }

        }


        private void btnChangeImage_Click(object sender, RoutedEventArgs e)
        {
            string path = "";
            string fileName = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;..."; ;
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                _imagePath = openFileDialog.FileName;
                fileName = Path.GetFileName(path);
                txtImage.Text = fileName;
            }

            var stream = new MemoryStream(File.ReadAllBytes(path).ToArray());
            image = stream;
        }
    }
}
