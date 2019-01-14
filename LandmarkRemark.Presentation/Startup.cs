using LandmarkRemark.Application.Locations.Commands.CreateLocation;
using LandmarkRemark.Application.Locations.Queries.GetLocationDetail;
using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using LandmarkRemark.Application.UserLocation.Queries;
using LandmarkRemark.Application.Users.Commands.CreateUser;
using LandmarkRemark.Application.Users.Queries.GetUserDetail;
using LandmarkRemark.Application.Users.Queries.GetUserList;
using LandmarkRemark.Application.Users.Queries.UserLogin;

using LandmarkRemark.Business.Locations.Commands.CreateLocation;
using LandmarkRemark.Business.Locations.Queries.GetLocationDetail;
using LandmarkRemark.Business.Locations.Queries.GetLocationList;
using LandmarkRemark.Business.UserLocations.Queries;
using LandmarkRemark.Business.Users.Commands.CreateUser;
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
            var ConnectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=master;Integrated Security=True;Database=LRDB7;Trusted_Connection=True;";
                       
            services.AddCors();
            services.AddMvc();
            services.AddDbContext<LandmarkRemarkContext>(o => o.UseSqlServer(ConnectionString));

            //***Services from application repo***
            //User repo services
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
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
                //TODO:
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
                        
            app.UseSwaggerUi3(typeof(Startup).GetTypeInfo().Assembly);
            app.UseCors();
            app.UseHttpsRedirection();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            
            app.UseSpa(spa =>
            {
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
