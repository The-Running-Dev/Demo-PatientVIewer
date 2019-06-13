using System.Collections.Generic;

using PatientViewer.Models;

namespace PatientViewer.Service.Interfaces
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();

        Patient GetById(string id);
    }
}
