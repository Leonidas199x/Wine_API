using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Domain.Countries;
using Domain.Grapes;
using WineAPI.Models;
using Microsoft.Extensions.Hosting;
using System;
using FluentValidation.AspNetCore;
using Domain.Mappings;
using Domain.Region;
using Domain.WineRegion;
using Domain.Producer;
using Domain.VineyardEstate;
using Domain.Drinker;
using Domain.QualityControl;
using Domain.StopperType;
using Domain.WineType;

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
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvc();

            //Add fluent validtion
            builder.AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<RegionValidator>()
            .RegisterValidatorsFromAssemblyContaining<Startup>());

            services.Configure<AppSettings>(Configuration.GetSection("ApplicationSettings"));

            var dbConnectionString = Configuration.GetConnectionString(DatabaseConfigSection);

            //repositories
            services.AddTransient<ICountryRepository>(x => new CountryRepository(dbConnectionString));
            services.AddTransient<IGrapeRepository>(x => new GrapeRepository(dbConnectionString));
            services.AddTransient<IRegionRepository>(x => new RegionRepository(dbConnectionString));
            services.AddTransient<IWineRegionRepository>(x => new WineRegionRepository(dbConnectionString));
            services.AddTransient<IProducerRepository>(x => new ProducerRepository(dbConnectionString));
            services.AddTransient<IVineyardEstateRepository>(x => new VineyardEstateRepository(dbConnectionString));
            services.AddTransient<IDrinkerRepository>(x => new DrinkerRepository(dbConnectionString));
            services.AddTransient<IQualityControlRepository>(x => new QualityControlRepository(dbConnectionString));
            services.AddTransient<IStopperTypeRepository>(x => new StopperTypeRepository(dbConnectionString));
            services.AddTransient<IWineTypeRepository>(x => new WineTypeRepository(dbConnectionString));

            //services
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IGrapeService, GrapeService>();
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IWineRegionService, WineRegionService>();
            services.AddTransient<IProducerService, ProducerService>();
            services.AddTransient<IVineyardEstateService, VineyardEstateService>();
            services.AddTransient<IDrinkerService, DrinkerService>();
            services.AddTransient<IQualityControlService, QualityControlService>();
            services.AddTransient<IStopperTypeService, StopperTypeService>();
            services.AddTransient<IWineTypeService, WineTypeService>();

            services.AddMvc(option => option.EnableEndpointRouting = false);

            //Register automapper
            services.AddAutoMapper(typeof(MappingProfile));

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
