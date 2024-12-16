namespace ItsmServices.Src.Priorities.Domain
{
    public class Priority
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Priority(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

    }
}
