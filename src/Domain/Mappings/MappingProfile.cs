using AutoMapper;

namespace Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataContract.CountryInbound, Countries.Country>();
            CreateMap<Countries.Country, DataContract.Country>();
        }
    }
}
