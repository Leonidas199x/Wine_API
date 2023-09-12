using Domain;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.Delete
{
    public class WhenTheDeleteIsInvalid : WhenTestingTheMethod
    {
        private readonly int _countryId = 1;

        protected override void SetupScenario()
        {
            CountryId = _countryId;

            var validationResult = new ValidationResult();
            var validationFailure = new ValidationFailure("a", "b");
            validationResult.Errors.Add(validationFailure);

            CountryService.Get(_countryId).Returns(new Country());
            CountryService.Delete(_countryId).Returns(validationResult);
        }

        [Test]
        public void ItShouldNotThrowAnException()
        {
            Assert.That(ThrownException, Is.Null);
        }

        [Test]
        public void ItShouldCallTheCountryServiceGetWithTheExpectedId()
        {
            CountryService.Received(1).Get(_countryId);
        }

        [Test]
        public void ItShouldCallTheCountryServiceDeleteWithTheExpectedId()
        {
            CountryService.Received(1).Delete(_countryId);
        }

        [Test]
        public void ItShouldReturnABadRequestObjectResult()
        {
            Assert.That(Result, Is.InstanceOf<BadRequestObjectResult>());
        }
    }
}
