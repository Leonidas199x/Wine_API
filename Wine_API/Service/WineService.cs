using System;
using System.Collections.Generic;
using Database_Models;
using Database_Repository;

namespace Service
{
    public class WineService : IWineService
    {
        private IDatabaseRepository _databaseRepository;

        public WineService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public IEnumerable<Models.Country> GetAllCountries()
        {
            var countries = _databaseRepository.GetCountries();

            return (countries != null) ? countries : null; 
        }

        public IEnumerable<Models.FullCountry> GetCountry(int countryId)
        {
            var country = _databaseRepository.GetCountry(countryId);

            return (country != null) ? country : null;
        }
    }
}
