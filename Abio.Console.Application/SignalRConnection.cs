using Abio.Library.Actions;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Console.Application
{
    public class SignalRConnection
    {
        public HubConnection Connection { get; set; }
        string chatUrl = "http://localhost:5096/chathub";

        public SignalRConnection()
        {
            Connection = new HubConnectionBuilder().WithUrl(chatUrl).AddNewtonsoftJsonProtocol(opts =>
                opts.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto).Build();
        }
        public async Task Start()
        {
            
            // receive a message from the hub
            Connection.On<CombatResult>("ReceiveMessage", OnReceiveMessage);

            var t = Connection.StartAsync();

            t.Wait();
        }

        public async Task SendChatHubMessageAsync(CombatMessage combatMessage)
        {
            await Connection.InvokeAsync("SendMessage", combatMessage);
        }

        public void OnReceiveMessage(CombatResult combatResult)
        {
            System.Console.WriteLine($"Test {combatResult.CombatLog}");
        }

    }
}
