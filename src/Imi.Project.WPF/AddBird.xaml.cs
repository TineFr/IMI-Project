using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
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
        private readonly IApiService _apiService;
        public AddBird(IApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newBird = new Bird
            {
                Name = txtName.Text,
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                CageId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                SpeciesId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            };

            _apiService.AddBird(newBird);
        }
    }
}
