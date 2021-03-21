using Microsoft.AspNetCore.Mvc;
using Domain.Countries;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using System.Collections.Generic;
using System.Linq;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _countryMapper;

        public CountryController(
            ICountryService countryService,
            IMapper countryMapper)
        {
            _countryService = countryService;
            _countryMapper = countryMapper;
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> Get(int countryId)
        {
            var country = await _countryService.Get(countryId).ConfigureAwait(false);
            if(country == null)
            {
                return NotFound();
            }

            var outboundCountry = _countryMapper.Map<DataContract.Country>(country);

            return Ok(outboundCountry);
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryService.GetCountryLookup().ConfigureAwait(false);
            var outboundCountries = _countryMapper.Map<IEnumerable<DataContract.CountryLookup>>(countries);

            return Ok(outboundCountries);
        }

        [HttpDelete("{countryId}")]
        public async Task<IActionResult> Delete(int countryId)
        {
            var country = await _countryService.Get(countryId).ConfigureAwait(false);
            if(country == null)
            {
                return NotFound();
            }

            await _countryService.Delete(countryId).ConfigureAwait(false);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataContract.CountryInbound country)
        {
            var domainCountry = _countryMapper.Map<Country>(country);

            var validationResult = await _countryService.Insert(domainCountry).ConfigureAwait(false);
            if(validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }
    }
}