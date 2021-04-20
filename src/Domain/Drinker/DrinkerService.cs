using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Drinker
{
    public class DrinkerService : IDrinkerService
    {
        private readonly IDrinkerRepository _drinkerRepository;
        private readonly IValidator<Drinker> _drinkerValidator;

        public DrinkerService(IDrinkerRepository drinkerRepository, IValidator<Drinker> drinkerValidator)
        {
            _drinkerRepository = drinkerRepository;
            _drinkerValidator = drinkerValidator;
        }

        public async Task<IEnumerable<Drinker>> GetAll()
        {
            return await _drinkerRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<Drinker> Get(int drinkerId)
        {
            return await _drinkerRepository.Get(drinkerId).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(Drinker drinker)
        {
            var validationResult = _drinkerValidator.Validate(drinker);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _drinkerRepository.Insert(drinker).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(Drinker drinker)
        {
            var validationResult = _drinkerValidator.Validate(drinker);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _drinkerRepository.Update(drinker).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int drinkerId)
        {
            return await _drinkerRepository.Delete(drinkerId).ConfigureAwait(false);
        }
    }
}
