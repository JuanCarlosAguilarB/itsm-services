using System.Text.Json;
using ItsmServices.Src.Priorities.Domain;
using ItsmServices.Src.StatusModule.Domain;
using ItsmServices.Src.Tickets.Domain.Configs;

namespace ItsmServices.Src.StatusModule.Infrastructure.Adapters
{
    public class HttpServicesStatus : ServicesStatus
    {
        private readonly HttpClient _httpClient;
        public HttpServicesStatus(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Status>> FindAll()
        {
            string url = Config.UrlStatusService;

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al obtener los status. Código de estado: {response.StatusCode}");
            }

            string responseBody = await response.Content.ReadAsStringAsync();

            var statusResponse = JsonSerializer.Deserialize<List<Status>>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (statusResponse == null)
            {
                throw new InvalidOperationException("No se pudo deserializar la respuesta de los status");
            }
            return statusResponse;

        }
    }
}
