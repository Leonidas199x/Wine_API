using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.WineRegion
{
    public interface IWineRegionService
    {
        Task<IEnumerable<WineRegion>> GetAll();

        Task<WineRegion> Get(int Id);

        Task<ValidationResult> Insert(WineRegion wineRegion);

        Task<ValidationResult> Update(WineRegion wineRegion);
    }
}