using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Producer
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IValidator<Producer> _producerValidator;

        public ProducerService(IProducerRepository producerRepository, IValidator<Producer> producerValidator)
        {
            _producerRepository = producerRepository;
            _producerValidator = producerValidator;
        }

        public async Task<PagedList<IEnumerable<Producer>>> GetAll(int page, int pageSize)
        {
            return await _producerRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<Producer> Get(int Id)
        {
            return await _producerRepository.Get(Id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(Producer producer)
        {
            var validationResult = _producerValidator.Validate(producer);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _producerRepository.Insert(producer).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(Producer producer)
        {
            var validationResult = _producerValidator.Validate(producer);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _producerRepository.Update(producer).ConfigureAwait(false);
        }

        public async Task Delete(int producerId)
        {
            await _producerRepository.Delete(producerId).ConfigureAwait(false);
        }
    }
}
