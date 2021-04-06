using FluentValidation;

namespace Domain.Grapes
{
    public class GrapeColourValidator : AbstractValidator<GrapeColour>
    {
        private readonly int _maxLength = 20;

        public GrapeColourValidator()
        {
            RuleFor(x => x.Colour)
                .NotEmpty()
                .WithMessage("Colour is required")
                .MaximumLength(_maxLength)
                .WithMessage($"Colour cannot be more that {_maxLength} characters");
        }
    }
}
