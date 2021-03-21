using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Countries
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IValidator<Country> _countryValidator;

        public CountryService(
            ICountryRepository countryRepository,
            IValidator<Country> countryValidator)
        {
            _countryRepository = countryRepository;
            _countryValidator = countryValidator;
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

        public async Task<ValidationResult> Insert(Country country)
        {
            var validationResult = _countryValidator.Validate(country);

            if(!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _countryRepository.Insert(country).ConfigureAwait(false);
        }
    }
}
