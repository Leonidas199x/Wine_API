using AutoMapper;
using Domain.VineyardEstate;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class VineyardEstateController : Controller
    {
        private readonly IVineyardEstateService _vineyardEstateService;
        private readonly IMapper _mapper;

        public VineyardEstateController(
            IVineyardEstateService vineyardEstateService, 
            IMapper mapper)
        {
            _vineyardEstateService = vineyardEstateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var vineyardEstates = await _vineyardEstateService.GetAll(page, pageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.VineyardEstate>>>(vineyardEstates));
        }

        [HttpGet("{vineyardEstateId}")]
        public async Task<IActionResult> Get(int vineyardEstateId)
        {
            var vineyardEstate = await _vineyardEstateService.Get(vineyardEstateId).ConfigureAwait(false);
            if (vineyardEstate == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.VineyardEstate>(vineyardEstate));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.VineyardEstateCreate vineyardEstate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainVineyardEstate = _mapper.Map<VineyardEstate>(vineyardEstate);
            var validationResult = await _vineyardEstateService.Insert(domainVineyardEstate).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.VineyardEstate vineyardEstate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainVineyardEstate = _mapper.Map<VineyardEstate>(vineyardEstate);

            var validationResult = await _vineyardEstateService.Update(domainVineyardEstate).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{vineyardEstateId}")]
        public async Task<IActionResult> Delete(int vineyardEstateId)
        {
            var vineyardEstate = await _vineyardEstateService.Get(vineyardEstateId).ConfigureAwait(false);
            if (vineyardEstate == null)
            {
                return NotFound();
            }

            await _vineyardEstateService.Delete(vineyardEstateId).ConfigureAwait(false);

            return NoContent();
        }
    }
}
