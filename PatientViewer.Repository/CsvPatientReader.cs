using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using CsvHelper;
using PatientViewer.Data.Models;
using PatientViewer.Service.Interfaces;

namespace PatientViewer.Repository
{
    /// <summary>
    /// Reads the patients from a CSV file
    /// </summary>
    public class CsvPatientReader: IPatientReader
    {
        /// <summary>
        /// Get all the patients from a CSV file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> Get()
        {
            List<Patient> patients;

            using (var reader = new StreamReader(_dataFile))
            {
                using (var csv = new CsvReader(reader))
                {
                    // Register the mapper between the CSV and the Patient model
                    csv.Configuration.RegisterClassMap<PatientCsvMap>();

                    // Read all the records in the CSV and convert them to Patient
                    patients = csv.GetRecords<Patient>().ToList();
                }
            }

            return patients;
        }

        private readonly string _dataFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Patients.csv");
    }
}