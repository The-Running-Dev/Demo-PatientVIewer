using System;

namespace PatientViewer.Service.Interfaces
{
    /// <summary>
    /// The blueprint for the repository cache
    /// </summary>
    public interface IRepositoryCache
    {
        /// <summary>
        /// Stores data in the cache
        /// </summary>
        /// <param name="key">The cache key</param>
        /// <param name="value">The value to stored</param>
        void Add<T>(string key, T value);

        /// <summary>
        /// Removes data from the cache
        /// </summary>
        /// <param name="key">The cache key</param>
        void Remove(string key);

        /// <summary>
        /// Gets data from the cache.
        /// If no data, uses the supplied function to populate the cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The cache key</param>
        /// <param name="getData">The function to get the data</param>
        /// <returns>The value from the cache</returns>
        T Get<T>(string key, Func<T> getData) where T : class;
    }
}