using FluentValidation;

namespace Domain.VineyardEstate
{
    public class VineyardEstateValidator : AbstractValidator<VineyardEstate>
    {
        public VineyardEstateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot be more that 50 characters");
        }
    }
}
