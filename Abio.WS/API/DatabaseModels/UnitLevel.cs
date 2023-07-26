﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels;

[Table("UnitLevels", Schema = "Lookup")]
public partial class UnitLevel
{
    [Key]
    public int UnitLevelId { get; set; }

    [Unicode(false)]
    public string UnitRankName { get; set; }

    [InverseProperty("UnitLevelNavigation")]
    public virtual ICollection<HiredUnit> HiredUnits { get; } = new List<HiredUnit>();
}