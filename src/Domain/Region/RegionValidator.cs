using Domain.Countries;
using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Region
{
    public class RegionValidator : AbstractValidator<Region>
    {
        private readonly IRegionRepository _regionRepository;
        private readonly ICountryRepository _countryRepository;

        public RegionValidator(IRegionRepository regionRepository, ICountryRepository countryRepository)
        {
            _regionRepository = regionRepository;
            _countryRepository = countryRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot be more that 50 characters");

            RuleFor(x => x.Country.Id)
                .MustAsync(async (region, context, cancellation) =>
                {
                    return await CountryExists(region.Country.Id).ConfigureAwait(false);
                })
                .WithMessage("Country does not exists");

            RuleFor(x => x.IsoCode)
                .NotEmpty()
                .WithMessage("ISO Code is required");

            RuleFor(x => x)
                .MustAsync(async (region, context, cancellation) =>
                {
                    return await RegionWithNameExists(region.Name, region.Country.Id).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Region with name already exists");

            RuleFor(x => x)
                .MustAsync(async (region, context, cancellation) =>
                {
                    return await RegionWithIsoExists(region.IsoCode).ConfigureAwait(false);
                })
                .When(x => x.IsNew)
                .WithMessage($"Region with ISO Code already exists");
        }

        private async Task<bool> RegionWithNameExists(string name, int countryId)
        {
            var region = await _regionRepository.GetByNameAndCountryId(name, countryId).ConfigureAwait(false);
            return !region.Any(x => x.Name == name && x.Country.Id == countryId);
        }

        private async Task<bool> RegionWithIsoExists(string isoCode)
        {
            var region = await _regionRepository.GetByIsoCode(isoCode).ConfigureAwait(false);
            return !region.Any(x => x.IsoCode == isoCode);
        }

        private async Task<bool> CountryExists(int countryId)
        {
            var country = await _countryRepository.Get(countryId).ConfigureAwait(false);
            return country != null;
        }
    }
}
