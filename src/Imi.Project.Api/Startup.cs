
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services;
using Imi.Project.Api.Infrastructure;
using Imi.Project.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyAviaryDbContext>(options => options.UseSqlServer
             (Configuration.GetConnectionString("MyAviary")));
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }); ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMI API", Version = "v1" });
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICageRepository, CageRepository>();
            services.AddScoped<IBirdRepository, BirdRepository>();
            services.AddScoped<ISpeciesRepository, SpeciesRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IDailyTaskRepository, DailyTaskRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICageService, CageService>();
            services.AddScoped<IBirdService, BirdService>();
            services.AddScoped<ISpeciesService, SpeciesService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IDailyTaskService, DailyTaskService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMI API v1");

            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
