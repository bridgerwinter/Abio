﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class HiredUnitStatMagic
{
    public Guid HiredUnitStatMagicId { get; set; }

    public byte? Life { get; set; }

    public byte? Death { get; set; }

    public byte? Nature { get; set; }

    public virtual ICollection<HiredUnitStat> HiredUnitStat { get; set; } = new List<HiredUnitStat>();
}