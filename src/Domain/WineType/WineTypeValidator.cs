using FluentValidation;
using System.Threading.Tasks;

namespace Domain.WineType
{
    public class WineTypeValidator : AbstractValidator<WineType>
    {
        private readonly int _maxLength = 50;
        private readonly IWineTypeRepository _wineTypeRepository;

        public WineTypeValidator(IWineTypeRepository wineTypeRepositoru)
        {
            _wineTypeRepository = wineTypeRepositoru;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(_maxLength)
                .WithMessage($"Name cannot be more that {_maxLength} characters");

            RuleFor(x => x)
                .MustAsync(async (wineType, context, cancellation) =>
                {
                    return await Exists(wineType.Name).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Wine type with name already exists");
        }

        private async Task<bool> Exists(string name)
        {
            var stopper = await _wineTypeRepository.GetByName(name).ConfigureAwait(false);
            return stopper == null;
        }
    }
}
