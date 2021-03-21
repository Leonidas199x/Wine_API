﻿using FluentValidation;

namespace Domain.Countries
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be provided.");

            RuleFor(x => x.Name)
                .MaximumLength(50)
                .WithMessage("Name cannot be more that 50 characters");
        }
    }
}
