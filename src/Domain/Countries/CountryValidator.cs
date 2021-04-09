using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Countries
{
    public class CountryValidator : AbstractValidator<Country>
    {
        private readonly ICountryRepository _countryRepository;

        public CountryValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot be more that 50 characters");


            RuleFor(x => x)
                .MustAsync(async (country, context, cancellation) =>
                {
                    return await CountryExists(country.Name).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Country already exists");
        }

        private async Task<bool> CountryExists(string name)
        {
            var country = await _countryRepository.GetByName(name).ConfigureAwait(false);
            return !country.Any(x => x.Name == name);
        }
    }
}
