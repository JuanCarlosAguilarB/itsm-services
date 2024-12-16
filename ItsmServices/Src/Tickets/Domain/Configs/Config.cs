namespace ItsmServices.Src.Tickets.Domain.Configs
{
    public class Config
    {

        private static string _urlGlpiBase = "http://localhost:5000";
        public static string UrlTicket { get; private set; } = _urlGlpiBase + "/glpi-provider/v1/tickets";

        public static int ClosedStatusId { get; private set; } = 2;
        public static string UrlStatusService { get; internal set; } = _urlGlpiBase + "/glpi-provider/v1/status";
        public static string UrlPriorityServices { get; internal set; } = _urlGlpiBase + "/glpi-provider/v1/priorities";
    }
}
