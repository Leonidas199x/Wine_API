using AutoMapper;
using Domain.WineRegion;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WineAPI.Models;

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
        public async Task<IActionResult> GetAll([FromQuery] PagingInformation info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wineRegions = await _wineRegionService.GetAll(info.Page, info.PageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.WineRegion>>>(wineRegions));
        }

        [HttpGet("{wineRegionId}")]
        public async Task<IActionResult> Get(int wineRegionId)
        {
            var wineRegion = await _wineRegionService.Get(wineRegionId).ConfigureAwait(false);
            if (wineRegion == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.WineRegion>(wineRegion));
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
