using ItsmServices.Src.Users.Domain;

namespace ItsmServices.Src.Users.Services.Create
{
    public class UserCreator
    {

        private readonly UserRepository _userRepository;

        public UserCreator(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(Guid id, Guid objectId, Guid objectTypeId, int userRight)
        {
            var user = User.Create(id, objectId, objectTypeId, userRight);
            await _userRepository.Save(user);
        }

    }
}
