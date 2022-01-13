
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services;
using Imi.Project.Api.Handlers;
using Imi.Project.Api.Infrastructure;
using Imi.Project.Api.Infrastructure.Repositories;
using Imi.Project.Api.Requirements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyAviaryDbContext>(options => options.UseSqlServer
             (Configuration.GetConnectionString("MyAviaryIdentity")));

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }); ;

            //identity

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

            }).AddEntityFrameworkStores<MyAviaryDbContext>();



            //authentication
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = Configuration["JWTConfig:Audience"],
                    ValidIssuer = Configuration["JWTConfig:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTConfig:SigningKey"])),
                };
            });


            //authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorRole", policy =>
                {
                    policy.RequireRole("Administrator");
                });

                options.AddPolicy("IsOfAge", policy =>
                {
                    policy.Requirements.Add(new AgeRequirement(15));
                });

            });

            services.AddSingleton<IAuthorizationHandler, AgeRequirementHandler>();

            //swagger
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMI API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                          },
                        },
                        new List<string>()
                      }
                    });

            });


            services.AddRouting(options => options.LowercaseUrls = true);

            // repositories

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseRepository<ApplicationUser>), typeof(UserRepository));
            services.AddScoped(typeof(IBaseRepository<Cage>), typeof(CageRepository));


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICageRepository, CageRepository>();
            services.AddScoped<IBirdRepository, BirdRepository>();
            services.AddScoped<ISpeciesRepository, SpeciesRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IDailyTaskRepository, DailyTaskRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

            // services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICageService, CageService>();
            services.AddScoped<IBirdService, BirdService>();
            services.AddScoped<ISpeciesService, SpeciesService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IDailyTaskService, DailyTaskService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
        }


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

            app.UseStaticFiles();
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
