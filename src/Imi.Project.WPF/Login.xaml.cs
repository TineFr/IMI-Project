using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.ViewModels;
using System.Windows;

namespace Imi.Project.WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IBirdApiService birdApiService;
        private readonly ISpeciesApiService speciesApiService;
        public Login(IBirdApiService birdApiService, ISpeciesApiService speciesApiService)
        {
            InitializeComponent();
            this.birdApiService = birdApiService;
            this.speciesApiService = speciesApiService;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new LoginViewModel();

        }
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            birdApiService.Authenticate(txtEmail.Text, txtPassword.Text);
            Window window = new MainWindow(speciesApiService, birdApiService);
            window.Show();
            this.Close();
        }
    }
}
