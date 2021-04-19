using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.Get
{
    public class WhenTheCountryIsNotFound : WhenTestingTheMethod
    {
        private readonly int _countryId = 1;

        protected override void SetupScenario()
        {
            CountryId = _countryId;

            CountryService.Get(CountryId).ReturnsNull();
        }

        [Test]
        public void ItShouldNotThrowAnException()
        {
            Assert.That(ThrownException, Is.Null);
        }

        [Test]
        public void ItShouldUseThePassedInIdToGetTheCountry()
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
