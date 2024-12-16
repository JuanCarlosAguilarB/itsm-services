using ItsmServices.Src.Tickets.Domain;
using ItsmServices.Src.Tickets.Infrastructure.Web;

namespace ItsmServices.Src.Tickets.Services.Update
{
    public class TicketUpdater
    {

        private readonly TicketServices _ticketServices;

        public TicketUpdater(TicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        public async Task Update(Guid id, int status, Guid userId)
        {
            // for now, only status can be updated to closed
            await _ticketServices.CloseTicket(id, userId);
        }

    }
}
