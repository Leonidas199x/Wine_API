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
            CreateMap<IEnumerable<Grape>, IEnumerable<DataContract.Grape>>();
            CreateMap<Grape, DataContract.Grape>();
            #endregion
        }
    }
}
