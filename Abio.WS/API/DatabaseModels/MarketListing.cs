﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("MarketListings", Schema = "Economy")]
    public partial class MarketListing
    {
        [Key]
        public Guid ListingId { get; set; }
        public Guid? MarketId { get; set; }
        public Guid? ItemId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ItemInventoryId { get; set; }
        public long? ItemQuantity { get; set; }

        [ForeignKey("ItemId")]
        [InverseProperty("MarketListings")]
        public virtual Item Item { get; set; }
        [ForeignKey("ItemInventoryId")]
        [InverseProperty("MarketListings")]
        public virtual ItemInventory ItemInventory { get; set; }
        [ForeignKey("MarketId")]
        [InverseProperty("MarketListings")]
        public virtual Market Market { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("MarketListings")]
        public virtual User User { get; set; }
    }
}
