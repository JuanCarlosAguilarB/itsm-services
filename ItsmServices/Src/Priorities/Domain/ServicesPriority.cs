namespace ItsmServices.Src.Priorities.Domain
{
    public interface ServicesPriority
    {
        public Task<List<Priority>> FindAll();
    }
}
