﻿using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Countries
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryLookup>> GetCountryLookup();

        Task<Country> Get(int countryId);

        Task<IEnumerable<Country>> GetByName(string name);

        Task Delete(int countryId);

        Task<ValidationResult> Insert(Country country);
    }
}