using System;
using System.ComponentModel.DataAnnotations;

namespace PatientViewer.Data.Models
{
    /// <summary>
    /// Represents the Patient data
    /// </summary>
    public class Patient
    {
        public int UniqueIdentifier { get; set; }

        /// <summary>
        /// Runtime property to display the full name
        /// </summary>
        public string Name => $"{Forename} {Surname}";

        public string Forename { get; set; }

        public string Surname { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateOfBirth { get; set; }

        public string PostalCode { get; set; }

        public Patient() { }
    }
}
