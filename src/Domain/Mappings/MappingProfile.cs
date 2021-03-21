using AutoMapper;

namespace Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataContract.Country, Countries.Country>();
        }
    }
}
