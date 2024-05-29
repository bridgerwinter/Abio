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

namespace Abio.Test.Client.Business.Hubs
{
    public class SignalRConnection
    {
        public HubConnection Connection { get; set; }
        string url = "http://localhost:5096/combathub";


        public SignalRConnection()
        {
            Connection = new HubConnectionBuilder().WithUrl(url).AddNewtonsoftJsonProtocol(opts =>
                opts.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto).Build();
        }
        public async Task Start()
        {
            var t = Connection.StartAsync();
            t.Wait();
        }
    }

}
