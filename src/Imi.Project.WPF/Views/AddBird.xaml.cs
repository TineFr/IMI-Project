using Imi.Project.Common.Enums;
using Imi.Project.WPF.Core.Interfaces;
using Imi.Project.WPF.Core.Models;
using Imi.Project.WPF.Events;
using Imi.Project.WPF.Models.Birds;
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

        private readonly IBaseApiService<BirdModel, BirdModel> _birdApiService;
        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesApiService;
        private readonly IBaseApiService<CageModel, CageModel> _cageApiService;

        public delegate void RefreshList(object sender, BirdAddedOrEditedArgs e);
        public event RefreshList BirdAdded;

        private OpenFileDialog openFileDialog;
        private Stream image;
        private string _imagePath;
        public AddBird(IBaseApiService<BirdModel, BirdModel> birdApiService, 
                       IBaseApiService<SpeciesModel, SpeciesModel> speciesApiService, 
                       IBaseApiService<CageModel, CageModel> cageApiService)
        {
            InitializeComponent();

            this.DataContext = new AddBirdViewModel();
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
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newBird = new BirdModel
            {
                //Name = txtName.Text,
                //HatchDate = DateTime.Parse(pkrDate.Text),
                //CageId= ((CageModel)cmbCages.SelectedItem).Id,
                //SpeciesId = ((SpeciesModel)cmbSpecies.SelectedItem).Id,
                //Gender = (Gender)cmbGender.SelectedValue,
                //Food = txtFood.Text,
            };

            //newBird.Image = image;
            //newBird.FileName = _imagePath;

            var result = await _birdApiService.AddAsync("birds", newBird);
            if (!ReferenceEquals(result, null))
            {
                MessageBox.Show($"Something went wrong.\n{result}", null,
                                                     MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (openFileDialog != null)
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
