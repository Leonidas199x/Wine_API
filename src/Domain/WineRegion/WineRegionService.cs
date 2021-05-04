using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.WineRegion
{
    public class WineRegionService : IWineRegionService
    {
        private readonly IWineRegionRepository _wineRegionRepository;
        private readonly IValidator<WineRegion> _wineRegionValidator;

        public WineRegionService(IWineRegionRepository wineRegionRepository, IValidator<WineRegion> wineRegionValidator)
        {
            _wineRegionRepository = wineRegionRepository;
            _wineRegionValidator = wineRegionValidator;
        }

        public async Task<PagedList<IEnumerable<WineRegion>>> GetAll(int page, int pageSize)
        {
            return await _wineRegionRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<WineRegion> Get(int Id)
        {
            return await _wineRegionRepository.Get(Id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(WineRegion wineRegion)
        {
            var validationResult = _wineRegionValidator.Validate(wineRegion);
            if(!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _wineRegionRepository.Insert(wineRegion).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(WineRegion wineRegion)
        {
            var validationResult = _wineRegionValidator.Validate(wineRegion);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _wineRegionRepository.Update(wineRegion).ConfigureAwait(false);
        }

        public async Task Delete(int wineRegionId)
        {
            await _wineRegionRepository.Delete(wineRegionId).ConfigureAwait(false);
        }
    }
}
