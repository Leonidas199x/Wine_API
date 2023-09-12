using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.Delete
{
    public class WhenTheCountryIsNotFound : WhenTestingTheMethod
    {
        private readonly int _countryId = 1;

        protected override void SetupScenario()
        {
            CountryId = _countryId;
            CountryService.Get(_countryId).ReturnsNull();
        }

        [Test]
        public void ItShouldNotThrowAnException()
        {
            Assert.That(ThrownException, Is.Null);
        }

        [Test]
        public void ItShouldCallTheCountryServiceWithTheExpectedId()
        {
            CountryService.Received(1).Get(_countryId);
        }

        [Test]
        public void ItShouldReturnANotFoundResult()
        {
            Assert.That(Result, Is.InstanceOf<NotFoundResult>());
        }
    }
}
