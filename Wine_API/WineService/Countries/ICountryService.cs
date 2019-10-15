using System.Collections.Generic;
using System.Threading.Tasks;
using DataContract.Country;

namespace WineService.Countries
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountries();

        Task<IEnumerable<FullCountry>> GetCountry(int countryId);

        Task<bool> DeleteCountry(int countryId);
    }
}
