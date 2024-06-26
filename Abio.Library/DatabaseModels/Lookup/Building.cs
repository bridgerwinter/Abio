﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class Building
{
    public int BuildingId { get; set; }

    public string BuildingName { get; set; }

    public string BuildingDescription { get; set; }

    public int? FactionId { get; set; }

    public int? ResourceId { get; set; }

    public int? FoodCost { get; set; }

    public int? WoodCost { get; set; }

    public int? SteelCost { get; set; }

    public int? GoldCost { get; set; }

    public int? StoneCost { get; set; }

    public virtual ICollection<ConstructedBuilding> ConstructedBuilding { get; set; } = new List<ConstructedBuilding>();

    public virtual Faction Faction { get; set; }
}