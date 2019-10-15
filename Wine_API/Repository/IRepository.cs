using System.Collections.Generic;
using System.Threading.Tasks;
using DataContract.Country;

namespace DataRepository
{
    public interface IRepository
    {
        Task<IEnumerable<Country>> GetCountries();

        Task<IEnumerable<FullCountry>> GetCountry(int countryId);

        Task<bool> DeleteCountry(int countryId);

        Task<(bool, FullCountry)> InsertCountry(FullCountry country);
    }
}
