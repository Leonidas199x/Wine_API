using Microsoft.AspNetCore.Mvc;
using Service;

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

            if (countries != null)
            {
                return Ok(countries);
            }
            else
            {
              return   NotFound();
            }
        }
    }
}