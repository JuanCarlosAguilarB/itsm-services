namespace ItsmServices.Src.Tickets.Domain
{
    public record TicketResponse(
        int Page,
        int TotalPages,
        int ElementsByPage,
        List<TicketData> Data
        );

    public record TicketData(
        int TicketId,
        string Subject,
        int StatusId,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
