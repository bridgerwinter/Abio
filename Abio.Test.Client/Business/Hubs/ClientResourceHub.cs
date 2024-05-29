using Abio.Library.Actions;
using Abio.Library.DatabaseModels;
using Abio.Test.Client.Business.Hubs;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Test.Client.Business
{
    public class ClientReosurceHub : SignalRConnection
    {
        public HubConnection Connection { get; set; }
        string url = "http://localhost:5096/resourcehub";

        public ClientReosurceHub()
        {
            Connection = new HubConnectionBuilder().WithUrl(url).AddNewtonsoftJsonProtocol(opts =>
                opts.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto).Build();
        }

        public async Task Start()
        {

            // receive a message from the hub
            //Connection.On<CombatResult>("OnReceiveResource", OnReceiveResource);

            var t = Connection.StartAsync();

            t.Wait();
        }

        public async Task GatherResources(Guid id)
        {
            await Connection.InvokeAsync("GatherResources", id);
        }
        
        public void OnReceiveResource()
        {
            Debug.WriteLine("Received Combat Result");
        }
    }
    public class HelperClientResourceHub()
    {
        public static async Task<ClientReosurceHub> GetSignalRConnection()
        {
            var signalRConnection = new ClientReosurceHub();
            await signalRConnection.Start();
            return signalRConnection;
        }
    }

}
