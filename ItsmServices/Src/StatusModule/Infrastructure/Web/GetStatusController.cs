using ItsmServices.Src.StatusModule.Domain;
using ItsmServices.Src.StatusModule.Services.Find;
using Microsoft.AspNetCore.Mvc;

namespace ItsmServices.Src.StatusModule.Infrastructure.Web
{
    [ApiController]
    public class GetStatusController : ControllerBase
    {

        private readonly StatusFinder _statusFinder;
        public GetStatusController(StatusFinder statusFinder)
        {
            _statusFinder = statusFinder;
        }

        [HttpGet]
        [Route("status")]
        public async Task<ActionResult<List<Status>>> GetStatus()
        {
            var status = await _statusFinder.FindAll();
            return Ok(status);
        }
    }
}
