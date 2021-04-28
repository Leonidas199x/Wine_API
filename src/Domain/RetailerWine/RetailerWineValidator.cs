using Domain.Wine;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.RetailerWine
{
    public class RetailerWineValidator : AbstractValidator<RetailerWine>
    {
        private readonly int _maxLength = 50;
        private readonly IRetailerWineRepository _retailerWineRepository;
        private readonly IRetailerWineRepository _retailerRepository;
        private readonly IWineRepository _wineRepository;

        public RetailerWineValidator(
            IRetailerWineRepository retailerWineRepository,
            IRetailerWineRepository retailerRepository,
            IWineRepository wineRepository)
        {
            _retailerWineRepository = retailerWineRepository;
            _retailerRepository = retailerRepository;
            _wineRepository = wineRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(_maxLength)
                .WithMessage($"Name cannot be more that {_maxLength} characters");

            RuleFor(x => x.RetailerId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Retailer ID is required");

            RuleFor(x => x.WineId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Wine ID is required");

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("Description is required");

            RuleFor(x => x)
                .MustAsync(async (retailerWine, context, cancellation) =>
                {
                    return await Exists(retailerWine.Name).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage("Retailer with name already exists");

            RuleFor(x => x)
                .MustAsync(async (retailerWine, context, cancellation) =>
                {
                    return await RetailerExists(retailerWine.RetailerId).ConfigureAwait(false);
                })
                .WithMessage("Retailer ID does not exist");

            RuleFor(x => x)
                .MustAsync(async (retailerWine, context, cancellation) =>
                {
                    return await WineExists(retailerWine.WineId).ConfigureAwait(false);
                })
                .WithMessage("Wine ID does not exist");
        }

        private async Task<bool> Exists(string name)
        {
            var retailer = await _retailerWineRepository.GetByName(name).ConfigureAwait(false);
            return retailer == null;
        }

        private async Task<bool> RetailerExists(int id)
        {
            var retailer = await _retailerRepository.Get(id).ConfigureAwait(false);
            return retailer != null;
        }

        private async Task<bool> WineExists(int id)
        {
            var wine = await _wineRepository.Get(id).ConfigureAwait(false);
            return wine != null;
        }
    }
}
