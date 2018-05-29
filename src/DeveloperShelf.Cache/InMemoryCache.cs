using System;
using Microsoft.Extensions.Caching.Memory;

namespace DeveloperShelf.Cache
{
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryCache : ICacheService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMemoryCache memoryCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoryCache"></param>
        public InMemoryCache(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public object GetOrSet(string cacheKey, Func<object> getItemCallback, int timeoutInSeconds = 1800)
        {
            var result = this.GetOrSet(cacheKey, getItemCallback, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(timeoutInSeconds) });
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="expirationTimeRelativeToNow"></param>
        /// <returns></returns>
        public object GetOrSet(string cacheKey, Func<object> getItemCallback, TimeSpan expirationTimeRelativeToNow)
        {
            var result = this.GetOrSet(cacheKey, getItemCallback, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = expirationTimeRelativeToNow });
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public object GetOrSet(string cacheKey, Func<object> getItemCallback, MemoryCacheEntryOptions options)
        {
            if (this.memoryCache.TryGetValue(cacheKey, out var model))
            {
                return model;
            }

            var item = getItemCallback();

            this.memoryCache.Set(cacheKey, item, options);
            return item;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, int timeoutInSeconds = 1800) where T : class
        {
            var result = this.GetOrSet(cacheKey, getItemCallback, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(timeoutInSeconds) });
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="expirationTimeRelativeToNow"></param>
        /// <returns></returns>
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, TimeSpan expirationTimeRelativeToNow) where T : class
        {
            var result = this.GetOrSet(cacheKey, getItemCallback, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = expirationTimeRelativeToNow });
            return result;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets an item in the cache based, with a supplied cache options.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, MemoryCacheEntryOptions options) where T : class
        {
            if (this.memoryCache.TryGetValue(cacheKey, out var model))
            {
                return (T)model;
            }

            var item = getItemCallback();

            this.memoryCache.Set(cacheKey, item, options);
            return item;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="cacheKey"></param>
        public void Remove(string cacheKey)
        {
            if (this.memoryCache.TryGetValue(cacheKey, out var model))
            {
                this.memoryCache.Remove(model);
            }
        }
    }
}
