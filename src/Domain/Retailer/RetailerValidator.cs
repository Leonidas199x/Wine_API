using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Retailer
{
    public class RetailerValidator : AbstractValidator<Retailer>
    {
        private readonly int _maxLength = 50;
        private readonly IRetailerRepository _retailerRepository;

        public RetailerValidator(IRetailerRepository retailerRepository)
        {
            _retailerRepository = retailerRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(_maxLength)
                .WithMessage($"Name cannot be more that {_maxLength} characters");

            RuleFor(x => x.MinimumPurchaseQuantity)
                .NotNull()
                .WithMessage("Minimum Purchase Quantity is required");

            RuleFor(x => x.IncrementQuantity)
                .NotNull()
                .WithMessage("Increment Quantity is required");

            RuleFor(x => x.MaxCustomerRating)
                .NotNull()
                .WithMessage("Maximum Customer Rating is required");

            RuleFor(x => x)
                .MustAsync(async (stopperType, context, cancellation) =>
                {
                    return await Exists(stopperType.Name).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage("Retailer with name already exists");
        }

        private async Task<bool> Exists(string name)
        {
            var retailer = await _retailerRepository.GetByName(name).ConfigureAwait(false);
            return retailer == null;
        }
    }
}
