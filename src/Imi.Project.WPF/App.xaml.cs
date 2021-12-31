using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Services;
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
            services.AddScoped<IBaseApiService, BaseApiService>();
            services.AddScoped<IAuthApiService, AuthApiService>();
            services.AddScoped<IBirdApiService, BirdApiService>();
            services.AddScoped<ISpeciesApiService, SpeciesApiService>();
            services.AddScoped<ICageApiService, CageApiService>();
            services.AddTransient(typeof(Login));
            services.AddTransient(typeof(MainWindow));
        }
    }
}

