﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.Models;

public partial class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; }

    public int? FactionId { get; set; }

    public int? Health { get; set; }

    public int? Attack { get; set; }

    public int? Defense { get; set; }

    public virtual Faction Faction { get; set; }

    public virtual ICollection<HiredUnit> HiredUnits { get; } = new List<HiredUnit>();
}