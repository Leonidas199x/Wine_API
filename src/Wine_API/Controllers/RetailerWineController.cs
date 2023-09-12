using AutoMapper;
using Domain.RetailerWine;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class RetailerWineController : Controller
    {
        private readonly IRetailerWineService _retailerWineService;
        private readonly IMapper _mapper;

        public RetailerWineController(
            IRetailerWineService retailerWineService,
            IMapper mapper)
        {
            _retailerWineService = retailerWineService;
            _mapper = mapper;
        }

        [HttpGet("{retailerWineId}")]
        public async Task<IActionResult> Get(int retailerWineId)
        {
            var retailerWine = await _retailerWineService.Get(retailerWineId).ConfigureAwait(false);
            if (retailerWine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.RetailerWine>(retailerWine));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingInformation info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var retailerWineRecords = await _retailerWineService.GetAll(info.Page, info.PageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.RetailerWine>>>(retailerWineRecords));
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup()
        {
            var lookup = await _retailerWineService.GetLookup().ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<DataContract.RetailerWineLookup>>(lookup));
        }

        [HttpDelete("{retailerWineId}")]
        public async Task<IActionResult> Delete(int retailerWineId)
        {
            var country = await _retailerWineService.Get(retailerWineId).ConfigureAwait(false);
            if (country == null)
            {
                return NotFound();
            }

            var validationResult = await _retailerWineService.Delete(retailerWineId).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataContract.RetailerWineInbound retailerWine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRetailerWine = _mapper.Map<RetailerWine>(retailerWine);

            var validationResult = await _retailerWineService.Insert(domainRetailerWine).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.RetailerWine retailerWine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRetailerWine = _mapper.Map<RetailerWine>(retailerWine);

            var validationResult = await _retailerWineService.Update(domainRetailerWine).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }
    }
}
