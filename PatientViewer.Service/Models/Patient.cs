using System;

namespace PatientViewer.Models
{
    /// <summary>
    /// Represents the Patient data coming from the API
    /// </summary>
    public class Patient
    {
        public string UniqueIdentifier { get; set; }

        public string Forenames { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PostCode { get; set; }

        public Patient() { }
    }
}
