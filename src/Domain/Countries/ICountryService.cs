using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Countries
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryLookup>> GetLookup();

        Task<Country> Get(int countryId);

        Task<PagedList<IEnumerable<Country>>> GetAll(int page, int pageSize);

        Task<ValidationResult> Delete(int countryId);

        Task<ValidationResult> Insert(Country country);

        Task<ValidationResult> Update(Country country);

        Task<PagedList<IEnumerable<Country>>> Search(CountrySearch search, int page, int pageSize);
    }
}
