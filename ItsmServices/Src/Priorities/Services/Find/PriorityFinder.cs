using ItsmServices.Src.Priorities.Domain;

namespace ItsmServices.Src.Priorities.Services.Find
{
    public class PriorityFinder
    {

        private readonly ServicesPriority _servicesPriority;
        public PriorityFinder(ServicesPriority servicesPriority)
        {
            _servicesPriority = servicesPriority;
        }
        public async Task<List<Priority>> FindAll()
        {
            return await _servicesPriority.FindAll();
        }

    }
}
