using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace FoodZone.Web.Helpers
{
    [HubName("tableHub")]
    public class TableHub : Hub
    {
        public static void BroadcastData()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<TableHub>();
            context.Clients.All.refreshAllTable();
        }

    }
}