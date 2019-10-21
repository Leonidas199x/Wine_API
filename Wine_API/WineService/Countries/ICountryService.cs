using System.Collections.Generic;
using System.Threading.Tasks;
using DataContract.Country;

namespace WineService.Countries
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryLookup>> GetCountryLookup();

        Task<IEnumerable<Country>> Get(int countryId);

        Task<bool> Delete(int countryId);

        Task<(bool, Country)> Insert(Country country);
    }
}
