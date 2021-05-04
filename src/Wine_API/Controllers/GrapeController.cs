using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Grapes;
using AutoMapper;
using System.Collections.Generic;
using FluentValidation.AspNetCore;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class GrapeController : Controller
    {
        private readonly IGrapeService _grapeService;
        private readonly IMapper _mapper;

        public GrapeController(
            IGrapeService grapeService,
            IMapper mapper)
        {
            _grapeService = grapeService;
            _mapper = mapper;
        }

        #region grape
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var grapes = await _grapeService.GetAll(page, pageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.Grape>>>(grapes));
        }

        [HttpGet("{grapeId}")]
        public async Task<IActionResult> Get(int grapeId)
        { 
            var grape = await _grapeService.Get(grapeId).ConfigureAwait(false);
            if (grape == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.Grape>(grape));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.GrapeCreate grape)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainGrape = _mapper.Map<Domain.Grape>(grape);

            var validationResult = await _grapeService.InsertGrape(domainGrape).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut("{grapeId}")]
        public async Task<IActionResult> UpdateGrape([FromBody] DataContract.Grape grape)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainGrape = _mapper.Map<Domain.Grape>(grape);

            var validationResult = await _grapeService.UpdateGrape(domainGrape).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{grapeId}")]
        public async Task<IActionResult> DeleteGrape(int grapeId)
        {
            var grape = await _grapeService.Get(grapeId).ConfigureAwait(false);
            if (grape == null)
            {
                return NotFound();
            }

            var validationResult = await _grapeService.DeleteGrape(grapeId).ConfigureAwait(false);
            if(!validationResult.IsValid)
            {
                return BadRequest();
            }

            return NoContent();
        }
        #endregion

        #region colour
        [HttpGet]
        [Route("colour")]
        public async Task<IActionResult> GetAllColours([FromQuery] int page, [FromQuery] int pageSize)
        {
            var grapeColours = await _grapeService.GetAllColours(page, pageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.GrapeColour>>>(grapeColours));
        }

        [HttpGet]
        [Route("colour/{grapeColourId}")]
        public async Task<IActionResult> GetGrapeColour(int grapeColourId)
        {
            var grapeColour = await _grapeService.GetGrapeColour(grapeColourId).ConfigureAwait(false);
            if(grapeColour == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.GrapeColour>(grapeColour));
        }

        [HttpPost]
        [Route("colour")]
        public async Task<IActionResult> InsertGrapeColour([FromBody] DataContract.GrapeColourCreate grapeColour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainGrapeColour = _mapper.Map<GrapeColour>(grapeColour);

            var validationResult = await _grapeService.InsertGrapeColour(domainGrapeColour).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("colour/{grapeColourId}")]
        public async Task<IActionResult> DeleteGrapeColour(int grapeColourId)
        {
            var grapeColour = await _grapeService.GetGrapeColour(grapeColourId).ConfigureAwait(false);
            if (grapeColour == null)
            {
                return NotFound();
            }

            await _grapeService.DeleteGrapeColour(grapeColourId).ConfigureAwait(false);

            return NoContent();
        }

        [HttpPut("colour")]
        public async Task<IActionResult> UpdateGrapeColour([FromBody] DataContract.GrapeColour grapeColour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainGrapeColour = _mapper.Map<GrapeColour>(grapeColour);

            var validationResult = await _grapeService.UpdateGrapeColour(domainGrapeColour).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }
        #endregion
    }
}