using AutoMapper;
using Domain.Retailer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class RetailerController : Controller
    {
        private readonly IRetailerService _retailerService;
        private readonly IMapper _mapper;

        public RetailerController(IRetailerService retailerService, IMapper mapper)
        {
            _retailerService = retailerService;
            _mapper = mapper;
        }

        [HttpGet("{retailerId}")]
        public async Task<IActionResult> Get(int retailerId)
        {
            var retailer = await _retailerService.Get(retailerId).ConfigureAwait(false);
            if (retailer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.Retailer>(retailer));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingInformation info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var retailers = await _retailerService.GetAll(info.Page, info.PageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.Retailer>>>(retailers));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.RetailerCreate retailer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRetailer = _mapper.Map<Retailer>(retailer);
            var validationResult = await _retailerService.Insert(domainRetailer).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.Retailer retailer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRetailer = _mapper.Map<Retailer>(retailer);

            var validationResult = await _retailerService.Update(domainRetailer).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{retailerId}")]
        public async Task<IActionResult> Delete(int retailerId)
        {
            var retailer = await _retailerService.Get(retailerId).ConfigureAwait(false);
            if (retailer == null)
            {
                return NotFound();
            }

            await _retailerService.Delete(retailerId).ConfigureAwait(false);

            return NoContent();
        }
    }
}
