using System.Collections.Generic;

using PatientViewer.Data.Models;

namespace PatientViewer.Service.Interfaces
{
    /// <summary>
    /// The blueprint for the patient repository
    /// </summary>
    public interface IPatientRepository
    {
        /// <summary>
        /// Get all the patients
        /// </summary>
        /// <returns></returns>
        IEnumerable<Patient> GetAll();

        /// <summary>
        /// Get the patient by the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Patient GetById(int id);
    }
}
