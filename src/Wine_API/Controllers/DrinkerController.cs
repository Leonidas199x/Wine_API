using AutoMapper;
using Domain.Drinker;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class DrinkerController : Controller
    {
        private readonly IDrinkerService _drinkerService;
        private readonly IMapper _mapper;

        public DrinkerController(IDrinkerService drinkerService, IMapper mapper)
        {
            _drinkerService = drinkerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var drinkers = await _drinkerService.GetAll().ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<DataContract.Drinker>>(drinkers));
        }

        [HttpGet("{drinkerId}")]
        public async Task<IActionResult> Get(int drinkerId)
        {
            var drinker = await _drinkerService.Get(drinkerId).ConfigureAwait(false);
            if (drinker == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.Drinker>(drinker));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataContract.DrinkerCreate drinker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainDrinker = _mapper.Map<Drinker>(drinker);

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainDrinker = _mapper.Map<Drinker>(drinker);

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
