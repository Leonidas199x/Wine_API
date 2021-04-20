using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Retailer
{
    public class RetailerService : IRetailerService
    {
        private readonly IRetailerRepository _retailerRepository;
        private readonly IValidator<Retailer> _reatilerValidator;

        public RetailerService(IRetailerRepository retailerRepository, IValidator<Retailer> reatilerValidator)
        {
            _retailerRepository = retailerRepository;
            _reatilerValidator = reatilerValidator;
        }

        public async Task<IEnumerable<Retailer>> GetAll()
        {
            return await _retailerRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<Retailer> Get(int id)
        {
            return await _retailerRepository.Get(id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Insert(Retailer retailer)
        {
            var validationResult = _reatilerValidator.Validate(retailer);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _retailerRepository.Insert(retailer).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Update(Retailer retailer)
        {
            var validationResult = _reatilerValidator.Validate(retailer);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _retailerRepository.Update(retailer).ConfigureAwait(false);
        }

        public async Task<ValidationResult> Delete(int id)
        {
            return await _retailerRepository.Delete(id).ConfigureAwait(false);
        }
    }
}
