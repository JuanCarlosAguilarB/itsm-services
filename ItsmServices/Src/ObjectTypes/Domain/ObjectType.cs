namespace ItsmServices.Src.ObjectTypes.Domain
{
    public class ObjectType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ObjectType (Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
