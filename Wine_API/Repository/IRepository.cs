using System.Collections.Generic;

namespace DataRepository
{
    public interface IRepository
    {
        IEnumerable<DataContract.Country.Country> GetCountries();

        IEnumerable<DataContract.Country.FullCountry> GetCountry(int countryId);
    }
}
