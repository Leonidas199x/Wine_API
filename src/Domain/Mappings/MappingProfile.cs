﻿using AutoMapper;

namespace Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Domain
            CreateMap(typeof(DataContract.PagedList<>), typeof(Domain.PagedList<>)).ReverseMap();
            #endregion

            #region Country
            CreateMap<DataContract.CountryInbound, Country>();
            CreateMap<Country, DataContract.Country>().ReverseMap();
            CreateMap<CountryLookup, DataContract.CountryLookup>();
            CreateMap<Region.RegionLookup, DataContract.RegionLookup>();
            CreateMap<DataContract.CountrySearch, Countries.CountrySearch>();
            #endregion

            #region Grape
            CreateMap<Grape, DataContract.Grape>().ReverseMap();
            CreateMap<DataContract.GrapeCreate, Grape>();
            CreateMap<Grapes.GrapeColour, DataContract.GrapeColour>().ReverseMap();
            CreateMap<DataContract.GrapeColourCreate, Grapes.GrapeColour>();
            CreateMap<DataContract.GrapeLookup, Grapes.GrapeLookup>().ReverseMap();
            CreateMap<DataContract.GrapeCreate, Grape>()
                .ForPath(dest => dest.Colour.Id, opt => opt.MapFrom(x => x.GrapeColourId))
                .ReverseMap();
            #endregion

            #region Region
            CreateMap<Region.Region, DataContract.Region>().ReverseMap();
            CreateMap<Region.Region, DataContract.RegionCreate>().ReverseMap();
            #endregion

            #region WineRegion
            CreateMap<WineRegion.WineRegion, DataContract.WineRegion>().ReverseMap();
            CreateMap<WineRegion.WineRegion, DataContract.WineRegionCreate>().ReverseMap();
            #endregion

            #region Producer
            CreateMap<Producer.Producer, DataContract.Producer>().ReverseMap();
            CreateMap<Producer.Producer, DataContract.ProducerCreate>().ReverseMap();
            CreateMap<Producer.ProducerLookup, DataContract.ProducerLookup>().ReverseMap();
            #endregion

            #region Drinker
            CreateMap<Drinker.Drinker, DataContract.Drinker>().ReverseMap();
            CreateMap<Drinker.Drinker, DataContract.DrinkerCreate>().ReverseMap();
            #endregion

            #region QualityControl
            CreateMap<QualityControl.QualityControl, DataContract.QualityControl>().ReverseMap();
            CreateMap<QualityControl.QualityControl, DataContract.QualityControlCreate>().ReverseMap();
            CreateMap<QualityControl.QualityControlLookup, DataContract.QualityControlLookup>().ReverseMap();
            #endregion

            #region StopperType
            CreateMap<StopperType.StopperType, DataContract.StopperType>().ReverseMap();
            CreateMap<StopperType.StopperType, DataContract.StopperTypeCreate>().ReverseMap();
            #endregion

            #region Wine Type
            CreateMap<WineType.WineType, DataContract.WineType>().ReverseMap();
            CreateMap<WineType.WineType, DataContract.WineTypeCreate>().ReverseMap();
            CreateMap<WineType.WineTypeLookup, DataContract.WineTypeLookup>().ReverseMap();
            #endregion

            #region Retailer
            CreateMap<Retailer.Retailer, DataContract.Retailer>().ReverseMap();
            CreateMap<Retailer.Retailer, DataContract.RetailerCreate>().ReverseMap();
            CreateMap<Retailer.RetailerLookup, DataContract.RetailerLookup>().ReverseMap();
            #endregion

            #region Wine
            CreateMap<Wine.Wine, DataContract.Wine>().ReverseMap();
            CreateMap<Issue.Issue, DataContract.Issue>().ReverseMap();
            CreateMap<DataContract.WineCreate, Wine.WineCreate>().ReverseMap();
            CreateMap<DataContract.WineUpdate, Wine.WineUpdate>().ReverseMap();
            CreateMap<DataContract.WineGrape, Wine.WineGrape>().ReverseMap();
            #endregion

            #region Retailer Wine
            CreateMap<RetailerWine.RetailerWine, DataContract.RetailerWine>().ReverseMap();
            CreateMap<DataContract.RetailerWineInbound, RetailerWine.RetailerWine>();
            CreateMap<RetailerWine.RetailerWineLookup, DataContract.RetailerWineLookup>();
            #endregion

            #region Vineyard estate
            CreateMap<VineyardEstate.VineyardEstate, DataContract.VineyardEstate>().ReverseMap();
            CreateMap<DataContract.VineyardEstateCreate, VineyardEstate.VineyardEstate>();
            CreateMap<VineyardEstate.VineyardEstateLookup, DataContract.VineyardEstateLookup>().ReverseMap();
            #endregion

            #region WineHeader
            CreateMap<Wine.WineHeader, DataContract.WineHeader>().ReverseMap();
            #endregion

            #region Rating
            CreateMap<Rating.WineRating, DataContract.WineRating>().ReverseMap();
            #endregion
        }
    }
}
