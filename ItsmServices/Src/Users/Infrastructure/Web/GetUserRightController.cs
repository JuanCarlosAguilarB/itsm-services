using ItsmServices.Src.Users.Domain;
using ItsmServices.Src.Users.Services.Find;
using Microsoft.AspNetCore.Mvc;

namespace ItsmServices.Src.Users.Infrastructure.Web
{
    [ApiController]
    public class GetUserRightController : ControllerBase
    {
        private readonly UserRightFinder _userRightFinder;

        public GetUserRightController(UserRightFinder userRightFinder)
        {
            _userRightFinder = userRightFinder;
        }

        [HttpGet]
        [Route("itsm-management/v1/users/rights")]
        public async Task<ActionResult<List<UserRight>>> GetUserRight(Guid id)
        {
            var userRight = await _userRightFinder.FindAll();

            return Ok(userRight);
        }
    }
}
