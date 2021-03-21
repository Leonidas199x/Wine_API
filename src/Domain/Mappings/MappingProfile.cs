using AutoMapper;
using System.Collections.Generic;

namespace Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Country
            CreateMap<DataContract.CountryInbound, Countries.Country>();
            CreateMap<Countries.Country, DataContract.Country>();
            CreateMap<IEnumerable<Countries.CountryLookup>, IEnumerable<DataContract.CountryLookup>>();
            #endregion
        }
    }
}
