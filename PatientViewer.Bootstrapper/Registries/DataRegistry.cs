using PatientViewer.Repository;
using PatientViewer.Service.Interfaces;

using StructureMap;

namespace PatientViewer.Bootstrapper.Registries
{
    /// <summary>
    /// Registers all the services with the dependency resolver
    /// </summary>
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            // Register all services by convention
            Scan(scan =>
            {
                // Scan all the assemblies
                scan.AssembliesFromApplicationBaseDirectory();

                // With the default convention
                // being ClassName implements IClassName
                scan.WithDefaultConventions();
            });

            // Explicitly register the CSV reader as IPatientReader
            // because it doesn't match the default convention
            For<IPatientReader>().Add<CsvPatientReader>();
        }
    }
}