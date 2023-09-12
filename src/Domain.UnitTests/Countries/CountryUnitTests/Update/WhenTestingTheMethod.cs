using FluentValidation.Results;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Domain.UnitTests.Countries.CountryUnitTests.Update
{
    [TestFixture]
    public abstract class WhenTestingTheMethod : WhenTestingTheClass
    {
        protected Country Country { get; set; }

        protected Exception ThrownException { get; set; }

        protected ValidationResult Result { get; set; }

        protected override async Task Run()
        {
            try
            {
                Result = await ItemUnderTest.Update(Country).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                ThrownException = e;
            }
        }
    }
}
