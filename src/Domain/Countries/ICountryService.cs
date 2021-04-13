using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Countries
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryLookup>> GetCountryLookup();

        Task<Country> Get(int countryId);

        Task<IEnumerable<Country>> GetAll();

        Task<ValidationResult> Delete(int countryId);

        Task<ValidationResult> Insert(Country country);

        Task<ValidationResult> Update(Country country);
    }
}
