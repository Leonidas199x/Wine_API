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
        private readonly IMapper _mapper;

        public RegionController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        [HttpGet("{regionId}")]
        public async Task<IActionResult> Get(int regionId)
        {
            var region = await _regionService.Get(regionId).ConfigureAwait(false);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.Region>(region));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var regions = await _regionService.GetAll(page, pageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<DataContract.Region>>(regions));
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup()
        {
            var lookup = await _regionService.GetLookup().ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<DataContract.RegionLookup>>(lookup));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.RegionCreate region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRegion = _mapper.Map<Region>(region);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRegion = _mapper.Map<Region>(region);

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
