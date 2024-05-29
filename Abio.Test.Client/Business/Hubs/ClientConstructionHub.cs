using Abio.Library.Actions;
using Abio.Library.DatabaseModels;
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
    public class ClientConstructionHub
    {
        public HubConnection Connection { get; set; }
        string url = "http://localhost:5096/constructionhub";


        public ClientConstructionHub()
        {
            Connection = new HubConnectionBuilder().WithUrl(url).AddNewtonsoftJsonProtocol(opts =>
                opts.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto).Build();
        }
        public async Task Start()
        {

            // receive a message from the hub
            Connection.On<string>("OnReceiveCreateConstructedBuilding", OnReceiveCreateConstructedBuilding);

            var t = Connection.StartAsync();

            t.Wait();
        }

        public async Task CreateConstructedBuilding(ConstructedBuilding constructedBuilding)
        {
            await Connection.InvokeAsync("CreateConstructedBuilding", constructedBuilding);
        }

        // If youre having issues receiving messages it's probably the return type. httpResponseMessage could not get sent. string could, maybe size issue?
        public void OnReceiveCreateConstructedBuilding(string responseMessage)
        {
            Debug.WriteLine($"Received");
        }

    }

    public class HelperClientConstructionHub()
    {
        public static async Task<ClientConstructionHub> GetSignalRConnection()
        {
            var signalRConnection = new ClientConstructionHub();
            await signalRConnection.Start();
            return signalRConnection;
        }
    }

}
