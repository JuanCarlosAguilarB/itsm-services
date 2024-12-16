using System;

namespace ItsmServices.Src.Tickets.Domain
{
    public class Ticket
    {
        public Guid? Id { get; private set; }
        public string Subject { get; set; }
        public List<Context> Context { get; set; }

        public Guid UserId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }

        public DateTime? ClosedAt { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Ticket(Guid id, Guid userId, string subject, int statusId, int priorityId, List<Context> context, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Subject = subject;
            UserId = userId;
            StatusId = statusId;
            Context = context;
            PriorityId = priorityId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

    }
}
