using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Region
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAll();

        Task<Region> Get(int Id);

        Task<IEnumerable<Region>> GetByNameAndCountryId(string name, int countryId);

        Task<ValidationResult> Insert(Region region);

        Task<ValidationResult> Update(Region region);

        Task Delete(int regionId);
    }
}