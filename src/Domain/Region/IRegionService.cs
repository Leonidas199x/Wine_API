using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Region
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAll();

        Task<Region> Get(int regionId);

        Task<ValidationResult> Insert(Region region);

        Task<ValidationResult> Update(Region region);

        Task Delete(int regionId);
    }
}