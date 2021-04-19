using AutoMapper;
using Domain.Countries;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using WineAPI.Controllers;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests
{
    [TestFixture]
    public abstract class WhenTestingTheClass
    {
        protected ICountryService CountryService { get; private set; }

        protected IMapper CountryMapper { get; private set; }

        protected CountryController ItemUnderTest { get; private set; }

        protected abstract void SetupScenario();

        protected abstract Task Run();

        [OneTimeSetUp]
        public Task ArrangeScenario()
        {
            CountryService = Substitute.For<ICountryService>();
            CountryMapper = Substitute.For<IMapper>();

            SetupScenario();

            ItemUnderTest = new CountryController(CountryService, CountryMapper);

            return Run();
        }
    }
}
