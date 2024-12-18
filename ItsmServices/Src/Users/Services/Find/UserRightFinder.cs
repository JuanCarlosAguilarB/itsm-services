using ItsmServices.Src.Users.Domain;

namespace ItsmServices.Src.Users.Services.Find
{
    public class UserRightFinder
    {
        private readonly UserRightRepository _userRightRepository;
        public UserRightFinder(UserRightRepository userRightRepository)
        {
            _userRightRepository = userRightRepository;
        }
        public async Task<List<UserRight>> FindAll()
        {
            return await _userRightRepository.FindAll();
        }
    }
}
