using Domain.Countries;
using Domain.Drinker;
using Domain.Grapes;
using Domain.Producer;
using Domain.QualityControl;
using Domain.Rating;
using Domain.Region;
using Domain.Retailer;
using Domain.RetailerWine;
using Domain.StopperType;
using Domain.VineyardEstate;
using Domain.Wine;
using Domain.WineRegion;
using Domain.WineType;
using Microsoft.Extensions.DependencyInjection;

namespace WineAPI
{
    public static class ServiceExtensions
    {
        public static void RegisterUserRepositories(this IServiceCollection services, string dbConnectionString) 
        {
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
            services.AddTransient<IRetailerRepository>(x => new RetailerRepository(dbConnectionString));
            services.AddTransient<IWineRepository>(x => new WineRepository(
                                                                            dbConnectionString, 
                                                                            x.GetRequiredService<IGrapeRepository>(), 
                                                                            x.GetRequiredService<IRegionRepository>(),
                                                                            x.GetRequiredService<IQualityControlRepository>()));
            services.AddTransient<IRetailerWineRepository>(x => new RetailerWineRepository(dbConnectionString));
            services.AddTransient<IRatingRepository>(x => new RatingRepository(dbConnectionString));
        }
        public static void RegisterUserServices(this IServiceCollection services) 
        {
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
            services.AddTransient<IRetailerService, RetailerService>();
            services.AddTransient<IWineService, WineService>();
            services.AddTransient<IRetailerWineService, RetailerWineService>();
            services.AddTransient<IRatingService, RatingService>();
        }
    }
}
