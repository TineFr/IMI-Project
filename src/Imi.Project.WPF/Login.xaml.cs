using Imi.Project.WPF.Interfaces;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IBirdApiService _apiService;
        public Login(IBirdApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;


        }
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

            Window login = new MainWindow(_apiService);
            login.Show();
            this.Close();
        }

    }
}
