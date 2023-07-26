using System;
using System.IO;
using Abio.Library.Services;
using Abio.WS.API;
using Abio.WS.API.Controllers;
using Abio.WS.API.DatabaseModels;

public class Program
{
    static void Main(string[] args)
    {
        MainAsync().Wait();
    }
    static async Task MainAsync()
    { 
        
        Abio.WS.API.DatabaseModels.Unit unit = new Abio.WS.API.DatabaseModels.Unit();
        unit.Attack = 10;
        unit.Defense = 10;
        unit.UnitName = "Test";
        //unit.FactionId = 0;
        unit.Health = 10;
        try
        {
            var x = await ApiService.GetUnits();
            var response = await ApiService.PostUnit(unit);
            await Console.Out.WriteLineAsync(response.StatusCode.ToString() + "A New Unit in the Database");
            var units = await ApiService.GetUnits();
            await Console.Out.WriteLineAsync(string.Format("Reading Units in Database"));

            foreach (var item in units)
            {
                await Console.Out.WriteLineAsync(string.Format("------------------------------------------"));
                await Console.Out.WriteLineAsync(string.Format("Name: {0}", item.UnitName));
                await Console.Out.WriteLineAsync(string.Format("Attack: {0}", item.Attack));
                await Console.Out.WriteLineAsync(string.Format("Defense: {0}", item.Defense));
                await Console.Out.WriteLineAsync(string.Format("Health: {0}", item.Health));

            }
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
            throw;
        }

    }
}