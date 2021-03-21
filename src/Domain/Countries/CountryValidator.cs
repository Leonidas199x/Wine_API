using FluentValidation;

namespace Domain.Countries
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be provided.");
        }
    }
}
