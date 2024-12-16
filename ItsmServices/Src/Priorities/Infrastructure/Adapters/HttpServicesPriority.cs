using System.Text.Json;
using ItsmServices.Src.Priorities.Domain;
using ItsmServices.Src.Tickets.Domain;
using ItsmServices.Src.Tickets.Domain.Configs;

namespace ItsmServices.Src.Priorities.Infrastructure.Adapters
{
    public class HttpServicesPriority : ServicesPriority
    {
        private readonly HttpClient _httpClient;

        public HttpServicesPriority(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Priority>> FindAll()
        {
            string url = Config.UrlStatusService;

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al obtener las priorities. Código de estado: {response.StatusCode}");
            }

            string responseBody = await response.Content.ReadAsStringAsync();

            var priorityResponse = JsonSerializer.Deserialize<List<Priority>>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );


            if (priorityResponse == null)
            {
                throw new InvalidOperationException("No se pudo deserializar las priorities.");
            }

            return priorityResponse;
        }
    }
}
