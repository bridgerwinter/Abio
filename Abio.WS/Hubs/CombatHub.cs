using Abio.Library.Actions;
using Abio.Library.DatabaseModels;
using Abio.WS.API.Logic;
using Microsoft.AspNetCore.SignalR;

namespace Abio.WS.Hubs
{
    public class CombatHub : Hub
    {
        public async Task DoCombatLogic(CombatMessage combatMessage)
        {
            CombatResult combatResult = CombatLogic.GetCombatResult(combatMessage);

            await Clients.All.SendAsync("OnReceiveCombatResult", combatResult);
        }
    }
}
