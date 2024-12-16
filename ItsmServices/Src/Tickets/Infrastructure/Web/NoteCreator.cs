using ItsmServices.Src.Tickets.Domain;

namespace ItsmServices.Src.Tickets.Infrastructure.Web
{
    public class NoteCreator
    {
        private readonly TicketServices _ticketServices;

        public NoteCreator(TicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        public async Task<Note> Create(NoteRequest note, Guid ticketId)
        {
            return await _ticketServices.AddNote(ticketId, note);
        }
    }
}