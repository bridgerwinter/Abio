using Abio.Library.Actions;
using Abio.Library.DatabaseModels;
using Abio.Library.Services;
using Abio.WS.API.Logic;
using Microsoft.AspNetCore.SignalR;
using System;

namespace Abio.WS.Hubs
{
    public class ConstructionHub : Hub
    {
        public async Task CreateConstructedBuilding(ConstructedBuilding constructedBuilding)
        {
            var result = await ApiService.CreateConstructedBuilding(constructedBuilding);
            ResourceGain resourcegain = new ResourceGain();
            var id = result.Headers.Location.Segments[3];
            resourcegain.ConstructedBuildingId = Guid.Parse(id);
            resourcegain.UserId = (Guid)constructedBuilding.UserId;
            var building = await ApiService.GetBuilding((int)constructedBuilding.BuildingId);
            // Subtract totals 
            await SubtractBuildingCosts(building, resourcegain.UserId);
            resourcegain.ResourceId = (int)building.ResourceId;

            var httpResponse = await ApiService.CreateResourceGain(resourcegain);
            await Clients.All.SendAsync("OnReceiveCreateConstructedBuilding", httpResponse.ReasonPhrase );
        }

        public async Task SubtractBuildingCosts(Building b, Guid id)
        {
            
            var r = await ApiService.GetResourceInventoryByUser(id);
            foreach(var i in r)
            {
                switch (i.ResourceId)
                {
                    case 5:
                        i.Quantity -= b.StoneCost;
                        break;
                    case 4:
                        i.Quantity -= b.GoldCost;
                        break;
                    case 2:
                        i.Quantity -= b.WoodCost;
                        break;
                    case 3:
                        i.Quantity -= b.SteelCost;
                        break;
                    case 1:
                        i.Quantity -= b.FoodCost;
                        break;
                }
                await ApiService.UpdateResourceInventory(i);
            }


        }
    }
}
