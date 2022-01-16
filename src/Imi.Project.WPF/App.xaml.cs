using Imi.Project.WPF.Core.Interfaces;
using Imi.Project.WPF.Core.Models;
using Imi.Project.WPF.Core.Services;
using Imi.Project.WPF.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Imi.Project.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<Login>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IAuthApiService, AuthApiService>();
            services.AddScoped(typeof(IBaseApiService<BirdRequestModel, BirdModel>), typeof(BirdApiService));
            services.AddScoped(typeof(IBaseApiService<CageModel, CageModel>), typeof(BaseApiService<CageModel, CageModel>));
            services.AddScoped(typeof(IBaseApiService<SpeciesModel, SpeciesModel>), typeof(BaseApiService<SpeciesModel, SpeciesModel>));
            services.AddScoped(typeof(IBaseApiService<LogInApiResponse, LogInApiResponse>), typeof(BaseApiService<LogInApiResponse, LogInApiResponse>));
            services.AddTransient(typeof(Login));
            services.AddTransient(typeof(MainWindow));
        }
    }
}

