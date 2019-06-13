using System.Collections.Generic;

using PatientViewer.Models;
using PatientViewer.Service.Interfaces;

namespace PatientViewer.Service.Services
{
    public class PatientService : IPatientService
    {
        public PatientService()
        {
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Patient GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
