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
        public async Task Start()
        {
            var url = "http://localhost:5096/chathub";

            var connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            // receive a message from the hub
            connection.On<CombatResult>("ReceiveMessage", (result) => OnReceiveMessage(result));

            var t = connection.StartAsync();

            t.Wait();

            // send a message to the hub
            await connection.InvokeAsync("SendMessage", "ConsoleApp", "Message from the console app");
            System.Console.WriteLine("Test A");
        }

        private void OnReceiveMessage(CombatResult combatResult)
        {
            System.Console.WriteLine($"Test {combatResult.CombatLog}");
        }

    }
}
