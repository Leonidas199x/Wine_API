using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.GetAll
{
    [TestFixture]
    public abstract class WhenTestingTheMethod : WhenTestingTheClass
    {
        protected Exception ThrownException { get; set; }

        protected IActionResult Result { get; set; }

        protected override async Task Run()
        {
            try
            {
                Result = await ItemUnderTest.GetAll().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                ThrownException = e;
            }
        }
    }
}
