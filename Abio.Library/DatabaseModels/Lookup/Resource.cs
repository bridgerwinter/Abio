﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class Resource
{
    public int ResourceId { get; set; }

    public string ResourceName { get; set; }

    public string ResourceDescription { get; set; }

    public virtual ICollection<ResourceGain> ResourceGain { get; set; } = new List<ResourceGain>();

    public virtual ICollection<ResourceInventory> ResourceInventory { get; set; } = new List<ResourceInventory>();
}