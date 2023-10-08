using AutoMapper;
using DataContract;
using Domain.Wine;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class WineController : Controller
    {
        private readonly IWineService _wineService;
        private readonly IMapper _mapper;

        public WineController(IWineService wineService, IMapper mapper)
        {
            _wineService = wineService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingInformation info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vineyardEstates = await _wineService.GetAll(info.Page, info.PageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.WineHeader>>>(vineyardEstates));
        }

        [HttpGet("{wineId}")]
        public async Task<IActionResult> Get(int wineId)
        {
            var wine = await _wineService.Get(wineId).ConfigureAwait(false);
            if (wine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.Wine>(wine));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.WineUpdate wine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainWine = _mapper.Map<Domain.Wine.WineUpdate>(wine);
            var validationResult = await _wineService.Update(domainWine).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataContract.WineCreate wine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainWine = _mapper.Map<Domain.Wine.WineCreate>(wine);
            var (validationResult, insertedId) = await _wineService.Insert(domainWine).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                var createdWine = new WineCreated
                {
                    WineId = insertedId,
                };

                return Ok(createdWine);
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{wineId}")]
        public async Task<IActionResult> Delete(int wineId)
        {
            var wine = await _wineService.Get(wineId).ConfigureAwait(false);
            if (wine == null)
            {
                return NotFound();
            }

            var validationResult = await _wineService.Delete(wineId).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }
    }
}