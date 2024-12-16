using System.Text;
using System.Text.Json;
using ItsmServices.Src.Tickets.Domain;
using ItsmServices.Src.Tickets.Domain.Configs;
using ItsmServices.Src.Tickets.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItsmServices.Src.Tickets.Infrastructure.Adapters
{
    public class HttpTicketServices : TicketServices
    {
        private readonly HttpClientServices _httpClientServices;

        public HttpTicketServices(HttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        public async Task<Ticket> Create(TicketRequest ticketRequest)
        {


            string url = Config.UrlTicket;

            var response = await _httpClientServices.PutAsync(url, ticketRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al agregar el ticket. Código de estado: {response.StatusCode}");
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            var ticketResponse = JsonSerializer.Deserialize<Ticket>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (ticketResponse == null)
            {
                throw new InvalidOperationException("No se pudo deserializar la respuesta del ticket.");
            }

            return ticketResponse;
        }

        public async Task<TicketDetailsResponse> FindById(Guid id)
        {
            string url = $"{Config.UrlTicket}/{id}";

            var response = await _httpClientServices.GetAsync(url);

            string responseBody = await response.Content.ReadAsStringAsync();

            var ticketResponse = JsonSerializer.Deserialize<TicketDetailsResponse>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (ticketResponse == null)
            {
                throw new InvalidOperationException("No se pudo deserializar la respuesta del ticket.");
            }

            return ticketResponse;
        }

        public async Task<Note> AddNote(Guid ticketId, NoteRequest noteRequest)
        {
            string url = $"{Config.UrlTicket}/{ticketId}/notes";

            var payload = new { userId = noteRequest.UserId, note = noteRequest.Note };

            var response = await _httpClientServices.PostAsync(url, payload);
            
            string responseBody = await response.Content.ReadAsStringAsync();

            var noteResponse = JsonSerializer.Deserialize<Note>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (noteResponse == null)
            {
                throw new InvalidOperationException("No se pudo deserializar la respuesta del ticket.");
            }

            return noteResponse;
        }

        public async Task<TicketResponse> FindAll
            (
                Guid userId,
                string? status,
                int page = 1,
                int per_page = 10,
                string? order = "statusId",
                string? order_by = "asc",
                List<string>? filter = null,
                List<string>? value = null
            )
        {
            var queryParams = BuildQueryParams(userId, status, page, per_page, order, order_by, filter, value);
            string url = $"{Config.UrlTicket}?{queryParams}";

            var response = await _httpClientServices.GetAsync(url);

            string responseBody = await response.Content.ReadAsStringAsync();
            var ticketsResponse = JsonSerializer.Deserialize<TicketResponse>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (ticketsResponse == null)
            {
                throw new InvalidOperationException("No se pudo deserializar la respuesta del ticket.");
            }

            return ticketsResponse;
        }

        private string BuildQueryParams(
            Guid userId,
            string? status,
            int page,
            int per_page,
            string? order,
            string? order_by,
            List<string>? filter,
            List<string>? value)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(status)) queryParams.Add($"status={status}");
            if (filter != null && value != null && filter.Count == value.Count)
            {
                for (int i = 0; i < filter.Count; i++)
                {
                    queryParams.Add($"filter={filter[i]}&value={value[i]}");
                }
            }
            
            queryParams.Add($"userId={userId}");
            
            if (page > 0) queryParams.Add($"page={page}");
            if (per_page > 0) queryParams.Add($"per_page={per_page}");
            if (!string.IsNullOrEmpty(order)) queryParams.Add($"order={order}");
            if (!string.IsNullOrEmpty(order_by)) queryParams.Add($"order_by={order_by}");

            return string.Join("&", queryParams);
        }

        public async Task CloseTicket(Guid ticketId, Guid userId)
        {

            string url = $"{Config.UrlTicket}/{ticketId}";

            var payload = new
            {
                userId = userId,
                statusId = Config.ClosedStatusId
            };

            var response = await _httpClientServices.PatchAsync(url, payload);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al actualizar el ticket. Código de estado: {response.StatusCode}");
            }

        }
    }
}
