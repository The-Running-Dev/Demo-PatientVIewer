using System.Collections.Generic;

using PatientViewer.Data.Models;

namespace PatientViewer.Service.Interfaces
{
    /// <summary>
    /// The blueprint for the patient reader
    /// </summary>
    public interface IPatientReader
    {
        /// <summary>
        /// Get all the patients
        /// </summary>
        /// <returns></returns>
        IEnumerable<Patient> Get();
    }
}