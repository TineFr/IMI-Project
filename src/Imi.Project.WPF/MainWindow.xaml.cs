using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
using Imi.Project.WPF.Services;
using Imi.Project.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Imi.Project.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBirdApiService _apiService;
        public MainWindow(IBirdApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
            this.DataContext = new MainViewModel(_apiService);


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stkDetails.Visibility = Visibility.Hidden;
        }

        private void lstBirds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stkDetails.Visibility = Visibility.Visible;
            stkDetails.DataContext = new BirdDetailViewModel(lstBirds.SelectedItem as BirdApiResponse);

        }

        private void btnAddBird_Click(object sender, RoutedEventArgs e)
        {
            Window addBird = new AddBird(_apiService);
            addBird.Show();
        }
    }
}
