﻿using FluentValidation;
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
            return await _countryRepository.GetCountryLookup().ConfigureAwait(false);
        }

        public async Task<Country> Get(int countryId)
        {
            return await _countryRepository.Get(countryId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _countryRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Country>> GetByName(string name)
        {
            return await _countryRepository.GetByName(name).ConfigureAwait(false);
        }

        public async Task Delete(int countryId)
        {
            await _countryRepository.Delete(countryId).ConfigureAwait(false);
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
