using AutoMapper;
using Domain.Wine;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("{wineId}")]
        public async Task<IActionResult> GetWine(int wineId)
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