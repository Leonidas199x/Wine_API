using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Countries
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryLookup>> GetLookup();

        Task<Country> Get(int countryId);

        Task<PagedList<IEnumerable<Country>>> GetAll(int page, int pageSize);

        Task<IEnumerable<Country>> GetByName(string name);

        Task<IEnumerable<Country>> GetByIsoCode(string isoCode);

        Task<ValidationResult> Delete(int countryId);

        Task<ValidationResult> Insert(Country country);

        Task<ValidationResult> Update(Country country);
    }
}
