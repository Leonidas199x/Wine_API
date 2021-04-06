﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _grapeMapper;

        public GrapeController(
            IGrapeService grapeService,
            IMapper grapeMapper)
        {
            _grapeService = grapeService;
            _grapeMapper = grapeMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grapes = await _grapeService.GetAll().ConfigureAwait(false);

            var outboundGrapes = _grapeMapper.Map<IEnumerable<DataContract.Grape>>(grapes);
            return Ok(outboundGrapes);
        }

        [HttpGet("{grapeId}")]
        public async Task<IActionResult> Get(int grapeId)
        { 
            var grape = await _grapeService.Get(grapeId).ConfigureAwait(false);
            if (grape == null)
            {
                return NotFound();
            }

            var outboundGrape = _grapeMapper.Map<DataContract.Grape>(grape);
            return Ok(outboundGrape);
        }

        [HttpGet]
        [Route("colour")]
        public async Task<IActionResult> GetAllColours()
        {
            var grapeColours = await _grapeService.GetAllColours().ConfigureAwait(false);

            var outboundGrapeColours = _grapeMapper.Map<IEnumerable<DataContract.GrapeColour>>(grapeColours);
            return Ok(outboundGrapeColours);
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

            var outboundGrapeColours = _grapeMapper.Map<DataContract.GrapeColour>(grapeColour);
            return Ok(outboundGrapeColours);
        }

        [HttpPost]
        [Route("colour")]
        public async Task<IActionResult> InsertGrapeColour(DataContract.GrapeColourCreate grapeColour)
        {
            var domainGrape = _grapeMapper.Map<GrapeColour>(grapeColour);

            var validationResult = await _grapeService.InsertGrapeColour(domainGrape).ConfigureAwait(false);
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
        public async Task<IActionResult> UpdateGrapeColour([FromBody] DataContract.GrapeColourCreate grapeColour)
        {
            var domainGrapeColour = _grapeMapper.Map<GrapeColour>(grapeColour);

            var validationResult = await _grapeService.UpdateGrapeColour(domainGrapeColour).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }
    }
}