using ItsmServices.Src.Users.Services.Create;
using Microsoft.AspNetCore.Mvc;

namespace ItsmServices.Src.Users.Infrastructure.Web
{
    [ApiController]
    public class PutUserController : ControllerBase
    {
        private readonly UserCreator _userCreator;

        public PutUserController(UserCreator userCreator)
        {
            _userCreator = userCreator;
        }

        [HttpPut]
        [Route("itsm-management/v1/users/{id}")]
        public async Task<ActionResult> PutUser(Guid id, [FromBody] UserRequest user)
        {
            await _userCreator.Create(
                id: id,
                objectId: user.ObjectId,
                objectTypeId: user.ObjectTypeId,
                userRight: user.UserRight
                );

            return Ok();
        }

    }


    public class UserRequest
    {
        public Guid ObjectId { get; set; }
        public Guid ObjectTypeId { get; set; }
        public int UserRight { get; set; }
    }

}
