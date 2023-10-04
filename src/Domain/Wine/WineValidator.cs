using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Wine
{
    public class WineValidator : AbstractValidator<WineCreate>
    {
        private readonly int _importerLength = 25;
        private readonly int _descriptionLength = 100;
        private readonly IWineRepository _wineRepository;

        public WineValidator(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Description is required.")
                .MaximumLength(_descriptionLength)
                .WithMessage($"Description cannot be more than {_descriptionLength} characters");

            RuleFor(x => x.Importer)
                .MaximumLength(_importerLength)
                .WithMessage($"Importer cannot be more than {_importerLength} characters");

            RuleFor(x => x.RegionId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Region is required.");

            RuleFor(x => x.Abv)
                .NotEmpty()
                .NotNull()
                .WithMessage("ABV is required.");

            RuleFor(x => x.WineTypeId) 
                .NotEmpty()
                .NotNull()
                .WithMessage("Wine Type is required.");

            RuleFor(x => x)
                .MustAsync(async (wine, context, cancellation) =>
                {
                    return await Exists(wine.Description).ConfigureAwait(false);
                })
                .WithMessage($"Wine with name already exists");
        }

        private async Task<bool> Exists(string description)
        {
            var wine = await _wineRepository.GetByDescription(description).ConfigureAwait(false);
            return wine == null;
        }
    }
}
