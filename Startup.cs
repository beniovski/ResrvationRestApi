using System;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection; 
using ReservationRestApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ReservationRestApi.Services;

namespace ReservationRestApi
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get;  }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the Configure method, below.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection.
            services.AddMvc();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)            
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });
            var val = Configuration["Jwt:Key"];
            services.AddSingleton<IConfiguration>(Configuration);

            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterType<RoomsRepository>().As<IRoomsRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<TokenService>().As<ITokenService>();
            builder.RegisterType<ResrvationDateRepository>().As<IReservationDateRepository>();
            builder.RegisterType<ReservationService>().As<IReservationService>();
            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // Configure is where you add middleware. This is called after
        // ConfigureServices. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(
          IApplicationBuilder app,
          ILoggerFactory loggerFactory,
          IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseAuthentication();
            app.UseMvc();
            app.UseDeveloperExceptionPage(); // error message output
            app.UseStaticFiles();
            

        }
    }
}

