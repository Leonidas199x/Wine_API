using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WineAPI.Models;
using Microsoft.Extensions.Hosting;
using System;
using FluentValidation.AspNetCore;
using Domain.Mappings;
using Domain.Region;
using System.Reflection;
using System.Diagnostics;
using FluentValidation;

namespace WineAPI
{
    public class Startup
    {
        private const string DatabaseConfigSection = "Wine_DB";
        public IConfiguration Configuration { get; set; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvc();

            //Add fluent validation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssembly(typeof(RegionValidator).Assembly);

            services.Configure<AppSettings>(Configuration.GetSection("ApplicationSettings"));

            var dbConnectionString = Configuration.GetConnectionString(DatabaseConfigSection);

            services.RegisterUserRepositories(dbConnectionString);
            services.RegisterUserServices();

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.Configure<DebugSettings>(Configuration.GetSection("DebugSettings"));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddLogging();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Wine API",
                    Version = "v1",
                    Description = "An API to return data from the Wine database.",
                    Contact = new OpenApiContact
                    {
                        Name = "Toby Prince",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/Leonidas199x/Wine_API"),
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            CreateEventLogSource();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseMiddleware<ErrorLoggingMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wine API");
            });
        }

        private static void CreateEventLogSource()
        {
            if (!EventLog.SourceExists(EventViewerInformation.Source))
            {
                EventLog.CreateEventSource(EventViewerInformation.Source, EventViewerInformation.Log);
                return;
            }
        }
    }
}
