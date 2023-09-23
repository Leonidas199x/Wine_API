using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.WineType
{
    public class WineTypeService : IWineTypeService
    {
        private readonly IWineTypeRepository _wineTypeRepository;
        private readonly IValidator<WineType> _wineTypeValidator;

        public WineTypeService(IWineTypeRepository wineTypeRepository, IValidator<WineType> wineTypeValidator)
        {
            _wineTypeRepository = wineTypeRepository;
            _wineTypeValidator = wineTypeValidator;
        }

        public async Task<PagedList<IEnumerable<WineType>>> GetAll(int page, int pageSize)
        {
            return await _wineTypeRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<WineType> Get(int id)
        {
            return await _wineTypeRepository.Get(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<WineTypeLookup>> GetLookup()
        {
            return await _wineTypeRepository.GetLookup().ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(WineType wineType)
        {
            var validationResult = await _wineTypeValidator.ValidateAsync(wineType).ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _wineTypeRepository.Insert(wineType).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(WineType wineType)
        {
            var validationResult = await _wineTypeValidator.ValidateAsync(wineType).ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _wineTypeRepository.Update(wineType).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int id)
        {
            return await _wineTypeRepository.Delete(id).ConfigureAwait(false);
        }
    }
}
