﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class ResourceInventory
{
    public Guid ResourceInventoryId { get; set; }

    public Guid? UserId { get; set; }

    public int? ResourceId { get; set; }

    public long? Quantity { get; set; }

    public virtual Resource Resource { get; set; }

    public virtual User User { get; set; }
}