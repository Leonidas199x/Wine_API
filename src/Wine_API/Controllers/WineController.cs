using AutoMapper;
using Domain.Wine;
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
    }
}