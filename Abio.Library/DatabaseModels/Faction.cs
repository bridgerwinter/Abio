﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class Faction
{
    public Guid FactionId { get; set; }

    public string FactionName { get; set; }

    public virtual ICollection<Building> Building { get; set; } = new List<Building>();

    public virtual ICollection<Unit> Unit { get; set; } = new List<Unit>();
}