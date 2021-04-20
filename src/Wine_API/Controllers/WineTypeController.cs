using AutoMapper;
using Domain.WineType;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class WineTypeController : Controller
    {
        private readonly IWineTypeService _wineTypeService;
        private readonly IMapper _mapper;

        public WineTypeController(IWineTypeService wineTypeService, IMapper mapper)
        {
            _wineTypeService = wineTypeService;
            _mapper = mapper;
        }

        [HttpGet("{wineTypeId}")]
        public async Task<IActionResult> Get(int wineTypeId)
        {
            var wineType = await _wineTypeService.Get(wineTypeId).ConfigureAwait(false);
            if (wineType == null)
            {
                return NotFound();
            }

            var outboundType = _mapper.Map<DataContract.WineType>(wineType);

            return Ok(outboundType);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wineTypes = await _wineTypeService.GetAll().ConfigureAwait(false);
            var outboundTypes = _mapper.Map<IEnumerable<DataContract.WineType>>(wineTypes);

            return Ok(outboundTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.WineTypeCreate wineType)
        {
            var domainWineType = _mapper.Map<WineType>(wineType);
            var validationResult = await _wineTypeService.Insert(domainWineType).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.WineType wineType)
        {
            var domainType = _mapper.Map<WineType>(wineType);

            var validationResult = await _wineTypeService.Update(domainType).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{wineTypeId}")]
        public async Task<IActionResult> Delete(int wineTypeId)
        {
            var wineType = await _wineTypeService.Get(wineTypeId).ConfigureAwait(false);
            if (wineType == null)
            {
                return NotFound();
            }

            await _wineTypeService.Delete(wineTypeId).ConfigureAwait(false);

            return NoContent();
        }
    }
}
