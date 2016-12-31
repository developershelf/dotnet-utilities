using System.Net;

namespace DeveloperShelf.Utilities.Web
{
    public class ProviderResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }

        public string Content { get; set; }
    }
}