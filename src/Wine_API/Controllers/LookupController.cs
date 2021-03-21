using Microsoft.AspNetCore.Mvc;
using Domain.Countries;
using System.Linq;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class LookupController : Controller
    {
        private readonly ICountryService _countryService;

        public LookupController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryService.GetCountryLookup().ConfigureAwait(false);
            if (!countries.Any())
            {
                return NoContent(); 
            }

            return Ok(countries);
        }
    }
}