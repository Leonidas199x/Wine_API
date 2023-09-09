using AutoMapper;
using Domain.Producer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;

        public ProducerController(
            IProducerService producerService, 
            IMapper mapper)
        {
            _producerService = producerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingInformation info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producers = await _producerService.GetAll(info.Page, info.PageSize).ConfigureAwait(false);

            return Ok(_mapper.Map<DataContract.PagedList<IEnumerable<DataContract.Producer>>>(producers));
        }

        [HttpGet("{producerId}")]
        public async Task<IActionResult> Get(int producerId)
        {
            var producer = await _producerService.Get(producerId).ConfigureAwait(false);
            if (producer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DataContract.Producer>(producer));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DataContract.ProducerCreate producer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainProducer = _mapper.Map<Producer>(producer);
            var validationResult = await _producerService.Insert(domainProducer).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataContract.Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainProducer = _mapper.Map<Producer>(producer);

            var validationResult = await _producerService.Update(domainProducer).ConfigureAwait(false);
            if (validationResult.IsValid)
            {
                return NoContent();
            }

            validationResult.AddToModelState(ModelState, string.Empty);

            return BadRequest(ModelState);
        }

        [HttpDelete("{producerId}")]
        public async Task<IActionResult> Delete(int producerId)
        {
            var producer = await _producerService.Get(producerId).ConfigureAwait(false);
            if (producer == null)
            {
                return NotFound();
            }

            await _producerService.Delete(producerId).ConfigureAwait(false);

            return NoContent();
        }
    }
}
