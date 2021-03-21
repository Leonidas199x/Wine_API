using Database_Models;
using System.Collections.Generic;


namespace Database_Repository
{
    public interface IDatabaseRepository
    {
        IEnumerable<Models.Country> GetCountries();

        IEnumerable<Models.FullCountry> GetCountry(int countryId);
    }
}
