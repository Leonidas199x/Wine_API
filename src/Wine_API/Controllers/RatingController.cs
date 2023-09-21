using AutoMapper;
using Domain.Rating;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;
        private readonly IMapper _mapper;

        public RatingController(IRatingService ratingService, IMapper mapper)
        {
            _ratingService = ratingService;
            _mapper = mapper;
        }

        [HttpGet("WineId/{wineId}")]
        public async Task<IActionResult> GetByWineId(int wineId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ratings = await _ratingService.GetByWineId(wineId).ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<DataContract.WineRating>>(ratings));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataContract.WineRating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRating = _mapper.Map<WineRating>(rating);

            var validationResult = await _ratingService.Insert(domainRating).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.WineRating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRating = _mapper.Map<WineRating>(rating);

            var validationResult = await _ratingService.Update(domainRating).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{ratingId}")]
        public async Task<IActionResult> Delete(int ratingId)
        {
            var qualityControl = await _ratingService.Get(ratingId).ConfigureAwait(false);
            if (qualityControl == null)
            {
                return NotFound();
            }

            await _ratingService.Delete(ratingId).ConfigureAwait(false);

            return NoContent();
        }
    }
}
