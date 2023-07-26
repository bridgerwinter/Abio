﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels;

[Table("UnitGroups", Schema = "Player")]
public partial class UnitGroup
{
    [Key]
    public Guid UnitGroupsId { get; set; }

    public Guid? HiredUnitId { get; set; }

    public Guid? HiredLeaderId { get; set; }

    public int? GroupNumber { get; set; }

    [ForeignKey("HiredLeaderId")]
    [InverseProperty("UnitGroups")]
    public virtual HiredLeader HiredLeader { get; set; }

    [ForeignKey("HiredUnitId")]
    [InverseProperty("UnitGroups")]
    public virtual HiredUnit HiredUnit { get; set; }
}