using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Region
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IValidator<Region> _regionValidator;

        public RegionService(IRegionRepository regionRepository, IValidator<Region> regionValidator)
        {
            _regionRepository = regionRepository;
            _regionValidator = regionValidator;
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await _regionRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<Region> Get(int regionId)
        {
            return await _regionRepository.Get(regionId).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(Region region)
        {
            var validationResult = _regionValidator.Validate(region);
            if(!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _regionRepository.Insert(region).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(Region region)
        {
            var validationResult = _regionValidator.Validate(region);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _regionRepository.Update(region).ConfigureAwait(false);
        }

        public async Task Delete(int regionId)
        {
            await _regionRepository.Delete(regionId).ConfigureAwait(false);
        }
    }
}
