using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Grapes
{
    public class GrapeColourValidator : AbstractValidator<GrapeColour>
    {
        private readonly int _maxLength = 20;
        private readonly IGrapeRepository _grapeRepository;

        public GrapeColourValidator(IGrapeRepository grapeRepository)
        {
            _grapeRepository = grapeRepository;

            RuleFor(x => x.Colour)
                .NotEmpty()
                .WithMessage("Colour is required")
                .MaximumLength(_maxLength)
                .WithMessage($"Colour cannot be more that {_maxLength} characters");

            RuleFor(x => x)
                .MustAsync(async (grapeColour, context, cancellation) =>
                {
                    return await GrapeColourExists(grapeColour.Colour).ConfigureAwait(false);
                })
                .WithMessage($"Grape colour already exists");
        }

        private async Task<bool> GrapeColourExists(string grapeColour)
        {
            var colourResult = await _grapeRepository.GetByColour(grapeColour).ConfigureAwait(false);
            return !colourResult.Any(x => x.Colour == grapeColour);
        }
    }
}
