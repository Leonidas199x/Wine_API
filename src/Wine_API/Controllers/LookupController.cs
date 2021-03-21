using Microsoft.AspNetCore.Mvc;
using Domain.Countries;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class LookupController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _lookupMapper;

        public LookupController(
            ICountryService countryService,
            IMapper lookupMapper)
        {
            _countryService = countryService;
            _lookupMapper = lookupMapper;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryService.GetCountryLookup().ConfigureAwait(false);
            if (!countries.Any())
            {
                return NoContent(); 
            }

            var outboundCountries = _lookupMapper.Map<IEnumerable<DataContract.CountryLookup>>(countries);

            return Ok(outboundCountries);
        }
    }
}