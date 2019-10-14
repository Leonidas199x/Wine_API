using System.Collections.Generic;
using DataContract.Country;

namespace WineService.Countries
{
    public interface ICountryService
    {
        IEnumerable<Country> GetAllCountries();

        IEnumerable<FullCountry> GetCountry(int countryId);
    }
}
