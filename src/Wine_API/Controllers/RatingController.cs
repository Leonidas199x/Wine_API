using AutoMapper;
using Domain.Rating;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
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
    }
}
