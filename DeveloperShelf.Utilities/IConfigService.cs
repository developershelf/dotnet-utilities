namespace DeveloperShelf.Utilities
{
    public interface IConfigService
    {
        /// <summary>
        /// return key value as an Int
        /// </summary>
        /// <param name="key">configuration settings key name</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        int GetKeyAsInt(string key, int defaultValue = 0);

        /// <summary>
        /// return key value as a string
        /// </summary>
        /// <param name="key">configuration settings key name</param>
        /// <returns>string value</returns>
        string GetKeyAsString(string key);

        /// <summary>
        /// return key value as boolean
        /// </summary>
        /// <param name="key">configuration settings key name</param>
        /// <param name="defaultValue">Default value to return if the key is not found (defaulted to false)</param>
        /// <returns>value under key as bool or default</returns>
        bool GetKeyAsBool(string key, bool defaultValue = false);
    }
}