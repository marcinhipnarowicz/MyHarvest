using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyHarvestApi.Entity.Context;
using MyHarvestApi.Repository;
using MyHarvestApi.Api.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyHarvestApi.Service;
using MyHarvestApi.Entity.AppSettingsHelp;
using GeoAPI.Geometries;

namespace MyHarvestApi.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var cs = Configuration.GetConnectionString("DbConnectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cs, b => b.MigrationsAssembly("MyHarvestApi.Api")));

            //repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IPlotRepository, PlotRepository>();
            services.AddScoped<IStatusOfTaskRepository, StatusOfTaskRepository>();
            services.AddScoped<IUserInformationRepository, UserInformationRepository>();
            services.AddScoped<IWaypointRepository, WaypointRepository>();
            services.AddScoped<IPointOnTheMapRepository, PointOnTheMapRepository>();

            //service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountTypeService, AccountTypeService>();
            services.AddScoped<IStatusOfTaskService, StatusOfTaskService>();
            services.AddScoped<IPlotService, PlotService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserInformationService, UserInformationService>();
            services.AddScoped<IWaypointService, WaypointService>();
            services.AddScoped<IPointOnTheMapService, PointOnTheMapService>();

            //do tokenu
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //nie wiem czy potrzebne
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            //do tego miejsca
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}