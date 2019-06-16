using System;

using StructureMap;
using Microsoft.Extensions.DependencyInjection;

using PatientViewer.Bootstrapper.Registries;

namespace PatientViewer.Bootstrapper
{
    /// <summary>
    /// Sets up the dependency resolution for the project
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Sets the dependency resolution for the web project
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceProvider Web(IServiceCollection services)
        {
            // Register all the dependencies for the web application
            Bootstrap(SetupType.Web);

            // Populate all the services for the MVC dependency resolution
            IocWrapper.Instance.Container.Populate(services);

            return IocWrapper.Instance.Container.GetInstance<IServiceProvider>();
        }

        /// <summary>
        /// Provides means to registry different service implementations
        /// based on the setup type
        /// </summary>
        /// <param name="type"></param>
        public static void Bootstrap(SetupType type)
        {
            var container = new Container();

            switch (type)
            {
                case SetupType.Web:
                    ConfigureRegistries(container);

                    break;
                case SetupType.Api:
                    ConfigureRegistries(container);

                    break;
                case SetupType.Tests:
                    ConfigureTestRegistries(container);

                    break;
            }


            IocWrapper.Instance = new IocWrapper(container);
        }

        /// <summary>
        /// Configures the container with the all registries
        /// </summary>
        /// <param name="container"></param>
        private static void ConfigureRegistries(IContainer container)
        {
            container.Configure(cfg =>
            {
                cfg.AddRegistry<DataRegistry>();
            });
        }

        /// <summary>
        /// Configures the container with the registries needed for testing
        /// </summary>
        /// <param name="container"></param>
        private static void ConfigureTestRegistries(IContainer container)
        {
            container.Configure(cfg =>
            {
                cfg.AddRegistry<DataRegistry>();
            });
        }
    }
}