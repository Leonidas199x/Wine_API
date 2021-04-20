using AutoMapper;
using Domain.WineRegion;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class WineRegionController : Controller
    {
        private readonly IWineRegionService _wineRegionService;
        private readonly IMapper _mapper;

        public WineRegionController(IWineRegionService wineRegionService, IMapper mapper)
        {
            _wineRegionService = wineRegionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wineRegions = await _wineRegionService.GetAll().ConfigureAwait(false);
            var outboundRegions = _mapper.Map<IEnumerable<DataContract.WineRegion>>(wineRegions);

            return Ok(outboundRegions);
        }

        [HttpGet("{wineRegionId}")]
        public async Task<IActionResult> Get(int wineRegionId)
        {
            var wineRegion = await _wineRegionService.Get(wineRegionId).ConfigureAwait(false);
            if (wineRegion == null)
            {
                return NotFound();
            }

            var outboundRegion = _mapper.Map<DataContract.WineRegion>(wineRegion);

            return Ok(outboundRegion);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.WineRegionCreate wineRegion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainWineRegion = _mapper.Map<WineRegion>(wineRegion);
            var validationResult = await _wineRegionService.Insert(domainWineRegion).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.WineRegion wineRegion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRegion = _mapper.Map<WineRegion>(wineRegion);

            var validationResult = await _wineRegionService.Update(domainRegion).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{wineRegionId}")]
        public async Task<IActionResult> Delete(int wineRegionId)
        {
            var region = await _wineRegionService.Get(wineRegionId).ConfigureAwait(false);
            if (region == null)
            {
                return NotFound();
            }

            await _wineRegionService.Delete(wineRegionId).ConfigureAwait(false);

            return NoContent();
        }
    }
}
