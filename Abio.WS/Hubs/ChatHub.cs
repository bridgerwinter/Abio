using Abio.Library.Actions;
using Microsoft.AspNetCore.SignalR;

namespace Abio.WS.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            CombatResult combatResult = new CombatResult();
            combatResult.CombatLog = "Combat Result Successfully passed back to client";

            await Clients.All.SendAsync("ReceiveMessage", combatResult);
        }
    }
}
