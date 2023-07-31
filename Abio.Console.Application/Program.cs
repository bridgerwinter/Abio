using System;
using System.IO;
using Abio.WS.API;
using Abio.WS.API.Controllers;
using Abio.Library.DatabaseModels;
using Abio.Console.Application.Services;
using System.ComponentModel;
using System.Reflection;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;

public class Program
{
    static void Main(string[] args)
    {
        MainAsync().Wait();
    }
    static async Task MainAsync()
    {
        Unit unit = new Unit();
        unit.UnitName = "Archer";
        UnitStat stat = new UnitStat();
        UnitAttribute attribute = new UnitAttribute();

        stat.OneHanded = 25;
        stat.Bow = 75;
        stat.MeleeDefence = 10;
        stat.RangedDefence = 20;
        stat.MagicDefense = 0;
        stat.Dueling = 0;
        stat.Tank = 0;


        attribute.Strength = 45;
        attribute.Agility = 80;
        attribute.Dexterity = 80;
        attribute.Charisma = 40;
        attribute.Intelligence = 50;
        attribute.Willpower = 40;
        attribute.Soul = 20;
        attribute.Artistry = 40;
        attribute.Creativity = 45;
        attribute.Constitution = 60;
        attribute.Sanity = 50;

        var response = await ApiService.CreateUnit(unit);

        var newUnit = await ApiService.GetUnitByName(unit.UnitName);
        stat.UnitId = newUnit.UnitId;
        attribute.UnitId = newUnit.UnitId;
        await ApiService.CreateUnitAttribute(attribute);
        await ApiService.CreateUnitStat(stat);

    }
}