using System.Collections.Generic;
using DataContract.Country;

namespace Service
{
    public interface IWineService
    {
        IEnumerable<Country> GetAllCountries();

        IEnumerable<FullCountry> GetCountry(int countryId);
    }
}
