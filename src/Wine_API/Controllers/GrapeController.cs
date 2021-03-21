using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Domain.Grapes;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class GrapeController : Controller
    {
        private readonly IGrapeService _grapeService;

        public GrapeController(IGrapeService grapeService)
        {
            _grapeService = grapeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grapes = await _grapeService.GetAll().ConfigureAwait(false);

            if(!grapes.Any())
            {
                return NoContent();
            }

            return Ok(grapes);
        }

        [HttpGet("{grapeId}")]
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