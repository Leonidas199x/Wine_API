using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Region
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionLookup>> GetLookup();

        Task<PagedList<IEnumerable<Region>>> GetAll(int page, int pageSize);

        Task<Region> Get(int regionId);

        Task<ValidationResult> Insert(Region region);

        Task<ValidationResult> Update(Region region);

        Task Delete(int regionId);
    }
}