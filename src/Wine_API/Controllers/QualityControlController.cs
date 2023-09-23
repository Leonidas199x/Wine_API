using AutoMapper;
using Domain.QualityControl;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class QualityControlController : Controller
    {
        private readonly IQualityControlService _qualityControlService;
        private readonly IMapper _mapper;

        public QualityControlController(
            IQualityControlService qualityControlService, 
            IMapper mapper)
        {
            _qualityControlService = qualityControlService;
            _mapper = mapper;
        }

        [HttpGet("{qualityControlId}")]
        public async Task<IActionResult> Get(int qualityControlId)
        {
            var qualityControl = await _qualityControlService.Get(qualityControlId).ConfigureAwait(false);
            if (qualityControl == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.QualityControl>(qualityControl));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingInformation info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var qualityControllers = await _qualityControlService.GetAll(info.Page, info.PageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.QualityControl>>>(qualityControllers));
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup()
        {
            var lookup = await _qualityControlService.GetLookup().ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<DataContract.QualityControlLookup>>(lookup));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.QualityControlCreate qualityControl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRegion = _mapper.Map<QualityControl>(qualityControl);
            var validationResult = await _qualityControlService.Insert(domainRegion).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.QualityControl qualityControl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainQualityControl = _mapper
                .Map<QualityControl>(qualityControl);

            var validationResult = await _qualityControlService
                                            .Update(domainQualityControl)
                                            .ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{qualityControlId}")]
        public async Task<IActionResult> Delete(int qualityControlId)
        {
            var qualityControl = await _qualityControlService.Get(qualityControlId).ConfigureAwait(false);
            if (qualityControl == null)
            {
                return NotFound();
            }

            await _qualityControlService.Delete(qualityControlId).ConfigureAwait(false);

            return NoContent();
        }
    }
}
