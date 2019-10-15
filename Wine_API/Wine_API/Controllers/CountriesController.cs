using Microsoft.AspNetCore.Mvc;
using WineService.Countries;
using System.Linq;
using System.Threading.Tasks;

namespace Wine_API.Controllers
{
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountries().ConfigureAwait(false);

            if (!countries.Any())
            {
                return NotFound(); 
            }
            
            return Ok(countries);
        }

        [HttpGet("{CountryId}")]
        public async Task<IActionResult> GetCountry(int countryId)
        {
            var country = await _countryService.GetCountry(countryId).ConfigureAwait(false);

            if(!country.Any())
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpDelete("{CountryId}")]
        public async Task<IActionResult> DeleteCountry(int countryId)
        {
            var country = await _countryService.GetCountry(countryId).ConfigureAwait(false);

            if(!country.Any())
            {
                return NotFound();
            }

            var updated = await _countryService.DeleteCountry(countryId).ConfigureAwait(false);

            if(!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("{CountryId}")]
        public async Task<IActionResult> UpdateCountry(int countryId)
        {
            var country = await _countryService.GetCountry(countryId).ConfigureAwait(false);

            if (!country.Any())
            {
                return NotFound();
            }

            var updated

        }
    }
}