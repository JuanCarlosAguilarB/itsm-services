using ItsmServices.Src.Tickets.Services.Update;
using Microsoft.AspNetCore.Mvc;

namespace ItsmServices.Src.Tickets.Infrastructure.Web
{
    [ApiController]
    public class PatchTicketController : ControllerBase
    {
        private readonly TicketUpdater _ticketUpdater;
        public PatchTicketController(TicketUpdater ticketUpdater)
        {
            _ticketUpdater = ticketUpdater;
        }
        [HttpPatch]
        [Route("itsm-management/v1/tickets/{id}")]
        public async Task<ActionResult> PatchTicket([FromRoute] Guid id, [FromBody] TicketUpdateRequest request)
        {
            await _ticketUpdater.Update(id, request.Status, request.UserId);
            return Ok();
        }
    }

    public record TicketUpdateRequest (int Status, Guid UserId)
    {
    }

}
