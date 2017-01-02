using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DeveloperShelf.Utilities.Configuration;

namespace DeveloperShelf.Utilities.Web
{
    public class WebProvider : IWebProvider
    {
        /// <summary>
        /// Config service used to configure the provider
        /// </summary>
        private readonly IConfigService configService;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configService"></param>
        public WebProvider(IConfigService configService)
        {
            this.configService = configService;
        }

        /// <summary>
        /// Make a request to delete something from the backend api
        /// </summary>
        /// <param name="requestContent"></param>
        /// <param name="accessToken"></param>
        /// <param name="path"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<ProviderResponse> DeleteAsync(string path,
            HttpContent requestContent = null,
            string accessToken = null,
            string contentType = ContentTypes.Json)
        {
            return await this.MakeRequestAsync(path, HttpMethod.Delete, accessToken, contentType, requestContent);
        }

        /// <summary>
        /// Make a request to the backend gateway for the particular endpoint you are requesting
        /// </summary>
        /// <param name="requestContent"></param>
        /// <param name="accessToken"></param>
        /// <param name="path"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<ProviderResponse> GetAsync(
            string path,
            HttpContent requestContent,
            string accessToken = null,
            string contentType = ContentTypes.Json)
        {
            return await this.MakeRequestAsync(path, HttpMethod.Get, accessToken, contentType, requestContent);
        }

        /// <summary>
        /// Make a request to the backend gateway for the particular endpoint you are requesting
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="path"></param>
        /// <param name="requestContent"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<ProviderResponse> PostAsync(
            string path,
            HttpContent requestContent,
            string accessToken = null,
            string contentType = ContentTypes.Json)
        {
            return await this.MakeRequestAsync(path, HttpMethod.Post, accessToken, contentType, requestContent);
        }

        /// <summary>
        /// Make a request to the backend gateway for the particular endpoint you are requesting
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="path"></param>
        /// <param name="requestContent"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<ProviderResponse> PutAsync(
            string path,
            HttpContent requestContent,
            string accessToken = null,
            string contentType = ContentTypes.Json)
        {
            return await this.MakeRequestAsync(path, HttpMethod.Put, accessToken, contentType, requestContent);
        }

        /// <summary>
        /// Makes a http request
        /// </summary>
        /// <param name="path"></param>
        /// <param name="requestContent"></param>
        /// <param name="httpMethod"></param>
        /// <param name="accessToken"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        private async Task<ProviderResponse> MakeRequestAsync(
            string path,
            HttpMethod httpMethod,
            string contentType = ContentTypes.Json,
            string accessToken = null,
            HttpContent requestContent = null)
        {
            using (var client = new HttpClient())
            {
                this.ConfigClient(client, accessToken, contentType);

                HttpResponseMessage response;

                switch (httpMethod)
                {
                    case HttpMethod.Get:
                        response = await client.GetAsync(path);
                        break;
                    case HttpMethod.Post:
                        response = await client.PostAsync(path, requestContent);
                        break;
                    case HttpMethod.Put:
                        response = await client.PutAsync(path, requestContent);
                        break;
                    case HttpMethod.Delete:
                        response = await client.DeleteAsync(path);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(httpMethod), httpMethod, null);
                }

                return new ProviderResponse
                {
                    HttpStatusCode = response.StatusCode,
                    Message = await response.Content.ReadAsStringAsync()
                };
            }
        }

        /// <summary>
        /// Configures the HTTP Client with an access token if supplied and 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="client"></param>
        /// <param name="contentType"></param>
        private void ConfigClient(
            HttpClient client,
            string accessToken = null,
            string contentType = ContentTypes.Json)
        {
            var gateway = this.configService.GetKeyAsString(ApplicationSettings.BaseAddress);
            client.BaseAddress = new Uri(gateway);
            client.DefaultRequestHeaders.Accept.Clear();
            if (accessToken != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Headers.Bearer, accessToken);
            }
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
        }
    }
}