using AutoMapper;
using Domain.Issue;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WineAPI.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        private readonly IMapper _mapper;

        public IssueController(
            IIssueService issueService, 
            IMapper mapper)
        {
            _issueService = issueService;
            _mapper = mapper;
        }

        [HttpGet("{issueId}")]
        public async Task<IActionResult> Get(int issueId)
        {
            var country = await _issueService.Get(issueId).ConfigureAwait(false);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.Issue>(country));
        }

        [HttpGet("WineId/{wineId}")]
        public async Task<IActionResult> GetByWineId(int wineId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ratings = await _issueService.GetByWineId(wineId).ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<DataContract.Issue>>(ratings));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataContract.Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRating = _mapper.Map<Issue>(issue);

            var validationResult = await _issueService.Insert(domainRating).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainRating = _mapper.Map<Issue>(issue);

            var validationResult = await _issueService.Update(domainRating).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }
    }
}
