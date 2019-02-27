using Microsoft.AspNetCore.Mvc;
using Service;
using System.Linq;

namespace Wine_API.Controllers
{
    public class CountriesController : Controller
    {
        private IWineService _wineService;

        public CountriesController(IWineService wineService)
        {
            _wineService = wineService;
        }

        [Route("countries")]
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _wineService.GetAllCountries();

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
            var country = _wineService.GetCountry(countryId);

            if(country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }
    }
}