using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Items", Schema = "Lookup")]
    public partial class Item
    {
        public Item()
        {
            ItemInventories = new HashSet<ItemInventory>();
            MarketListings = new HashSet<MarketListing>();
        }

        [Key]
        public Guid ItemId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string ItemName { get; set; }
        [Unicode(false)]
        public string ItemDescription { get; set; }

        [InverseProperty("Item")]
        public virtual ICollection<ItemInventory> ItemInventories { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<MarketListing> MarketListings { get; set; }
    }
}
