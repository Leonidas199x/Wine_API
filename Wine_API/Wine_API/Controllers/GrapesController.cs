using Microsoft.AspNetCore.Mvc;
using WineService.Countries;
using System.Linq;
using System.Threading.Tasks;
using DataContract.Country;

namespace Wine_API.Controllers
{
    [Route("[controller]")]
    public class GrapesController : Controller
    {
        private ICountryService _countryService;

        public GrapesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        
    }
}