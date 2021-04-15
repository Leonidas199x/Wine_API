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
                    return await CountryWithNameExists(country.Name).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Country with name already exists");

            RuleFor(x => x)
                .MustAsync(async (country, context, cancellation) =>
                {
                    return await CountryWithIsoExists(country.IsoCode).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Country with ISO code already exists");
        }

        private async Task<bool> CountryWithNameExists(string name)
        {
            var country = await _countryRepository.GetByName(name).ConfigureAwait(false);
            return !country.Any(x => x.Name == name);
        }

        private async Task<bool> CountryWithIsoExists(string isoCode)
        {
            var country = await _countryRepository.GetByIsoCode(isoCode).ConfigureAwait(false);
            return !country.Any(x => x.IsoCode == isoCode);
        }
    }
}
