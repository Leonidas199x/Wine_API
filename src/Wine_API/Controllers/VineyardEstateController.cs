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
        private readonly IMapper _vineyardEstateMapper;

        public VineyardEstateController(IVineyardEstateService vineyardEstateService, IMapper vineyardEstateMapper)
        {
            _vineyardEstateService = vineyardEstateService;
            _vineyardEstateMapper = vineyardEstateMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vineyardEstates = await _vineyardEstateService.GetAll().ConfigureAwait(false);
            var outboundRegions = _vineyardEstateMapper.Map<IEnumerable<DataContract.Producer>>(vineyardEstates);

            return Ok(outboundRegions);
        }

        [HttpGet("{vineyardEstateId}")]
        public async Task<IActionResult> Get(int vineyardEstateId)
        {
            var vineyardEstate = await _vineyardEstateService.Get(vineyardEstateId).ConfigureAwait(false);
            if (vineyardEstate == null)
            {
                return NotFound();
            }

            var outboundVineyardEstate = _vineyardEstateMapper.Map<DataContract.VineyardEstate>(vineyardEstate);

            return Ok(outboundVineyardEstate);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.VineyardEstateCreate vineyardEstate)
        {
            var domainVineyardEstate = _vineyardEstateMapper.Map<VineyardEstate>(vineyardEstate);
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
            var domainVineyardEstate = _vineyardEstateMapper.Map<VineyardEstate>(vineyardEstate);

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
