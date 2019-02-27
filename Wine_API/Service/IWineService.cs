using Database_Models;
using System.Collections.Generic;

namespace Service
{
    public interface IWineService
    {
        IEnumerable<Models.Country> GetAllCountries();

        IEnumerable<Models.FullCountry> GetCountry(int countryId);
    }
}
