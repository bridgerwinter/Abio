﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class UnitGroup
{
    public Guid UnitGroupId { get; set; }

    public Guid? HiredUnitId { get; set; }

    public Guid? HiredLeaderId { get; set; }

    public int? GroupNumber { get; set; }

    public virtual HiredLeader HiredLeader { get; set; }

    public virtual HiredUnit HiredUnit { get; set; }
}