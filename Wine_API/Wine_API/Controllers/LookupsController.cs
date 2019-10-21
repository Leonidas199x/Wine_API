using Microsoft.AspNetCore.Mvc;
using WineService.Countries;
using System.Linq;
using System.Threading.Tasks;

namespace Wine_API.Controllers
{
    [Route("[controller]")]
    public class LookupsController : Controller
    {
        private ICountryService _countryService;

        public LookupsController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryService.GetCountryLookup().ConfigureAwait(false);

            if (!countries.Any())
            {
                return NotFound(); 
            }
            
            return Ok(countries);
        }
    }
}