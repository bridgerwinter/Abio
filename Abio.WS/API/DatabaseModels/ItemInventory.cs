﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels;

[Table("ItemInventory", Schema = "Player")]
public partial class ItemInventory
{
    [Key]
    public Guid ItemInventoryId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? ItemId { get; set; }

    public long? Quantity { get; set; }

    public long? MaxInventory { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("ItemInventories")]
    public virtual Item Item { get; set; }

    [InverseProperty("ItemInventory")]
    public virtual ICollection<MarketListing> MarketListings { get; } = new List<MarketListing>();

    [ForeignKey("UserId")]
    [InverseProperty("ItemInventories")]
    public virtual User User { get; set; }
}