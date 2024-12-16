namespace ItsmServices.Src.Tickets.Domain
{
    public record TicketDetailsResponse(
        string Subject,
        List<Context> Context,
        Guid UserId,
        int StatusId,
        List<Note> Notes,
        DateTime? ClosedAt,
        DateTime CreatedAt,
        DateTime UpdatedAt
        );

}
