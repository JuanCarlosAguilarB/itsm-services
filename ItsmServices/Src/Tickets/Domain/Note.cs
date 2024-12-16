namespace ItsmServices.Src.Tickets.Domain
{
    public class Note
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Note(Guid id, Guid ticketId, string description, DateTime createdAt)
        {
            Id = id;
            TicketId = ticketId;
            Description = description;
            CreatedAt = createdAt;
        }

    }
}