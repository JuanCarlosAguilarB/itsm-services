using ItsmServices.Src.Tickets.Infrastructure.Web;

namespace ItsmServices.Src.Tickets.Domain
{
    public interface TicketServices
    {
        Task<Ticket> Create(TicketRequest ticketRequest);
        Task<TicketResponse> FindAll
            (
                Guid userId,
                string? status,
                int page = 1,
                int per_page = 10,
                string? order = "statusId",
                string? order_by = "asc",
                List<string>? filter = null,
                List<string>? value = null
            );

        Task<TicketDetailsResponse> FindById(Guid id);

        Task<Note> AddNote(Guid ticketId, NoteRequest note);

        Task CloseTicket(Guid ticketId, Guid userId);
    }
}
