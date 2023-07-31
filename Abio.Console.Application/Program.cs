using System;
using System.IO;
using Abio.WS.API;
using Abio.WS.API.Controllers;
using Abio.Library.DatabaseModels;
using Abio.Console.Application.Services;

public class Program
{
    static void Main(string[] args)
    {
        MainAsync().Wait();
    }
    static async Task MainAsync()
    { 
        
        Unit unit = new Unit();
        unit.Attack = 10;
        unit.Defense = 10;
        unit.UnitName = "Test";
        //unit.FactionId = 0;
        unit.Health = 10;
        try
        {
            var x = await ApiService.GetAllUnits();
            var response = await ApiService.CreateUnit(unit);
            await Console.Out.WriteLineAsync(response.StatusCode.ToString() + "A New Unit in the Database");
            var units = await ApiService.GetAllUnits();
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