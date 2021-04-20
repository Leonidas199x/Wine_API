using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.VineyardEstate
{
    public class VineyardEstateService : IVineyardEstateService
    {
        private readonly IVineyardEstateRepository _vineyardEstateRepository;
        private readonly IValidator<VineyardEstate> _vineyardEstateValdator;

        public VineyardEstateService(IVineyardEstateRepository vineyardEstateRepository, IValidator<VineyardEstate> vineyardEstateValdator)
        {
            _vineyardEstateRepository = vineyardEstateRepository;
            _vineyardEstateValdator = vineyardEstateValdator;
        }

        public async Task<IEnumerable<VineyardEstate>> GetAll()
        {
            return await _vineyardEstateRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<VineyardEstate> Get(int vineyardEstateid)
        {
            return await _vineyardEstateRepository.Get(vineyardEstateid).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(VineyardEstate vineyardEstate)
        {
            var validationResult = _vineyardEstateValdator.Validate(vineyardEstate);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _vineyardEstateRepository.Insert(vineyardEstate).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(VineyardEstate vineyardEstate)
        {
            var validationResult = _vineyardEstateValdator.Validate(vineyardEstate);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _vineyardEstateRepository.Update(vineyardEstate).ConfigureAwait(false);
        }

        public async Task Delete(int regionId)
        {
            await _vineyardEstateRepository.Delete(regionId).ConfigureAwait(false);
        }
    }
}
