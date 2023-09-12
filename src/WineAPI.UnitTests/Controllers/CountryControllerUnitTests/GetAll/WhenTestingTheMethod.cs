using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.GetAll
{
    [TestFixture]
    public abstract class WhenTestingTheMethod : WhenTestingTheClass
    {
        public PagingInformation PagingInfo { get; set; }

        protected Exception ThrownException { get; set; }

        protected IActionResult Result { get; set; }

        protected override async Task Run()
        {
            try
            {
                Result = await ItemUnderTest.GetAll(PagingInfo).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                ThrownException = e;
            }
        }
    }
}
