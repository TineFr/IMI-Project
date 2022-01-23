using Imi.Project.Blazor.Hubs;
using Imi.Project.Blazor.Models.Api;
using Imi.Project.Blazor.Services;
using Imi.Project.Blazor.Services.Api;
using Imi.Project.Blazor.Services.Api.Interfaces;
using Imi.Project.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Imi.Project.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddSignalR();
            services.AddServerSideBlazor();
            services.AddTransient<IBirdService, MockBirdService>();
            services.AddTransient<ICageService, MockCageService>();
            services.AddTransient<ISpeciesService, MockSpeciesService>();
            services.AddTransient<IQuizService, QuizService>();
            services.AddSingleton<IRoomService, RoomService>();
            services.AddHttpClient();
            

            services.AddScoped<IAuthApiService, AuthApiService>();
            services.AddScoped(typeof(IBaseApiService<BirdRequestModel, BirdModel>), typeof(BirdApiService));
            services.AddScoped(typeof(IBaseApiService<CageRequestModel, CageModel>), typeof(CageApiService));
            services.AddScoped(typeof(IBaseApiService<SpeciesModel, SpeciesModel>), typeof(BaseApiService<SpeciesModel, SpeciesModel>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<QuizHub>("/multiplayer");
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
