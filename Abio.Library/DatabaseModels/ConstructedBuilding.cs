﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class ConstructedBuilding
{
    public Guid ConstructedBuildingId { get; set; }

    public int? BuildingId { get; set; }

    public Guid? UserId { get; set; }

    public int? BuildingLevel { get; set; }

    public byte[] created_at { get; set; }

    public virtual User User { get; set; }
}