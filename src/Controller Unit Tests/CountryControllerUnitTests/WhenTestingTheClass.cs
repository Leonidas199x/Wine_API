using System.Threading.Tasks;
using WineApi.Controllers;

namespace CountryControllerUnitTests
{
    public abstract class WhenTestingTheClass
    {
        public ICountryService CountryService { get; private set; }

        public IMapper CountryMapper { get; private set; }

        protected CountryController ItemUnderTest { get; private set; }

        protected abstract void ArrangeScenario();

        protected abstract Task Run();
    }
}
