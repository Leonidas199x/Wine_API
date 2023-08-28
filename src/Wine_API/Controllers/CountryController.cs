using Microsoft.AspNetCore.Mvc;
using Domain.Countries;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using System.Collections.Generic;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(
            ICountryService countryService,
            IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> Get(int countryId)
        {
            var country = await _countryService.Get(countryId).ConfigureAwait(false);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.Country>(country));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            if (page == 0 || pageSize == 0)
            {
                return BadRequest("Page and/or PageSize cannot be 0");
            }

            var countries = await _countryService.GetAll(page, pageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.Country>>>(countries));
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup()
        {
            var lookup = await _countryService.GetLookup().ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<DataContract.CountryLookup>>(lookup));
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string name, 
            [FromQuery] string isoCode, 
            [FromQuery] int page, 
            [FromQuery] int pageSize)
        {
            var searchParams = new DataContract.CountrySearch
            {
                Name = name,
                IsoCode = isoCode,
            };

            var domainSearch = _mapper.Map<CountrySearch>(searchParams);
            var countries = await _countryService.Search(domainSearch, page, pageSize).ConfigureAwait(false);
           
            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.Country>>>(countries));
        }

        [HttpDelete("{countryId}")]
        public async Task<IActionResult> Delete(int countryId)
        {
            var country = await _countryService.Get(countryId).ConfigureAwait(false);
            if (country == null)
            {
                return NotFound();
            }

            var validationResult = await _countryService.Delete(countryId).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataContract.CountryInbound country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainCountry = _mapper.Map<Domain.Country>(country);

            var validationResult = await _countryService.Insert(domainCountry).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainCountry = _mapper.Map<Domain.Country>(country);

            var validationResult = await _countryService.Update(domainCountry).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }
    }
}