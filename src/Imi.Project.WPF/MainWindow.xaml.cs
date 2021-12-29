using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
using Imi.Project.WPF.ViewModels;
using Imi.Project.WPF.Views;
using System.Windows;
using System.Windows.Controls;

namespace Imi.Project.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBirdApiService _birdApiService;
        private readonly ISpeciesApiService _speciesApiService;
        private readonly ICageApiService _cageApiService;


        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        public MainWindow(ISpeciesApiService speciesApiService, IBirdApiService birdApiService, ICageApiService cageApiService)
        {
            InitializeComponent();
            _speciesApiService = speciesApiService;
            _birdApiService = birdApiService;
            _cageApiService = cageApiService;
            SetData();

        }

        private async void SetData()
        {
            lstBirds.ItemsSource = await _birdApiService.GetBirds();
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
            AddBird addBird = new AddBird(_birdApiService, _speciesApiService, _cageApiService);
            RefreshListEvent += new RefreshList(RefreshBirdList); 
            addBird.BirdAdded = RefreshListEvent;
            addBird.Show();
        }

        private void btnEditBird_Click(object sender, RoutedEventArgs e)
        {
            Window addBird = new EditBird(_birdApiService, _speciesApiService, _cageApiService, (BirdApiResponse)lstBirds.SelectedItem);
            addBird.Show();
        }

        private async void btnDeleteBird_Click(object sender, RoutedEventArgs e)
        {
            var birdToDelete = (BirdApiResponse)lstBirds.SelectedItem;
            var result = await _birdApiService.DeleteBird(birdToDelete.Id);
            if (!ReferenceEquals(result, null)) MessageBox.Show($"Something went wrong\n{result}", null,
                                                         MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBox.Show("Bird was succesfully deleted!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                SetData();
                lstBirds.SelectedIndex = -1;
                stkDetails.Visibility = Visibility.Hidden;
            }

        }
        private void RefreshBirdList()
        {
            SetData();
        }
    }
}
