using Microsoft.AspNetCore.Mvc;

namespace ItsmServices.Src.Tickets.Infrastructure.Web
{
    [ApiController]
    public class Borrar : ControllerBase
    {
        private readonly HttpClientServices _httpClientServices;

        public Borrar(HttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        [HttpGet]
        [Route("vamos")]
        public async Task<ActionResult> Get() {

            //var response = await _httpClientServices.GetAsync("https://localhost:7032/api/v1/manager");
            var response = await _httpClientServices.GetAsync("http://localhost:5087/api/v1/manager");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al agregar el ticket. Código de estado: {response.StatusCode}");
            }
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
            return Ok(responseBody);
        }


    }
}
