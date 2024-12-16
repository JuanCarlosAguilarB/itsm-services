using ItsmServices.Src.Priorities.Services.Find;
using Microsoft.AspNetCore.Mvc;

namespace ItsmServices.Src.Priorities.Infrastructure.Web
{
    [ApiController]
    public class GetPriorityController : ControllerBase
    {

        private readonly PriorityFinder _priorityFinder;
        public GetPriorityController(PriorityFinder priorityFinder)
        {
            _priorityFinder = priorityFinder;
        }

        [HttpGet]
        [Route("itsm-management/v1/priorities")]
        public async Task<ActionResult> GetPriorities()
        {
            var priorities = await _priorityFinder.FindAll();
            return Ok(priorities);
        }
    }
}
