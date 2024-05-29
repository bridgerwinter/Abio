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
    public class ClientCombatHub : SignalRConnection
    {
        public HubConnection Connection { get; set; }
        string url = "http://localhost:5096/combathub";

        public ClientCombatHub()
        {
            Connection = new HubConnectionBuilder().WithUrl(url).AddNewtonsoftJsonProtocol(opts =>
                opts.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto).Build();
        }

        public async Task Start()
        {

            // receive a message from the hub
            Connection.On<CombatResult>("OnReceiveCombatResult", OnReceiveCombatResult);

            var t = Connection.StartAsync();

            t.Wait();
        }

        public async Task DoCombatLogic(CombatMessage combatMessage)
        {
            await Connection.InvokeAsync("DoCombatLogic", combatMessage);
        }
        
        public void OnReceiveCombatResult(CombatResult combatResult)
        {
            Debug.WriteLine("Received Combat Result");
        }
    }
    public class HelperClientCombatHub()
    {
        public static async Task<ClientCombatHub> GetSignalRConnection()
        {
            var signalRConnection = new ClientCombatHub();
            await signalRConnection.Start();
            return signalRConnection;
        }
    }

}
