﻿using AutoMapper;

namespace Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Country
            CreateMap<DataContract.CountryInbound, Country>();
            CreateMap<Country, DataContract.Country>().ReverseMap();
            CreateMap<CountryLookup, DataContract.CountryLookup>();
            #endregion

            #region Grape
            CreateMap<Grape, DataContract.Grape>().ReverseMap();
            CreateMap<DataContract.GrapeCreate, Grape>();
            CreateMap<Grapes.GrapeColour, DataContract.GrapeColour>().ReverseMap();
            CreateMap<DataContract.GrapeColourCreate, Grapes.GrapeColour>();
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
            #endregion  
        }
    }
}
