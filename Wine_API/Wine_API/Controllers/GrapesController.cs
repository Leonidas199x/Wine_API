using Microsoft.AspNetCore.Mvc;
using WineService.Grapes;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class GrapesController : Controller
    {
        private IGrapeService _grapeService;

        public GrapesController(IGrapeService grapeService)
        {
            _grapeService = grapeService;
        }

        
    }
}