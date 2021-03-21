using Microsoft.AspNetCore.Mvc;
using Domain.Countries;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

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
        public async Task<IActionResult> InsertCountry([FromBody] DataContract.Country country)
        {
            var domainCountry = _countryMapper.Map<Country>(country);

            var validationResult = await _countryService.Insert(domainCountry).ConfigureAwait(false);

            if(validationResult.IsValid)
            {
                return NoContent();
            }

            return BadRequest(ModelState);
        }
    }
}