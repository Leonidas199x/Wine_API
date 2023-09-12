using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.Delete
{
    [TestFixture]
    public abstract class WhenTestingTheMethod : WhenTestingTheClass
    {
        public int CountryId { get; set; }

        protected Exception ThrownException { get; set; }

        protected IActionResult Result { get; set; }

        protected override async Task Run()
        {
            try
            {
                Result = await ItemUnderTest.Delete(CountryId).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                ThrownException = e;
            }
        }
    }
}
