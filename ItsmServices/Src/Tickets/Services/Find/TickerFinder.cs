using ItsmServices.Src.Tickets.Domain;

namespace ItsmServices.Src.Tickets.Services.Find
{
    public class TickerFinder
    {

        private readonly TicketServices _ticketServices;

        public TickerFinder(TicketServices ticketServices)
        {
            _ticketServices = ticketServices;
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
            return await _ticketServices.FindAll(userId, status, page, per_page, order, order_by, filter, value);
        }

        public async Task<TicketDetailsResponse> FindById(Guid id, Guid userId)
        {
            return await _ticketServices.FindById(id);
        }
    }
}
