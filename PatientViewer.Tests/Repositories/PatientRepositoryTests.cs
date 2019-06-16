using System.Linq;

using NUnit.Framework;

using PatientViewer.Data.Extensions;

namespace PatientViewer.Tests.Repositories
{
    /// <summary>
    /// Tests for the PatientRepository class
    /// </summary>
    [TestFixture]
    public class PatientRepositoryTests: TestsBase
    {
        [Test]
        public void Should_Get_All_Patients()
        {
            var results = PatientRepository.GetAll();

            RepositoryCacheMockObject.Verify();
            PatientReaderMockObject.Verify();

            Assert.True(results.Any());
        }

        [Test]
        public void Should_Get_Exactly_3_Patients()
        {
            var results = PatientRepository.GetAll();

            Assert.True(results.Count() == 3);
        }

        [Test]
        public void Should_Contain_Ben_As_Patient()
        {
            var results = PatientRepository.GetAll();

            RepositoryCacheMockObject.Verify();

            Assert.True(results.FirstOrDefault(x => x.Name.IsEqualTo("Ben Richards")) != null);
        }

        [Test]
        public void Should_Get_Ben_By_Id()
        {
            var results = PatientRepository.GetById(1);

            Assert.True(results.Name.IsEqualTo("Ben Richards"));
        }
    }
}