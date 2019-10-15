using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var countries = await _databaseRepository.GetCountries().ConfigureAwait(false);

            return (countries != null) ? countries : null; 
        }

        public async Task<IEnumerable<FullCountry>> GetCountry(int countryId)
        {
            var country = await _databaseRepository.GetCountry(countryId).ConfigureAwait(false);

            return (country != null) ? country : null;
        }

        public async Task<bool> DeleteCountry(int countryId)
        {
            return await _databaseRepository.DeleteCountry(countryId).ConfigureAwait(false);
        }
    }
}
