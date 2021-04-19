using Domain;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.Get
{
    public class WhenTheCountryIsFound : WhenTestingTheMethod
    {
        private readonly int _countryId = 1;

        protected override void SetupScenario()
        {
            CountryId = _countryId;

            var domainCountry = new Country();

            CountryService.Get(CountryId).Returns(domainCountry);

            CountryMapper.Map<DataContract.Country>(domainCountry).Returns(new DataContract.Country());
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
        public void ItShouldReturnAnOkObjectsResult()
        {
            Assert.That(Result, Is.InstanceOf<OkObjectResult>());
        }
    }
}
