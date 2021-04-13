using AutoMapper;
using Domain.Region;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _regionMapper;

        public RegionController(IRegionService regionService, IMapper regionMapper)
        {
            _regionService = regionService;
            _regionMapper = regionMapper;
        }

        [HttpGet("{regionId}")]
        public async Task<IActionResult> Get(int regionId)
        {
            var region = await _regionService.Get(regionId).ConfigureAwait(false);
            if (region == null)
            {
                return NotFound();
            }

            var outboundRegion = _regionMapper.Map<DataContract.Region>(region);

            return Ok(outboundRegion);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionService.GetAll().ConfigureAwait(false);
            var outboundRegions = _regionMapper.Map<IEnumerable<DataContract.Region>>(regions);

            return Ok(outboundRegions);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.RegionCreate region)
        {
            var domainRegion = _regionMapper.Map<Region>(region);
            var validationResult = await _regionService.Insert(domainRegion).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.Region region)
        {
            var domainRegion = _regionMapper.Map<Region>(region);

            var validationResult = await _regionService.Update(domainRegion).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{regionId}")]
        public async Task<IActionResult> Delete(int regionId)
        {
            var region = await _regionService.Get(regionId).ConfigureAwait(false);
            if (region == null)
            {
                return NotFound();
            }

            await _regionService.Delete(regionId).ConfigureAwait(false);

            return NoContent();
        }
    }
}
