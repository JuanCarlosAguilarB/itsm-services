using ItsmServices.Src.Tickets.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ItsmServices.Src.Tickets.Infrastructure.Web
{
    [ApiController]
    public class PostTicketController : ControllerBase
    {
        private readonly NoteCreator _noteCreator;

        public PostTicketController(NoteCreator noteCreator)
        {
            _noteCreator = noteCreator;
        }

        [HttpPost]
        [Route("itsm-management/v1/tickets/{ticketId}notes")]
        public async Task<ActionResult> AddNoteToTicket([FromBody] NoteRequest note, Guid ticketId)
        {
            Note noteCreated = await _noteCreator.Create(note, ticketId);
            return Ok(noteCreated);
        }

    }

    public record NoteRequest(
        Guid UserId,
        string Note
        );
}
