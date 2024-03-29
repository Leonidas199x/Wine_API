﻿using FluentValidation;
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

        public async Task<IEnumerable<QualityControl>> GetAll()
        {
            return await _qualityControlRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<QualityControl> Get(int id)
        {
            return await _qualityControlRepository.Get(id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(QualityControl qualityControl)
        {
            var validationResult = _qualityControlValidator.Validate(qualityControl);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _qualityControlRepository.Insert(qualityControl).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(QualityControl qualityControl)
        {
            var validationResult = _qualityControlValidator.Validate(qualityControl);
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
