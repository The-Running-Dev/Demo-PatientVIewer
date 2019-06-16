using StructureMap;

namespace PatientViewer.Bootstrapper
{
    /// <summary>
    /// Provides single instance access
    /// to the dependency injection container 
    /// </summary>
    public class IocWrapper
    {
        public IContainer Container;

        private IocWrapper() { }

        public IocWrapper(IContainer iocContainer)
        {
            Container = iocContainer;
        }

        /// <summary>
        /// Gets the instance of the dependency resolver
        /// </summary>
        public static IocWrapper Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;

                }

                lock (SyncObject)
                {
                    if (_instance != null)
                    {
                        return _instance;
                    }

                    _instance = new IocWrapper();
                }

                return _instance;
            }
            set
            {
                lock (SyncObject)
                {
                    _instance = value;
                }
            }
        }

        /// <summary>
        /// Gets an instance of the requested type from the
        /// dependency resolver
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Instance.Container.GetInstance<T>();
        }

        private static readonly object SyncObject = new object();

        private static IocWrapper _instance;
    }
}