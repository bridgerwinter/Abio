﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class HiredLeaderStat
{
    public Guid HiredLeaderStatId { get; set; }

    public Guid? HiredLeaderId { get; set; }

    public int? Leadership { get; set; }

    public int? Attack { get; set; }

    public int? Defense { get; set; }

    public int? Construction { get; set; }

    public int? ResourceProduction { get; set; }

    public virtual HiredLeader HiredLeader { get; set; }
}