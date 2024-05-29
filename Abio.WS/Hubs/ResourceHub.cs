using Abio.Library.Actions;
using Abio.Library.DatabaseModels;
using Abio.Library.Services;
using Abio.WS.API.Logic;
using Microsoft.AspNetCore.SignalR;

namespace Abio.WS.Hubs
{
    public class ResourceHub : Hub
    {
        public async Task GatherResources(Guid userId)
        {
            var res = await ApiService.GetAllResourceGains();
            var inventory = await ApiService.GetAllResourceInventorys();
            inventory.Where(p => p.UserId == userId).ToList();
            res.Where(p => p.UserId == userId).ToList();

            foreach (var resource in res) 
            {
                TimeSpan diff = DateTime.Now - resource.TimeSinceLastGathered;
                var inv = inventory.Where(p => p.ResourceId == resource.ResourceId).FirstOrDefault();
                inv.Quantity += diff.Hours * 10 + 1;
                await ApiService.UpdateResourceInventory(inv);
                resource.TimeSinceLastGathered = DateTime.Now;
                await ApiService.UpdateResourceGain(resource);
            }
            
            await Clients.All.SendAsync("OnReceiveGatherResource", "nothing");
        }
    }
}
