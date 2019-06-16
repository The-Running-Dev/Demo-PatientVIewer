using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using PatientViewer.Service;
using PatientViewer.Repository;
using PatientViewer.Data.Models;
using PatientViewer.Bootstrapper;
using PatientViewer.Service.Interfaces;

namespace PatientViewer.Tests
{
    [SetUpFixture]
    public class TestsBase
    {
        protected IPatientService PatientService;
        protected Mock<IPatientService> PatientServiceMockObject;
        protected IPatientService PatientServiceMock => PatientServiceMockObject.Object;

        protected IPatientRepository PatientRepository;
        protected Mock<IPatientRepository> PatientRepositoryMockObject;
        protected IPatientRepository PatientRepositoryMock => PatientRepositoryMockObject.Object;

        protected IRepositoryCache RepositoryCache;
        protected Mock<IRepositoryCache> RepositoryCacheMockObject;
        protected IRepositoryCache RepositoryCacheMock => RepositoryCacheMockObject.Object;
        
        protected Mock<IPatientReader> PatientReaderMockObject;

        /// <summary>
        /// One time setup for all test execution
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Setup.Bootstrap(SetupType.Tests);

            PatientServiceMockObject = new Mock<IPatientService>();
            PatientRepositoryMockObject = new Mock<IPatientRepository>();
            RepositoryCacheMockObject = new Mock<IRepositoryCache>();
            PatientReaderMockObject = new Mock<IPatientReader>();

            var patients = new List<Patient>
            {
                new Patient { UniqueIdentifier = 1, DateOfBirth = DateTime.Today.Date, Forename = "Ben", Surname = "Richards", PostCode = "SO12 G56" },
                new Patient { UniqueIdentifier = 2, DateOfBirth = DateTime.Today.Date, Forename = "Sub", Surname = "Zero", PostCode = "SO12 G56" },
                new Patient { UniqueIdentifier = 3, DateOfBirth = DateTime.Today.Date, Forename = "Captain", Surname = "America", PostCode = "SO12 G56" }
            };

            // Mock the patient service methods
            PatientServiceMockObject.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(patients.AsEnumerable()));
            PatientServiceMockObject.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(patients.FirstOrDefault()));

            // Mock the patient repository methods
            PatientRepositoryMockObject.Setup(x => x.GetAll()).Returns(patients);
            PatientRepositoryMockObject.Setup(x => x.GetById(It.IsAny<int>())).Returns(patients.FirstOrDefault());

            // Mock the repository cache methods
            RepositoryCacheMockObject.Setup(x => x.Get(It.IsAny<string>(), It.IsAny<Func<IEnumerable<Patient>>>())).Returns(patients).Verifiable();

            // Mock the patient reader methods
            PatientReaderMockObject.Setup(x => x.Get()).Returns(patients.Take(1));

            PatientService = new PatientService(PatientRepositoryMockObject.Object);
            PatientRepository = new PatientRepository(RepositoryCacheMockObject.Object, PatientReaderMockObject.Object);
            RepositoryCache = new RepositoryCache();
        }
    }
}
