using System;
using Microsoft.Extensions.Caching.Memory;

namespace DeveloperShelf.Cache
{
    public interface ICacheService
    {
        /// <summary>
        /// Gets or sets the value of the item in the cache based on a key, default timeout is set to 30 minutes
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        object GetOrSet(string cacheKey, Func<object> getItemCallback, int timeoutInSeconds);

        /// <summary>
        /// Gets or sets an item with a specified timeout
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="expirationTimeRelativeToNow"></param>
        /// <returns></returns>
        object GetOrSet(string cacheKey, Func<object> getItemCallback, TimeSpan expirationTimeRelativeToNow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        object GetOrSet(string cacheKey, Func<object> getItemCallback, MemoryCacheEntryOptions options);

        /// <summary>
        /// Gets or sets the value of the item in the cache based on a key, default timeout is set to 30 minutes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, int timeoutInSeconds) where T : class;

        /// <summary>
        /// Gets or sets an item with a specified timeout
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="expirationTimeRelativeToNow"></param>
        /// <returns></returns>
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, TimeSpan expirationTimeRelativeToNow) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, MemoryCacheEntryOptions options) where T : class;

        /// <summary>
        /// Removes an item from the cache
        /// </summary>
        /// <param name="cacheKey"></param>
        void Remove(string cacheKey);
    }
}