using Microsoft.AspNetCore.Mvc;
using WineService.Countries;
using System.Linq;

namespace Wine_API.Controllers
{
    public class CountriesController : Controller
    {
        private ICountryService _countryService;

        public CountriesController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [Route("countries")]
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _countryService.GetAllCountries();

            if (!countries.Any())
            {
                return NotFound(); 
            }
            
            return Ok(countries);
        }

        [Route("countries/{CountryId}")]
        [HttpGet]
        public IActionResult GetCountry(int countryId)
        {
            var country = _countryService.GetCountry(countryId);

            if(country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }
    }
}