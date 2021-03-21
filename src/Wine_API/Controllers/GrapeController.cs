using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Grapes;
using AutoMapper;
using System.Collections.Generic;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class GrapeController : Controller
    {
        private readonly IGrapeService _grapeService;
        private readonly IMapper _grapeMapper;

        public GrapeController(
            IGrapeService grapeService,
            IMapper grapeMapper)
        {
            _grapeService = grapeService;
            _grapeMapper = grapeMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grapes = await _grapeService.GetAll().ConfigureAwait(false);

            var outboundGrapes = _grapeMapper.Map<IEnumerable<DataContract.Grape>>(grapes);
            return Ok(outboundGrapes);
        }

        [HttpGet("{grapeId}")]
        public async Task<IActionResult> Get(int grapeId)
        { 
            var grape = await _grapeService.Get(grapeId).ConfigureAwait(false);
            if (grape == null)
            {
                return NotFound();
            }

            var outboundGrape = _grapeMapper.Map<DataContract.Grape>(grape);
            return Ok(outboundGrape);
        }
    }
}