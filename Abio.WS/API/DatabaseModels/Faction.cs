﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels;

[Table("Factions", Schema = "Lookup")]
public partial class Faction
{
    [Key]
    public int FactionId { get; set; }

    [Unicode(false)]
    public string FactionName { get; set; }

    [InverseProperty("Faction")]
    public virtual ICollection<Building> Buildings { get; } = new List<Building>();

    [InverseProperty("Faction")]
    public virtual ICollection<Unit> Units { get; } = new List<Unit>();
}