using Imi.Project.WPF.Core.Interfaces;
using Imi.Project.WPF.Core.Models;
using System.Windows;

namespace Imi.Project.WPF.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdApiService;
        private readonly IBaseApiService<CageModel, CageModel> _cageApiService;
        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesApiService;
        private readonly IAuthApiService _authApiService;

        public Login(IAuthApiService authApiService, 
                     IBaseApiService<BirdRequestModel, BirdModel> birdApiService, 
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
            SetData();
        }

        private void SetData()
        {
            txtEmail.Text = "tine.franchois@gmail.com";
            txtPassword.Password = "Pa$$w0rd";
        }
        private async void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string response = await _authApiService.Authenticate(txtEmail.Text, txtPassword.Password);
            if (response is object)
            {
                tbkMessage.Text = response;
            }
            else
            {
                Window window = new MainWindow(_speciesApiService, _cageApiService, _birdApiService, _authApiService);
                window.Show();
                this.Close();
            }

        }
    }
}
