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

        public async Task<IEnumerable<CountryLookup>> GetLookup()
        {
            return await _countryRepository.GetLookup().ConfigureAwait(false);
        }

        public async Task<Country> Get(int countryId)
        {
            return await _countryRepository.Get(countryId).ConfigureAwait(false);
        }

        public async Task<PagedList<IEnumerable<Country>>> GetAll(int page, int pageSize)
        {
            return await _countryRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<PagedList<IEnumerable<Country>>> Search(CountrySearch search, int page, int pageSize)
        {
            return await _countryRepository.Search(search, page, pageSize).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Country>> GetByName(string name)
        {
            return await _countryRepository.GetByName(name).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int countryId)
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

        public async Task<ValidationResult> Update(Country country)
        {
            var validationResult = _countryValidator.Validate(country);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _countryRepository.Update(country).ConfigureAwait(false);
        }
    }
}
