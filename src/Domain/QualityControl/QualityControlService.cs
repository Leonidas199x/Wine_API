using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.QualityControl
{
    public class QualityControlService : IQualityControlService
    {
        private readonly IQualityControlRepository _qualityControlRepository;
        private readonly IValidator<QualityControl> _qualityControlValidator;

        public QualityControlService(
            IQualityControlRepository qualityControlRepository, 
            IValidator<QualityControl> qualityControlValidator)
        {
            _qualityControlRepository = qualityControlRepository;
            _qualityControlValidator = qualityControlValidator;
        }

        public async Task<PagedList<IEnumerable<QualityControl>>> GetAll(int page, int pageSize)
        {
            return await _qualityControlRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<QualityControl> Get(int id)
        {
            return await _qualityControlRepository.Get(id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(QualityControl qualityControl)
        {
            var validationResult = await _qualityControlValidator
                                            .ValidateAsync(qualityControl)
                                            .ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _qualityControlRepository.Insert(qualityControl).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(QualityControl qualityControl)
        {
            var validationResult = await _qualityControlValidator
                                            .ValidateAsync(qualityControl)
                                            .ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _qualityControlRepository.Update(qualityControl).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int id)
        {
            return await _qualityControlRepository.Delete(id).ConfigureAwait(false);
        }
    }
}
