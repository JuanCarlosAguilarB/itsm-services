namespace ItsmServices.Src.StatusModule.Domain
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Status(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
