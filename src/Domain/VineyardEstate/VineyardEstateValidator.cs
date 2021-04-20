using FluentValidation;
using System.Threading.Tasks;

namespace Domain.VineyardEstate
{
    public class VineyardEstateValidator : AbstractValidator<VineyardEstate>
    {
        private readonly int _maxLength = 50;
        private readonly IVineyardEstateRepository _vineyardEstateRepository;

        public VineyardEstateValidator(IVineyardEstateRepository vineyardEstateRepository)
        {
            _vineyardEstateRepository = vineyardEstateRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(_maxLength)
                .WithMessage($"Name cannot be more that {_maxLength} characters");

            RuleFor(x => x)
                .MustAsync(async (vineyardEstate, context, cancellation) =>
                {
                    return await Exists(vineyardEstate.Name).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Region with name already exists");
        }

        private async Task<bool> Exists(string name)
        {
            var vineyardEstate = await _vineyardEstateRepository.GetByName(name).ConfigureAwait(false);
            return vineyardEstate == null;
        }
    }
}
