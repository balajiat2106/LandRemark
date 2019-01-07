using LandmarkRemark.Application.Locations.Commands.CreateLocation;
using LandmarkRemark.Application.Locations.Queries.GetLocationDetail;
using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using LandmarkRemark.Application.UserLocation.Queries;
using LandmarkRemark.Application.Users.Commands.CreateUser;
using LandmarkRemark.Application.Users.Commands.DeleteUser;
using LandmarkRemark.Application.Users.Queries.GetUserDetail;
using LandmarkRemark.Application.Users.Queries.GetUserList;
using LandmarkRemark.Application.Users.Queries.UserLogin;
using LandmarkRemark.Business.Locations.Commands.CreateLocation;
using LandmarkRemark.Business.Locations.Queries.GetLocationDetail;
using LandmarkRemark.Business.Locations.Queries.GetLocationList;
using LandmarkRemark.Business.UserLocations.Queries;
using LandmarkRemark.Business.Users.Commands.CreateUser;
using LandmarkRemark.Business.Users.Commands.DeleteUser;
using LandmarkRemark.Business.Users.Queries.GetUserDetail;
using LandmarkRemark.Business.Users.Queries.GetUserList;
using LandmarkRemark.Business.Users.Queries.UserLogin;
using LandmarkRemark.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;
using System.Reflection;

namespace LandmarkRemark.Presentation
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
            var ConnectionString = @"Data Source=DESKTOP-1OVO3CU\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Database=LandmarkRemarkDB1;Trusted_Connection=True;";
            services.AddCors();
            services.AddMvc();
            services.AddDbContext<LandmarkRemarkContext>(o => o.UseSqlServer(ConnectionString));
            //***Services from application repo***
            //User repo services
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<IDeleteUserCommand, DeleteUserCommand>();
            services.AddScoped<IGetUserDetailQuery, GetUserDetailQuery>();
            services.AddScoped<IGetUserListQuery, GetUserListQuery>();
            services.AddScoped<IUserLoginQuery, UserLoginQuery>();
            //User lcoation repo services
            services.AddScoped<IGetUserLocationListQuery, GetUserLocationListQuery>();
            //Location repo services
            services.AddScoped<ICreateLocationCommand, CreateLocationCommand>();
            services.AddScoped<IGetLocationDetailQuery, GetLocationDetailQuery>(); 
            services.AddScoped<IGetLocationListBasedOnUserIdQuery, GetLocationListBasedOnUserIdQuery>();
            services.AddScoped<IGetLocationListBasedOnSearchTextQuery, GetLocationListBasedOnSearchTextQuery>();
            
            //***Services from business***
            //User services
            services.AddScoped<ICreateUser, CreateUser>();
            services.AddScoped<IDeleteUser, DeleteUser>();
            services.AddScoped<IGetUserDetail, GetUserDetail>(); 
            services.AddScoped<IGetUserList, GetUserList>();
            services.AddScoped<IGetUserDetailBasedOnUserName, GetUserDetailBasedOnUserName>();
            services.AddScoped<IUserLogin, UserLogin>();
            //User location service
            services.AddScoped<IGetUserLocationList, GetUserLocationList>();
            //Location services
            services.AddScoped<ICreateLocation, CreateLocation>();
            services.AddScoped<IGetLocationDetail, GetLocationDetail>();
            services.AddScoped<IGetLocationListBasedOnUserId, GetLocationListBasedOnUserId>();
            services.AddScoped<IGetLocationListBasedOnSearchText, GetLocationListBasedOnSearchText>();
            
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LandmarkRemarkContext landmarkRemarkContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseSwaggerUi3(typeof(Startup).GetTypeInfo().Assembly);
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            LandmarkRemarkInitializer.Initialize(landmarkRemarkContext);
        }
    }
}
