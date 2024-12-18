
namespace ItsmServices.Src.Users.Domain
{
    public interface UserRightRepository
    {
        public Task<List<UserRight>> FindAll();
        
    }
}
