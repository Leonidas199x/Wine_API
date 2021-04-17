using FluentValidation;

namespace Domain.Producer
{
    public class ProducerValidator : AbstractValidator<Producer>
    {
        public ProducerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot be more than 50 characters");
        }
    }
}
