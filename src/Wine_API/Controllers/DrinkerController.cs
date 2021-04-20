using AutoMapper;
using Domain.Drinker;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class DrinkerController : Controller
    {
        private readonly IDrinkerService _drinkerService;
        private readonly IMapper _drinkerMapper;

        public DrinkerController(IDrinkerService drinkerService, IMapper drinkerMapper)
        {
            _drinkerService = drinkerService;
            _drinkerMapper = drinkerMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var drinkers = await _drinkerService.GetAll().ConfigureAwait(false);
            var outboundDrinkers = _drinkerMapper.Map<IEnumerable<DataContract.Drinker>>(drinkers);

            return Ok(outboundDrinkers);
        }

        [HttpGet("{drinkerId}")]
        public async Task<IActionResult> Get(int drinkerId)
        {
            var drinker = await _drinkerService.Get(drinkerId).ConfigureAwait(false);
            if (drinker == null)
            {
                return NotFound();
            }

            var outboundDrinker = _drinkerMapper.Map<DataContract.Drinker>(drinker);

            return Ok(outboundDrinker);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataContract.DrinkerInbound drinker)
        {
            var domainDrinker = _drinkerMapper.Map<Drinker>(drinker);

            var validationResult = await _drinkerService.Insert(domainDrinker).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.Drinker drinker)
        {
            var domainDrinker = _drinkerMapper.Map<Drinker>(drinker);

            var validationResult = await _drinkerService.Update(domainDrinker).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{drinkerId}")]
        public async Task<IActionResult> Delete(int drinkerId)
        {
            var drinker = await _drinkerService.Get(drinkerId).ConfigureAwait(false);
            if (drinker == null)
            {
                return NotFound();
            }

            var validationResult = await _drinkerService.Delete(drinkerId).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }
    }
}
