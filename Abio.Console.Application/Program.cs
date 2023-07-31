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
        unit.UnitName = "Peasant";
        UnitStat stat = new UnitStat();
        UnitAttribute attribute = new UnitAttribute();

        stat.Staff = 10;
        stat.TwoHanded = 5;

        attribute.Strength = 60;
        attribute.Agility = 30;
        attribute.Dexterity = 20;
        attribute.Charisma = 30;
        attribute.Intelligence = 10;
        attribute.Willpower = 10;
        attribute.Soul = 0;
        attribute.Artistry = 0;
        attribute.Creativity = 0;
        attribute.Constitution = 40;
        attribute.Sanity = 50;

        //var response = await ApiService.CreateUnit(unit);
        var units = await ApiService.GetAllUnits();
        var id = units.First().UnitId;
        attribute.UnitId = id;
        stat.UnitId = id;
        await ApiService.CreateUnitAttribute(attribute);
        await ApiService.CreateUnitStat(stat);
    }
}