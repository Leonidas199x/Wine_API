using Domain;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace WineAPI.UnitTests.Controllers.CountryControllerUnitTests.GetAll
{
    public class WhenValid : WhenTestingTheMethod
    {
        protected override void SetupScenario()
        {
            var page = 1;
            var pageSize = 10;

            var domainCountries = new PagedList<IEnumerable<Country>>
            {
                Page = page,
                PageSize = pageSize,
                Data = new List<Country>
                {
                    new Country(),
                },
            };

            var outboundCountries = new DataContract.PagedList<IEnumerable<DataContract.Country>>
            {
                Page = page,
                PageSize = pageSize,
                Data = new List<DataContract.Country>
                {
                    new DataContract.Country(),
                }
            };

            CountryService.GetAll(page, pageSize).Returns(domainCountries);

            CountryMapper.Map<DataContract.PagedList<IEnumerable<DataContract.Country>>>(domainCountries).Returns(outboundCountries);
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
