using ItsmServices.Src.StatusModule.Domain;

namespace ItsmServices.Src.StatusModule.Services.Find
{
    public class StatusFinder
    {

        private readonly ServicesStatus _servicesStatus;

        public StatusFinder(ServicesStatus servicesStatus)
        {
            _servicesStatus = servicesStatus;
        }

        public async Task<List<Status>> FindAll()
        {
            return await _servicesStatus.FindAll();
        }

    }
}
