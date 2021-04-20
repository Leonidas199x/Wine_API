using FluentValidation;
using System.Threading.Tasks;

namespace Domain.StopperType
{
    public class StopperTypeValidator : AbstractValidator<StopperType>
    {
        private readonly int _maxLength = 50;
        private readonly IStopperTypeRepository _stopperTypeRepository;

        public StopperTypeValidator(IStopperTypeRepository stopperTypeRepository)
        {
            _stopperTypeRepository = stopperTypeRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(_maxLength)
                .WithMessage($"Name cannot be more that {_maxLength} characters");

            RuleFor(x => x)
                .MustAsync(async (stopperType, context, cancellation) =>
                {
                    return await Exists(stopperType.Name).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Stopper type with name already exists");
        }

        private async Task<bool> Exists(string name)
        {
            var stopper = await _stopperTypeRepository.GetByName(name).ConfigureAwait(false);
            return stopper != null;
        }
    }
}
