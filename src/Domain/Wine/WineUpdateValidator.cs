using FluentValidation;

namespace Domain.Wine
{
    public class WineUpdateValidator : AbstractValidator<WineUpdate>
    {
        private readonly int _importerLength = 25;
        private readonly int _descriptionLength = 100;

        public WineUpdateValidator()
        {

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
        }
    }
}
