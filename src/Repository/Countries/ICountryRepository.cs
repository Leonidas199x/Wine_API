using System.Collections.Generic;
using System.Threading.Tasks;
using DataContract.Country;

namespace Repository.Countries
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryLookup>> GetCountryLookup();

        Task<IEnumerable<Country>> Get(int countryId);

        Task<bool> Delete(int countryId);

        Task<(bool, Country)> Insert(Country country);
    }
}
