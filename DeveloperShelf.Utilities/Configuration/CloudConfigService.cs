using System;
using Microsoft.Azure;

namespace DeveloperShelf.Utilities.Configuration
{
    public class CloudConfigService : IConfigService
    {
        /// <summary>
        /// provide integer value for the given key
        /// </summary>
        /// <param name="key">configuration settings key</param>
        /// <param name="defValue">default value</param>
        /// <returns>int value</returns>
        public int GetKeyAsInt(string key, int defValue = 0)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("invalid configuration key", nameof(key));
            }
            var val = CloudConfigurationManager.GetSetting(key);
            return string.IsNullOrWhiteSpace(val)
                ? defValue
                : Convert.ToInt32(val);
        }

        /// <summary>
        /// get config item under key as string
        /// </summary>
        /// <param name="key">configuration key</param>
        /// <returns>string value</returns>
        public string GetKeyAsString(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("invalid configuration key", nameof(key));
            }

            return CloudConfigurationManager.GetSetting(key);
        }

        /// <summary>
        /// return key as boolean
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="defValue">default value to return if the key is not found (defaulted to false)</param>
        /// <returns>value under key as bool or default</returns>
        public bool GetKeyAsBool(string key, bool defValue = false)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("invalid configuration key", nameof(key));
            }

            var val = CloudConfigurationManager.GetSetting(key);
            return string.IsNullOrWhiteSpace(val)
                ? defValue
                : Convert.ToBoolean(val);
        }
    }
}