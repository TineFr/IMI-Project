using Imi.Project.Common.Enums;
using Imi.Project.WPF.Core.Entities;
using Imi.Project.WPF.Core.Interfaces;
using Imi.Project.WPF.Core.Models;
using Imi.Project.WPF.Events;
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
        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdApiService;
        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesApiService;
        private readonly IBaseApiService<CageModel, CageModel> _cageApiService;
        private readonly BirdModel _birdToUpdate;

        public delegate void RefreshList(object sender, BirdAddedOrEditedArgs e);
        public event RefreshList BirdEdited;

        private OpenFileDialog openFileDialog;
        private ImageInfo imageInfo;

        public EditBird(IBaseApiService<BirdRequestModel, BirdModel> birdApiService,
                       IBaseApiService<SpeciesModel, SpeciesModel> speciesApiService,
                       IBaseApiService<CageModel, CageModel> cageApiService,
                       BirdModel birdToUpdate)
        {
            InitializeComponent();
            _birdApiService = birdApiService;
            _speciesApiService = speciesApiService;
            _cageApiService = cageApiService;
            _birdToUpdate = birdToUpdate;
            SetData();
        }

        private async void SetData()
        {
            cmbSpecies.ItemsSource = await _speciesApiService.GetAllAsync("species");
            cmbCages.ItemsSource = await _cageApiService.GetAllAsync("me/cages");
            cmbGender.ItemsSource = Enum.GetValues(typeof(Gender));

            txtName.Text = _birdToUpdate.Name;
            txtFood.Text = _birdToUpdate.Food;
            cmbCages.Text = _birdToUpdate.Cage.Name;
            cmbSpecies.Text = _birdToUpdate.Species.Name;
            cmbGender.Text = _birdToUpdate.Gender.ToString();
            pkrDate.Text = _birdToUpdate.HatchDate.ToString();
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var editedBird = new BirdRequestModel
            {
                Name = txtName.Text,
                HatchDate = DateTime.Parse(pkrDate.Text),
                CageId = ((CageModel)cmbCages.SelectedItem).Id,
                SpeciesId = ((SpeciesModel)cmbSpecies.SelectedItem).Id,
                Gender = (Gender)cmbGender.SelectedValue,
                Food = txtFood.Text,
                ImageInfo = imageInfo
            };
            var result = await _birdApiService.UpdateAsync($"birds/{_birdToUpdate.Id}", editedBird);
            if (result.ErrorMessage is object)
            {
                MessageBox.Show(result.ErrorMessage, null,
                                                     MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (openFileDialog != null)
                    imageInfo.Image = new MemoryStream(File.ReadAllBytes(openFileDialog.FileName).ToArray());
            }
            else
            {
                MessageBox.Show("Bird was succesfully added!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                BirdAdded?.Invoke(this, new BirdAddedOrEditedArgs(editedBird.Name));
                this.Close();
            }
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;..."
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                if (!String.IsNullOrEmpty(path))
                {
                    imageInfo = new ImageInfo
                    {
                        Image = new MemoryStream(File.ReadAllBytes(path).ToArray()),
                        FileName = Path.GetFileName(path)
                    };
                    txtImage.Text = imageInfo.FileName;
                }
            }
        }
    }
}
