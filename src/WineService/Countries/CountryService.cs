using System.Collections.Generic;
using System.Threading.Tasks;
using DataContract.Country;
using Repository.Countries;

namespace WineService.Countries
{
    public class CountryService : ICountryService
    {
        private ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<CountryLookup>> GetCountryLookup()
        {
            var countries = await _countryRepository.GetCountryLookup().ConfigureAwait(false);

            return (countries != null) ? countries : null; 
        }

        public async Task<IEnumerable<Country>> Get(int countryId)
        {
            var country = await _countryRepository.Get(countryId).ConfigureAwait(false);

            return (country != null) ? country : null;
        }

        public async Task<bool> Delete(int countryId)
        {
            return await _countryRepository.Delete(countryId).ConfigureAwait(false);
        }

        public async Task<(bool, Country)> Insert(Country country)
        {
            return await _countryRepository.Insert(country).ConfigureAwait(false);
        }
    }
}
