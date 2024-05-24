using Abio.Library.Actions;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Test.Client.Business
{
    public class SignalRConnection
    {
        public HubConnection Connection { get; set; }
        string combatUrl = "http://localhost:5096/combathub";

        public SignalRConnection()
        {
            Connection = new HubConnectionBuilder().WithUrl(combatUrl).AddNewtonsoftJsonProtocol(opts =>
                opts.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto).Build();
        }
        public async Task Start()
        {

            // receive a message from the hub
            Connection.On<CombatResult>("OnReceiveCombatResult", OnReceiveCombatResult);

            var t = Connection.StartAsync();

            t.Wait();
        }

        public async Task DoCombatLogicAsync(CombatMessage combatMessage)
        {
            await Connection.InvokeAsync("DoCombatLogic", combatMessage);
        }

        public void OnReceiveCombatResult(CombatResult combatResult)
        {
            System.Console.WriteLine($"Test {combatResult.CombatLog}");
        }

    }

}
