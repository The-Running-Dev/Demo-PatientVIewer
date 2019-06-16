using System.Linq;
using System.Collections.Generic;

using PatientViewer.Data.Models;
using PatientViewer.Service.Interfaces;

namespace PatientViewer.Repository
{
    /// <summary>
    /// Encapsulates access to the patient data and provides data caching
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        /// <summary>
        /// Creates a new instance of the PatientRepository
        /// </summary>
        /// <param name="cache">The implementation of IRepositoryCache to be used as a cache mechanism</param>
        /// <param name="patientReader">The implementation of IPatientReader to be used as a read the patients</param>
        public PatientRepository(IRepositoryCache cache, IPatientReader patientReader)
        {
            _cache = cache;
            _patientReader = patientReader;
        }

        /// <summary>
        /// Get all the patients
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetAll()
        {
            return _cache.Get(CacheKey, _patientReader.Get);
        }

        /// <summary>
        /// Get the patient by the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Patient GetById(int id)
        {
            return _cache.Get(CacheKey, _patientReader.Get).ToList().FirstOrDefault(x => x.UniqueIdentifier == id);
        }

        private readonly IRepositoryCache _cache;

        private readonly IPatientReader _patientReader;

        private const string CacheKey = "availablePatients";
    }
}
