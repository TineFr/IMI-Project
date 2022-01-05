using Imi.Project.Common.Enums;
using Imi.Project.WPF.Core.Entities;
using Imi.Project.WPF.Core.Interfaces;
using Imi.Project.WPF.Core.Models;
using Imi.Project.WPF.Events;
using Imi.Project.WPF.ViewModels;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;


namespace Imi.Project.WPF
{
    /// <summary>
    /// Interaction logic for AddBird.xaml
    /// </summary>
    public partial class AddBird : Window
    {

        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdApiService;
        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesApiService;
        private readonly IBaseApiService<CageModel, CageModel> _cageApiService;

        public delegate void RefreshList(object sender, BirdAddedOrEditedArgs e);
        public event RefreshList BirdAdded;

        private OpenFileDialog openFileDialog;
        private ImageInfo imageInfo;

        public AddBird(IBaseApiService<BirdRequestModel, BirdModel> birdApiService,
                       IBaseApiService<SpeciesModel, SpeciesModel> speciesApiService,
                       IBaseApiService<CageModel, CageModel> cageApiService)
        {
            InitializeComponent();
            _birdApiService = birdApiService;
            _speciesApiService = speciesApiService;
            _cageApiService = cageApiService;
            SetData();
        }

        private async void SetData()
        {
            cmbSpecies.ItemsSource = await _speciesApiService.GetAllAsync("species");
            cmbSpecies.SelectedIndex = 0;
            cmbCages.ItemsSource = await _cageApiService.GetAllAsync("me/cages");
            cmbCages.SelectedIndex = 0;
            cmbGender.ItemsSource = Enum.GetValues(typeof(Gender));
            cmbGender.SelectedIndex = 0;
            pkrDate.Text = DateTime.Today.ToString();
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newBird = new BirdRequestModel
            {
                Name = txtName.Text,
                HatchDate = DateTime.Parse(pkrDate.Text),
                CageId = ((CageModel)cmbCages.SelectedItem).Id,
                SpeciesId = ((SpeciesModel)cmbSpecies.SelectedItem).Id,
                Gender = (Gender)cmbGender.SelectedValue,
                Food = txtFood.Text,
                ImageInfo = imageInfo
            };
            var result = await _birdApiService.AddAsync("birds", newBird);
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
                BirdAdded?.Invoke(this, new BirdAddedOrEditedArgs(newBird.Name));
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
