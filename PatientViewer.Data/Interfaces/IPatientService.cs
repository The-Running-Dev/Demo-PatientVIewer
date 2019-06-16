using System.Threading.Tasks;
using System.Collections.Generic;

using PatientViewer.Data.Models;

namespace PatientViewer.Service.Interfaces
{
    /// <summary>
    /// The blueprint for the patient service
    /// </summary>
    public interface IPatientService
    {
        /// <summary>
        /// Get all the patients
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Patient>> GetAllAsync();

        /// <summary>
        /// Get the patient by the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Patient> GetByIdAsync(int id);
    }
}
