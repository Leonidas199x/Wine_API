using System.Collections.Generic;
using System.Threading.Tasks;
using DataContract.Country;

namespace DataRepository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryLookup>> GetAll();

        Task<IEnumerable<Country>> Get(int countryId);

        Task<bool> Delete(int countryId);

        Task<(bool, Country)> Insert(Country country);
    }
}
