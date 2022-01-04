using Imi.Project.WPF.Core.Interfaces;
using Imi.Project.WPF.Core.Models;
using System.Windows;

namespace Imi.Project.WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private readonly IBaseApiService<BirdModel, BirdModel> _birdApiService;
        private readonly IBaseApiService<CageModel, CageModel> _cageApiService;
        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesApiService;
        private readonly IAuthApiService _authApiService;

        public Login(IAuthApiService authApiService, 
                     IBaseApiService<BirdModel, BirdModel> birdApiService, 
                     IBaseApiService<CageModel, CageModel> cageApiService, 
                     IBaseApiService<SpeciesModel, SpeciesModel> speciesApiService)
        {
            InitializeComponent();
            _birdApiService = birdApiService;
            _authApiService = authApiService;
            _cageApiService = cageApiService;
            _speciesApiService = speciesApiService;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtEmail.Text = "tine.franchois@gmail.com";
            txtPassword.Password = "Pa$$w0rd";
        }
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            _authApiService.Authenticate(txtEmail.Text, txtPassword.Password);
            Window window = new MainWindow(_birdApiService, _speciesApiService, _cageApiService);
            window.Show();
            this.Close();
        }
    }
}
