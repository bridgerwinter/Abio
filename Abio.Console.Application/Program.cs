using System;
using System.IO;
using Abio.WS.API;
using Abio.WS.API.Controllers;
using Abio.Library.DatabaseModels;
using Abio.Library.Services;
using System.ComponentModel;
using System.Reflection;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;
using Abio.Library.Actions;
using Microsoft.AspNetCore.SignalR.Client;
using Abio.Console.Application;

public class Program
{
    static void Main(string[] args)
    {
        // SignalRTestMethod().Wait();
        MainAsync().Wait();
    }
    static async Task MainAsync()
    {
        var units = await ApiService.GetAllUnits();

        List<Unit> army1 = new List<Unit>();
        List<Unit> army2 = new List<Unit>();

        var peasant = units.Where(p => p.UnitName == "Peasant").First();
        var knight = units.Where(p => p.UnitName == "Knight").First();
        for (int i = 0; i < 10; i++)
        {
            army1.Add(peasant);
        }

        for (int i = 0;i < 5; i++)
        {
            army2.Add(knight);
        }
        CombatMessage message = new CombatMessage();
        message.Army1 = army1;
        message.Army2 = army2;
        var connection = await SignalRConnection();
        await connection.DoCombatLogicAsync(message);

    }

    public static async Task<SignalRConnection> SignalRConnection()
    {
        var signalRConnection = new SignalRConnection();
        await signalRConnection.Start();
        return signalRConnection;
    }
}