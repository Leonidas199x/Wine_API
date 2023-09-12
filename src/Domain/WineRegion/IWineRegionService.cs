using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.WineRegion
{
    public interface IWineRegionService
    {
        Task<PagedList<IEnumerable<WineRegion>>> GetAll(int page, int pageSize);

        Task<WineRegion> Get(int Id);

        Task<ValidationResult> Insert(WineRegion wineRegion);

        Task<ValidationResult> Update(WineRegion wineRegion);

        Task Delete(int wineRegionId);
    }
}