using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Countries
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryLookup>> GetCountryLookup();

        Task<IEnumerable<Country>> Get(int countryId);

        Task<bool> Delete(int countryId);

        Task<ValidationResult> Insert(Country country);
    }
}
