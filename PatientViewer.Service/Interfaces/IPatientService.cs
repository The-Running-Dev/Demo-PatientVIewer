using System.Collections.Generic;

using PatientViewer.Models;

namespace PatientViewer.Service.Interfaces
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();

        Patient GetById(string id);
    }
}
