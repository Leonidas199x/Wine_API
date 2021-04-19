using Domain;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using System.Collections.Generic;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.GetAll
{
    public class WhenValid : WhenTestingTheMethod
    {
        protected override void SetupScenario()
        {
            var domainCountries = new List<Country>
            {
                new Country(),
            };

            var outboundCountries = new List<DataContract.Country>
            {
                new DataContract.Country(),
            };

            CountryService.GetAll().Returns(domainCountries);

            CountryMapper.Map<IEnumerable<DataContract.Country>>(domainCountries).Returns(outboundCountries);
        }

        [Test]
        public void ItShouldNotThrowAnException()
        {
            Assert.That(ThrownException, Is.Null);
        }

        [Test]
        public void ItShouldReturnAnOkObjectResult()
        {
            Assert.That(Result, Is.InstanceOf<OkObjectResult>());
        }
    }
}
