using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

using PatientViewer.Data.Models;
using PatientViewer.Web.Controllers;

namespace PatientViewer.Tests.Controllers
{
    /// <summary>
    /// Tests for the home controller
    /// </summary>
    [TestFixture]
    public class HomeControllerTests: TestsBase
    {
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new HomeController(PatientServiceMock);
        }

        [Test]
        public async Task Should_Get_All_Patients()
        {
            var actionResult = await _controller.Index();
            var result = actionResult as ViewResult;
            var patients = result.Model as IEnumerable<Patient>;

            Assert.NotNull(result);
            Assert.True(patients.Any());
        }
    }
}