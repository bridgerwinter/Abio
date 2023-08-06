using Abio.Library.Actions;
using Microsoft.AspNetCore.SignalR.Client;
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
            Connection = new HubConnectionBuilder().WithUrl(chatUrl).WithAutomaticReconnect().Build();
        }
        public async Task Start()
        {
            
            // receive a message from the hub
            Connection.On<CombatResult>("ReceiveMessage", (result) => OnReceiveMessage(result));

            var t = Connection.StartAsync();

            t.Wait();
        }

        public async Task SendChatHubMessageAsync(CombatMessage combatMessage)
        {
            await Connection.InvokeAsync("SendMessage", combatMessage);
        }

        public void OnReceiveMessage(CombatResult combatResult)
        {
            System.Console.WriteLine("Test");
            System.Console.WriteLine($"Test {combatResult.CombatLog}");
        }

    }
}
