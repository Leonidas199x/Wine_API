using Domain.Countries;
using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.QualityControl
{
    public class QualityControlValidator : AbstractValidator<QualityControl>
    {
        private readonly IQualityControlRepository _qualityControlRepository;
        private readonly ICountryRepository _countryRepository;

        public QualityControlValidator(
            IQualityControlRepository qualityControlRepository, 
            ICountryRepository countryRepository)
        {
            _qualityControlRepository = qualityControlRepository;
            _countryRepository = countryRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot be more that 50 characters");

            RuleFor(x => x.Country.Id)
                .MustAsync(async (qualityControl, context, cancellation) =>
                {
                    return await CountryExists(qualityControl.Country.Id)
                    .ConfigureAwait(false);
                })
                .WithMessage("Country does not exists");

            RuleFor(x => x)
                .MustAsync(async (qualityControl, context, cancellation) =>
                {
                    return await Exists(qualityControl.Name, qualityControl.Country.Id)
                    .ConfigureAwait(false);
                })
                .WithMessage("Quality Control with that name and country already exists"); ;
        }

        private async Task<bool> Exists(string name, int countryId)
        {
            var qualityControl = await _qualityControlRepository.GetByNameAndCountry(name, countryId).ConfigureAwait(false);
            return !qualityControl.Any(x => x.Name == name && x.Country.Id == countryId);
        }

        private async Task<bool> CountryExists(int countryId)
        {
            var country = await _countryRepository.Get(countryId).ConfigureAwait(false);
            return country != null;
        }
    }
}
