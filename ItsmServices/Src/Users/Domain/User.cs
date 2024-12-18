namespace ItsmServices.Src.Users.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid ObjectId { get; set; }
        public Guid ObjectTypeId { get; set; }
        public int UserRightId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Boolean IsActive { get; set; }

        public User(Guid id, Guid objectId, Guid objectTypeId, int userRightId, DateTime createdAt, DateTime updatedAt, bool isActive)
        {
            Id = id;
            ObjectId = objectId;
            ObjectTypeId = objectTypeId;
            UserRightId = userRightId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsActive = isActive;
        }

        public static User Create(Guid id, Guid objectId, Guid objectTypeId, int userRightId)
        {
            return new User(id, objectId, objectTypeId, userRightId, DateTime.Now, DateTime.Now, true);
        }

    }
}
