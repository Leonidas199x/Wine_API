﻿using AutoMapper;
using Domain.StopperType;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class StopperTypeController : Controller
    {
        private readonly IStopperTypeService _stopperTypeService;
        private readonly IMapper _mapper;

        public StopperTypeController(IStopperTypeService stopperTypeService, IMapper mapper)
        {
            _stopperTypeService = stopperTypeService;
            _mapper = mapper;
        }

        [HttpGet("{stopperTypeId}")]
        public async Task<IActionResult> Get(int stopperTypeId)
        {
            var stopperType = await _stopperTypeService.Get(stopperTypeId).ConfigureAwait(false);
            if (stopperType == null)
            {
                return NotFound();
            }

            var outboundRegion = _mapper.Map<DataContract.StopperType>(stopperType);

            return Ok(outboundRegion);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stopperTypes = await _stopperTypeService.GetAll().ConfigureAwait(false);
            var outboundStoppers = _mapper.Map<IEnumerable<DataContract.StopperType>>(stopperTypes);

            return Ok(outboundStoppers);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.StopperTypeCreate stopperType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainStopper = _mapper.Map<StopperType>(stopperType);
            var validationResult = await _stopperTypeService.Insert(domainStopper).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.StopperType stopperType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainStopper = _mapper.Map<StopperType>(stopperType);

            var validationResult = await _stopperTypeService.Update(domainStopper).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{stopperTypeId}")]
        public async Task<IActionResult> Delete(int stopperTypeId)
        {
            var stopperType = await _stopperTypeService.Get(stopperTypeId).ConfigureAwait(false);
            if (stopperType == null)
            {
                return NotFound();
            }

            await _stopperTypeService.Delete(stopperTypeId).ConfigureAwait(false);

            return NoContent();
        }
    }
}