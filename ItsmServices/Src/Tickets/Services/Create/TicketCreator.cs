using ItsmServices.Src.Tickets.Domain;
using ItsmServices.Src.Tickets.Infrastructure.Web;

namespace ItsmServices.Src.Tickets.Services.Create
{
    public class TicketCreator
    {
        private readonly TicketServices _ticketServices;

        public TicketCreator(TicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }
        public async Task<Ticket> Create(TicketRequest ticketRequest) {
            return await _ticketServices.Create(ticketRequest);
        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                      