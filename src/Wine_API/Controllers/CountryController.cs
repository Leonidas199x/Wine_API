using Microsoft.AspNetCore.Mvc;
using WineService.Countries;
using System.Linq;
using System.Threading.Tasks;
using DataContract.Country;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetCountry(int countryId)
        {
            var country = await _countryService.Get(countryId).ConfigureAwait(false);

            if(!country.Any())
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpDelete("{countryId}")]
        public async Task<IActionResult> DeleteCountry(int countryId)
        {
            var country = await _countryService.Get(countryId).ConfigureAwait(false);

            if(!country.Any())
            {
                return NotFound();
            }

            var updated = await _countryService.Delete(countryId).ConfigureAwait(false);

            if(!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> InsertCountry([FromBody]Country country)
        {
            var (exists, updatedCountry) = await _countryService.Insert(country).ConfigureAwait(false);

            if(exists)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}