using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Region
{
    public interface IRegionRepository
    {
        Task<IEnumerable<RegionLookup>> GetLookup();

        Task<PagedList<IEnumerable<Region>>> GetAll(int page, int pageSize);

        Task<Region> Get(int Id);

        Task<IEnumerable<Region>> GetByNameAndCountryId(string name, int countryId);

        Task<IEnumerable<Region>> GetByIsoCode(string isoCode);

        Task<ValidationResult> Insert(Region region);

        Task<ValidationResult> Update(Region region);

        Task Delete(int regionId);

        Region AddCountry(Region region, Country country);
    }
}