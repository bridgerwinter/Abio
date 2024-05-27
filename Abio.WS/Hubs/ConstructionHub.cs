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
            //resourcegain.ConstructedBuildingId = result.;
            var id = result.Headers.Location.Segments[3];
            resourcegain.ConstructedBuildingId = Guid.Parse(id);
            resourcegain.UserId = (Guid)constructedBuilding.UserId;
            var building = await ApiService.GetBuilding((int)constructedBuilding.BuildingId);
            resourcegain.ResourceId = (int)building.ResourceId;

            var httpResponse = await ApiService.CreateResourceGain(resourcegain);
            await Clients.All.SendAsync("OnReceiveCreateConstructedBuilding", httpResponse.ReasonPhrase );
        }
    }
}
