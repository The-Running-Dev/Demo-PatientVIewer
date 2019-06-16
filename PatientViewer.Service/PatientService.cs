using System.Threading.Tasks;
using System.Collections.Generic;

using PatientViewer.Data.Models;
using PatientViewer.Service.Interfaces;

namespace PatientViewer.Service
{
    /// <summary>
    /// Encapsulates patent related business logic
    /// </summary>
    public class PatientService : IPatientService
    {
        /// <summary>
        /// C
        /// </summary>
        /// <param name="repository"></param>
        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all the patients
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Patient>> GetAllAsync()
        {
            // Get list of patents from the repository
            var patients = _repository.GetAll();

            // Return the patient list as async result
            return Task.FromResult(patients);
        }

        /// <summary>
        /// Get the patient by the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Patient> GetByIdAsync(int id)
        {
            // Get a single patient from the repository
            var patient = _repository.GetById(id);

            // Return a single patient as async result
            //return Task.FromResult(_patients.FirstOrDefault(x => x.UniqueIdentifier == id));
            return Task.FromResult(patient);
        }

        private readonly IPatientRepository _repository;

    }
}