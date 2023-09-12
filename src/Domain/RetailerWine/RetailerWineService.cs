using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.RetailerWine
{
    public class RetailerWineService : IRetailerWineService
    {
        private readonly IRetailerWineRepository _retailerWineRepository;
        private readonly IValidator<RetailerWine> _validator;

        public RetailerWineService(
            IRetailerWineRepository retailerWineRepository,
            IValidator<RetailerWine> validator)
        {
            _retailerWineRepository = retailerWineRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<RetailerWineLookup>> GetLookup()
        {
            return await _retailerWineRepository.GetLookup().ConfigureAwait(false);
        }

        public async Task<RetailerWine> Get(int id)
        {
            return await _retailerWineRepository.Get(id).ConfigureAwait(false);
        }

        public async Task<PagedList<IEnumerable<RetailerWine>>> GetAll(int page, int pageSize)
        {
            return await _retailerWineRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<IEnumerable<RetailerWine>> GetByName(string name)
        {
            return await _retailerWineRepository.GetByName(name).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int id)
        {
            return await _retailerWineRepository.Delete(id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(RetailerWine retailerWine)
        {
            var validationResult = _validator.Validate(retailerWine);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _retailerWineRepository.Insert(retailerWine).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(RetailerWine retailerWine)
        {
            var validationResult = _validator.Validate(retailerWine);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _retailerWineRepository.Update(retailerWine).ConfigureAwait(false);
        }
    }
}
