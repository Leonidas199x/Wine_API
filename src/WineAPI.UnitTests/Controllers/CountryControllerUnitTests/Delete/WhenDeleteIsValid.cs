using Domain;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.Delete
{
    public class WhenDeleteIsValid : WhenTestingTheMethod
    {
        private readonly int _countryId = 1;

        protected override void SetupScenario()
        {
            CountryId = _countryId;

            var validationResult = new ValidationResult();

            CountryService.Get(_countryId).Returns(new Country());
            CountryService.Delete(_countryId).Returns(validationResult);
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
        public void ItShouldReturnANoContentResult()
        {
            Assert.That(Result, Is.InstanceOf<NoContentResult>());
        }
    }
}
