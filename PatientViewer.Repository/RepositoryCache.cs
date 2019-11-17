using System;

using Microsoft.Extensions.Caching.Memory;

using PatientViewer.Service.Interfaces;

namespace PatientViewer.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class RepositoryCache: IRepositoryCache
    {
        /// <summary>
        /// Creates a new instance of the RepositoryCache
        /// </summary>
        public RepositoryCache()
        {
            _policy = new MemoryCache(new MemoryCacheOptions());
            //_policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(60) };
        }

        /// <summary>
        /// Stores data in the cache
        /// </summary>
        /// <param name="key">The cache key</param>
        /// <param name="value">The value to stored</param>
        public void Add<T>(string key, T value)
        {
            _cache.Add(key, value, _policy);
        }

        /// <summary>
        /// Removes data from the cache
        /// </summary>
        /// <param name="key">The cache key</param>
        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Gets data from the cache.
        /// If no data, uses the supplied function to populate the cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The cache key</param>
        /// <param name="getData">The function to get the data</param>
        /// <returns>The value from the cache</returns>
        public T Get<T>(string key, Func<T> getData) where T : class
        {
            // If the cache key exists
            if(_cache.Contains(key))
            {
                // Get the value from the cache
                return _cache.Get(key) as T;
            }

            // Get the data with the supplied function
            var value = getData();

            // Store the data in the cache
            Add(key, value);

            return value;
        }

        private readonly ObjectCache _cache = MemoryCache.Default;

        private readonly CacheItemPolicy _policy;
    }
}