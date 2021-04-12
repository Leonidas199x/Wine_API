using AutoMapper;
using System.Collections.Generic;

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
        }
    }
}
