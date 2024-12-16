namespace ItsmServices.Src.Tickets.Domain
{
    public class Context
    {
        public int Id { get; set; }
        public Guid ObjectId { get; set; }
        public Guid TypeObjectId { get; set; }
        public required string Action { get; set; }
        public int RequestTypeId { get; set; }
        public required string Description { get; set; }
        public required string ServiceId { get; set; }
        public DateTime CreatedAt { get; private set; }


        public Context(int id, Guid objectId, Guid typeObjectId, string action, int requestTypeId, string description, string serviceId, DateTime createdAt)
        {
            Id = id;
            ObjectId = objectId;
            TypeObjectId = typeObjectId;
            Action = action;
            RequestTypeId = requestTypeId;
            Description = description;
            ServiceId = serviceId;
            CreatedAt = createdAt;

        }

    }
}      