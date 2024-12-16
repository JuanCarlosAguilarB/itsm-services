using System.Text.Json;
using System.Text;

namespace ItsmServices.Src.Tickets.Infrastructure
{
    public class HttpClientServices
    {

        private readonly HttpClient _httpClient;

        public HttpClientServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<HttpResponseMessage> PostAsync(string requestUri, Object body)
        {
            var content = ParceBody(body);
            return await _httpClient.PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> PutAsync(string requestUri, Object body)
        {
            var content = ParceBody(body);
            return await _httpClient.PutAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> PatchAsync(string requestUri, Object body)
        {
            var content = ParceBody(body);
            return await _httpClient.PatchAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _httpClient.GetAsync(requestUri);
        }


        public HttpContent ParceBody(Object body)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json"
                );

            return jsonContent;
        }


    }
}
