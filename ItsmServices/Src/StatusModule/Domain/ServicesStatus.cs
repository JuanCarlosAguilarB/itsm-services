namespace ItsmServices.Src.StatusModule.Domain
{
    public interface ServicesStatus
    {
        public Task<List<Status>> FindAll();
    }
}
