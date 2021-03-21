using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Repository.Countries;
using Repository.Grapes;
using WineService.Countries;
using WineService.Grapes;
using WineAPI.Models;
using Microsoft.Extensions.Hosting;
using System;

namespace WineAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<AppSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddTransient<ICountryRepository>(x => new CountryRepository(Configuration.GetConnectionString("Wine_DB")));
            services.AddTransient<IGrapesRepository>(x => new GrapesRepository(Configuration.GetConnectionString("Wine_DB")));
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IGrapeService, GrapeService>();
            services.AddMvc(option => option.EnableEndpointRouting = false);

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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wine API");
            });
        }
    }
}
