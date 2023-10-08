using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Wine
{
    public class WineService : IWineService
    {
        private readonly IWineRepository _wineRepository;
        private readonly IValidator<WineCreate> _wineValidator;
        private readonly IValidator<WineUpdate> _wineUpdateValidator;

        public WineService(
            IWineRepository wineRepository, 
            IValidator<WineCreate> wineValidator,
            IValidator<WineUpdate> wineUpdateValidator)
        {
            _wineRepository = wineRepository;
            _wineValidator = wineValidator;
            _wineUpdateValidator = wineUpdateValidator;
        }

        public async Task<PagedList<IEnumerable<WineHeader>>> GetAll(int page, int pageSize)
        {
            return await _wineRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<Wine> Get(int Id)
        {
            return await _wineRepository.Get(Id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(WineUpdate wine)
        {
            var validationResult = _wineUpdateValidator.Validate(wine);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _wineRepository.Update(wine).ConfigureAwait(false);
        }

        public async Task<(ValidationResult, int)> Insert(WineCreate wine)
        {
            var validationResult = await _wineValidator.ValidateAsync(wine);
            if (!validationResult.IsValid)
            {
                return (validationResult, default);
            }

            return await _wineRepository.Insert(wine).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int id)
        {
            return await _wineRepository.Delete(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<WineGrape>> GetGrapes(int wineId)
        {
            return await _wineRepository.GetGrapes(wineId).ConfigureAwait(false);
        }
    }
}
