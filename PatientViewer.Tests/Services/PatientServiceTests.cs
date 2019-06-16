using System.Linq;

using NUnit.Framework;
using PatientViewer.Data.Extensions;

namespace PatientViewer.Tests.Services
{
    /// <summary>
    /// Tests for the PatientService class
    /// </summary>
    [TestFixture]
    public class PatientServiceTests: TestsBase
    {
        [Test]
        public void Should_Get_All_Patients()
        {
            var results = PatientService.GetAllAsync();

            Assert.True(results.Result.Any());
        }

        [Test]
        public void Should_Get_Exactly_3_Patients()
        {
            var results = PatientService.GetAllAsync();

            Assert.True(results.Result.Count() == 3);
        }

        [Test]
        public void Should_Contain_Ben_As_Patient()
        {
            var results = PatientService.GetAllAsync();

            Assert.True(results.Result.Any(x => x.Name.IsEqualTo("Ben Richards")));
        }

        [Test]
        public void Should_Get_Ben_By_Id()
        {
            var results = PatientService.GetByIdAsync(1);

            Assert.True(results.Result.Name.IsEqualTo("Ben Richards"));
        }
    }
}