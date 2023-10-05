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

        public WineService(IWineRepository wineRepository, IValidator<WineCreate> wineValidator)
        {
            _wineRepository = wineRepository;
            _wineValidator = wineValidator;
        }

        public async Task<PagedList<IEnumerable<WineHeader>>> GetAll(int page, int pageSize)
        {
            return await _wineRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<Wine> Get(int Id)
        {
            return await _wineRepository.Get(Id).ConfigureAwait(false);
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
    }
}
