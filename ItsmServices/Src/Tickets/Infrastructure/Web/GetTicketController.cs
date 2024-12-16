using System.Net.Http;
using ItsmServices.Src.Tickets.Domain;
using ItsmServices.Src.Tickets.Services.Find;
using Microsoft.AspNetCore.Mvc;

namespace ItsmServices.Src.Tickets.Infrastructure.Web
{
    [ApiController]
    public class GetTicketController : ControllerBase
    {

        private readonly TickerFinder _tickerFinder;

        public GetTicketController(TickerFinder tickerFinder)
        {
            _tickerFinder = tickerFinder;
        }

        [HttpGet]
        [Route("its-management/v1/tickets")]
        public async Task<ActionResult<TicketResponse>> GetTicket(
            [FromQuery] Guid userId,
            [FromQuery] string? status,
            [FromQuery] int page = 1,
            [FromQuery] int per_page = 10,
            [FromQuery] string? order = "statusId",
            [FromQuery] string? order_by = "asc",
            [FromQuery] List<string>? filter = null,
            [FromQuery] List<string>? value = null
        )
        {
            var tickets = await _tickerFinder.FindAll(userId, status, page, per_page, order, order_by, filter, value);

            return Ok(tickets);
        }


        [HttpGet]
        [Route("its-management/v1/tickets/{id}")]
        public async Task<ActionResult<TicketDetailsResponse>> RetriveTicket(
            Guid id,
            [FromQuery] Guid userId
        )
        {
            var ticket = await _tickerFinder.FindById(id, userId);

            return Ok(ticket);
        }
    }

}
