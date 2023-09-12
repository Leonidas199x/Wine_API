using FluentValidation.Results;
using NSubstitute;
using NUnit.Framework;

namespace Domain.UnitTests.Countries.CountryUnitTests.Insert
{
    public class WhenInvalid : WhenTestingTheMethod
    {
        private ValidationResult _validationResult;

        protected override void SetupScenario()
        {
            Country = new Country();

            var validationFailure = new ValidationFailure("a", "b");
            _validationResult = new ValidationResult(new[] { validationFailure });

            CountryValidator.Validate(Country).Returns(_validationResult);
            CountryRepository.Insert(Country).Returns(_validationResult);
        }

        [Test]
        public void ItShouldNotThrowAnException()
        {
            Assert.That(ThrownException, Is.Null);
        }

        [Test]
        public void ItShouldReturnAnInvalidResult()
        {
            Assert.That(Result.IsValid, Is.EqualTo(false));
        }
    }
}
