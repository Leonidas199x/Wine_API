using System.Collections.Generic;
using DataContract.Country;
using DataRepository;

namespace WineService.Countries
{
    public class CountryService : ICountryService
    {
        private IRepository _databaseRepository;

        public CountryService(IRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            var countries = _databaseRepository.GetCountries();

            return (countries != null) ? countries : null; 
        }

        public IEnumerable<FullCountry> GetCountry(int countryId)
        {
            var country = _databaseRepository.GetCountry(countryId);

            return (country != null) ? country : null;
        }
    }
}
