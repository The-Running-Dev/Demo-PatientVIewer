using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

using PatientViewer.Web.API;

namespace PatientViewer.Tests.Controllers
{
    /// <summary>
    /// Tests for the patient API controller
    /// </summary>
    [TestFixture]
    public class PatientControllerTests: TestsBase
    {
        private PatientController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new PatientController(PatientServiceMock);
        }

        [Test]
        public async Task Should_Get_All_Patients()
        {
            var patients = await _controller.GetAllAsync();

            Assert.NotNull(patients);
            Assert.True(patients.Any());
        }

        [Test]
        public async Task Should_Get_A_Single_Patient()
        {
            var patient = await _controller.GetByIdAsync(1);

            Assert.NotNull(patient);
            Assert.True(patient.Name.StartsWith("Ben"));
        }
    }
}