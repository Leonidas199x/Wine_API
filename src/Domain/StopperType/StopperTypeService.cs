using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.StopperType
{
    public class StopperTypeService : IStopperTypeService
    {
        private readonly IStopperTypeRepository _stopperTypeRepository;
        private readonly IValidator<StopperType> _stopperTypeValidator;

        public StopperTypeService(IStopperTypeRepository stopperTypeRepository, IValidator<StopperType> stopperTypeValidator)
        {
            _stopperTypeRepository = stopperTypeRepository;
            _stopperTypeValidator = stopperTypeValidator;
        }

        public async Task<PagedList<IEnumerable<StopperType>>> GetAll(int page, int pageSize)
        {
            return await _stopperTypeRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<StopperType> Get(int id)
        {
            return await _stopperTypeRepository.Get(id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(StopperType stopperType)
        {
            var validationResult = await _stopperTypeValidator.ValidateAsync(stopperType).ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _stopperTypeRepository.Insert(stopperType).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(StopperType stopperType)
        {
            var validationResult = await _stopperTypeValidator.ValidateAsync(stopperType).ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _stopperTypeRepository.Update(stopperType).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int id)
        {
            return await _stopperTypeRepository.Delete(id).ConfigureAwait(false);
        }
    }
}
