using Imi.Project.Common.Enums;
using Imi.Project.WPF.Events;
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
using Imi.Project.WPF.Models.Cages;
using Imi.Project.WPF.Models.Species;
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
        private readonly IBirdApiService _birdApiService;
        private readonly ISpeciesApiService _speciesApiService;
        private readonly ICageApiService _cageApiService;

        public delegate void RefreshList(object sender, BirdAddedOrEditedArgs e);
        public event RefreshList BirdAdded;

        private OpenFileDialog openFileDialog;
        private Stream image;
        private string _imagePath;
        public AddBird(IBirdApiService apiService,
                       ISpeciesApiService speciesApiService,
                       ICageApiService cageApiService)
        {
            InitializeComponent();
            _birdApiService = apiService;
            _speciesApiService = speciesApiService;
            _cageApiService = cageApiService;
            this.DataContext = new AddBirdViewModel();
            SetData();
        }

        private async void SetData()
        {
            cmbSpecies.ItemsSource = await _speciesApiService.GetSpecies();
            cmbSpecies.SelectedIndex = 0;
            cmbCages.ItemsSource = await _cageApiService.GetCages();
            cmbCages.SelectedIndex = 0;
            cmbGender.ItemsSource = Enum.GetValues(typeof(Gender));
            cmbGender.SelectedIndex = 0;
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

            newBird.Image = image;
            newBird.FileName = _imagePath;

            var result = await _birdApiService.AddBird(newBird);
            if (!ReferenceEquals(result, null))
            {
                MessageBox.Show($"Something went wrong.\n{result}", null,
                                                     MessageBoxButton.OK, MessageBoxImage.Exclamation);
                image = new MemoryStream(File.ReadAllBytes(openFileDialog.FileName).ToArray());
            }
                
            else
            {
                MessageBox.Show("Bird was succesfully added!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                BirdAdded?.Invoke(this, new BirdAddedOrEditedArgs(newBird.Name));
                this.Close();
            }
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            string path = "";
            string fileName = "";
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;..."; ;
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                _imagePath = openFileDialog.FileName;
                fileName = Path.GetFileName(path);
                txtImage.Text = fileName;
            }

            if (path != "")
            {
                var stream = new MemoryStream(File.ReadAllBytes(path).ToArray());
                image = stream;
            }

        }

    }
}
