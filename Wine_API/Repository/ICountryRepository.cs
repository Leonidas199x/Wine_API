using System.Collections.Generic;
using System.Threading.Tasks;
using DataContract.Country;

namespace DataRepository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAll();

        Task<IEnumerable<FullCountry>> Get(int countryId);

        Task<bool> Delete(int countryId);

        Task<(bool, FullCountry)> Insert(FullCountry country);
    }
}
