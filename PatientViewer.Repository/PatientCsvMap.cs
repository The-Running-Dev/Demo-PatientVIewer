using CsvHelper.Configuration;

using PatientViewer.Data.Models;

namespace PatientViewer.Repository
{
    /// <summary>
    /// Maps the fields in the CSV to the Patient model
    /// </summary>
    public class PatientCsvMap : ClassMap<Patient>
    {
        public PatientCsvMap()
        {
            Map(m => m.UniqueIdentifier).Name("Unique Identifier");
            Map(m => m.DateOfBirth).Name("Date of Birth");
            Map(m => m.Forename).Name("Forename");
            Map(m => m.Surname).Name("Surname");
            Map(m => m.PostalCode).Name("Postal Code");
        }
    }
}