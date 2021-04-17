using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Grapes
{
    public class GrapeValidator : AbstractValidator<Grape>
    {
        private readonly int _maxLength = 25;
        private readonly IGrapeRepository _grapeRepository;

        public GrapeValidator(IGrapeRepository grapeRepository)
        {
            _grapeRepository = grapeRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(_maxLength)
                .WithMessage($"Name cannot be more than {_maxLength} characters");

            RuleFor(x => x.GrapeColourId)
                .NotEmpty()
                .WithMessage("Grape colour ID is required")
                .MustAsync(async (grape, context, cancellation) =>
                {
                    return await GrapeColourExists(grape.GrapeColourId).ConfigureAwait(false);
                })
                .WithMessage($"Grape colour does not exists");

            RuleFor(x => x)
                .MustAsync(async (grape, context, cancellation) =>
                {
                    return await GrapeExists(grape.Name).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Grape already exists");
        }

        private async Task<bool> GrapeExists(string name)
        {
            var nameResult = await _grapeRepository.GetByName(name).ConfigureAwait(false);
            return !nameResult.Any(x => x.Name == name);
        }

        private async Task<bool> GrapeColourExists(int id)
        {
            var grapeColourResult = await _grapeRepository.GetGrapeColour(id).ConfigureAwait(false);
            return grapeColourResult != null;
        }
    }
}
