using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Drinker
{
    public class DrinkerValdiator : AbstractValidator<Drinker>
    {
        private readonly IDrinkerRepository _drinkerRepository;
        private readonly int _maxLength = 255;

        public DrinkerValdiator(IDrinkerRepository drinkerRepository)
        {
            _drinkerRepository = drinkerRepository;

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Name is required")
               .MaximumLength(_maxLength)
               .WithMessage($"Name cannot be more than {_maxLength} characters");

            RuleFor(x => x)
                .MustAsync(async (drinker, context, cancellation) =>
                {
                    return await Exists(drinker.Name).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Drinker already exists");
        }

        private async Task<bool> Exists(string name)
        {
            var nameResult = await _drinkerRepository.GetByName(name).ConfigureAwait(false);
            return !nameResult.Any(x => x.Name == name);
        }
    }
}
