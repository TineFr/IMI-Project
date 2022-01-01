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
        private readonly IBirdApiService _birdApiService;
        private readonly ISpeciesApiService _speciesApiService;
        private readonly ICageApiService _cageApiService;
        private readonly IAuthApiService _authApiService;
        public Login(IBirdApiService birdApiService, 
                     ISpeciesApiService speciesApiService, 
                     IAuthApiService authApiService, 
                     ICageApiService cageApiService)
        {
            InitializeComponent();
            _birdApiService = birdApiService;
            _speciesApiService = speciesApiService;
            _authApiService = authApiService;
            _cageApiService = cageApiService;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtEmail.Text = "tine.franchois@gmail.com";
            txtPassword.Password = "Pa$$w0rd";
        }
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            _authApiService.Authenticate(txtEmail.Text, txtPassword.Password);
            Window window = new MainWindow(_speciesApiService, _birdApiService, _cageApiService);
            window.Show();
            this.Close();
        }
    }
}
