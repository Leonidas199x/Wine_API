using FluentValidation;

namespace Domain.WineRegion
{
    public class WineRegionValidator : AbstractValidator<WineRegion>
    {
        public WineRegionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.Region.Id)
                .NotEmpty()
                .WithMessage("RegionId is required");
        }
    }
}
