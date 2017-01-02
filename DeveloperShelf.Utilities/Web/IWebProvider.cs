using System.Net.Http;
using System.Threading.Tasks;

namespace DeveloperShelf.Utilities.Web
{
    public interface IWebProvider
    {
        /// <summary>
        /// Sends a HTTP Put request to the supplied path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="requestContent"></param>
        /// <param name="accessToken"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        Task<ProviderResponse> GetAsync(string path,
            HttpContent requestContent,
            string accessToken = null,
            string contentType = ContentTypes.Json);

        /// <summary>
        /// Sends a HTTP Delete request to the supplied path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="requestContent"></param>
        /// <param name="accessToken"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        Task<ProviderResponse> DeleteAsync(string path,
            HttpContent requestContent = null,
            string accessToken = null,
            string contentType = ContentTypes.Json);

        /// <summary>
        /// Sends a HTTP Post request to the supplied path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="requestContent"></param>
        /// <param name="accessToken"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        Task<ProviderResponse> PostAsync(string path,
            HttpContent requestContent,
            string accessToken = null,
            string contentType = ContentTypes.Json);

        /// <summary>
        /// Sends a HTTP Put request to the supplied path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="requestContent"></param>
        /// <param name="accessToken"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        Task<ProviderResponse> PutAsync(string path,
            HttpContent requestContent,
            string accessToken = null,
            string contentType = ContentTypes.Json);
    }
}