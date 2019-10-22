using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        [HttpGet("{GrapeId}")]
        public async Task<IActionResult> GetGrape(int grapeId)
        { 
            var grape = await _grapeService.Get(grapeId).ConfigureAwait(false);

            if (!grape.Any())
            {
                return NotFound();
            }

            return Ok(grape);
        }
    }
}