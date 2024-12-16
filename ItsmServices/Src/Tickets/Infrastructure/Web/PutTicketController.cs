using ItsmServices.Src.Tickets.Services.Create;
using Microsoft.AspNetCore.Mvc;

namespace ItsmServices.Src.Tickets.Infrastructure.Web
{
    [ApiController]
    public class PutTicketController : ControllerBase
    {
        private readonly TicketCreator _ticketCreator;

        public PutTicketController(TicketCreator ticketCreator)
        {
            _ticketCreator = ticketCreator;
        }

        [HttpPut]
        [Route("itsm-management/v1/tickets/")]
        public async Task<ActionResult> PutTicket([FromBody] TicketRequest ticket)
        {
            await _ticketCreator.Create(ticket);
            return Ok();
        }

    }

    public record ContextRequest(
        Guid ObjectId,
        Guid TypeObjectId,
        string Action,
        int RequestTypeId,
        string Description,
        string ServiceId
        );
    public record TicketRequest(
        string Subject,
        Guid UserId,
        int StatusId,
        int PriorityId,
        List<ContextRequest> Context
        );

}
