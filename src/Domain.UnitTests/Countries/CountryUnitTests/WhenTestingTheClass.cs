using Domain.Countries;
using FluentValidation;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Domain.UnitTests.Countries.CountryUnitTests
{
    [TestFixture]
    public abstract class WhenTestingTheClass
    {
        protected ICountryRepository CountryRepository { get; private set; }

        protected IValidator<Country> CountryValidator { get; private set; }

        protected CountryService ItemUnderTest { get; private set; }

        protected abstract void SetupScenario();

        protected abstract Task Run();

        [OneTimeSetUp]
        public Task ArrangeScenario()
        {
            CountryRepository = Substitute.For<ICountryRepository>();

            CountryValidator = Substitute.For<IValidator<Country>>();

            SetupScenario();

            ItemUnderTest = new CountryService(CountryRepository, CountryValidator);

            return Run();
        }
    }
}
