using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
using Imi.Project.WPF.ViewModels;
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
        public AddBird(IBirdApiService apiService, ISpeciesApiService speciesApiService)
        {
            InitializeComponent();
            _birdApiService = apiService;
            _speciesApiService = speciesApiService;
            DataContext = new AddBirdViewModel(_birdApiService, _speciesApiService);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newBird = new Bird
            {
                //Name = txtName.Text,
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                CageId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            };

            _birdApiService.AddBird(newBird);
        }
    }
}
