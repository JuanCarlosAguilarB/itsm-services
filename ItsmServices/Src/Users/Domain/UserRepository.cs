namespace ItsmServices.Src.Users.Domain
{
    public interface UserRepository
    {
        Task Save(User user);
    }
}
