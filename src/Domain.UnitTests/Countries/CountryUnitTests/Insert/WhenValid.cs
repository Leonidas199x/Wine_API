using FluentValidation.Results;
using NSubstitute;
using NUnit.Framework;

namespace Domain.UnitTests.Countries.CountryUnitTests.Insert
{
    public class WhenValid : WhenTestingTheMethod
    {
        private ValidationResult _validationResult;

        protected override void SetupScenario()
        {
            Country = new Country();
            _validationResult = new ValidationResult();

            CountryValidator.Validate(Country).Returns(_validationResult);
            CountryRepository.Insert(Country).Returns(_validationResult);
        }

        [Test]
        public void ItShouldNotThrowAnException()
        {
            Assert.That(ThrownException, Is.Null);
        }

        [Test]
        public void ItShouldReturnAValidValdationResult()
        {
            Assert.That(Result.IsValid, Is.EqualTo(true));
        }
    }
}
