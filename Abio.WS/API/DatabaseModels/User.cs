using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Users", Schema = "Security")]
    public partial class User
    {
        public User()
        {
            ConstructedBuildings = new HashSet<ConstructedBuilding>();
            Friends = new HashSet<Friend>();
            HiredLeaders = new HashSet<HiredLeader>();
            HiredUnits = new HashSet<HiredUnit>();
            ItemInventories = new HashSet<ItemInventory>();
            MarketListings = new HashSet<MarketListing>();
            ResourceInventories = new HashSet<ResourceInventory>();
            UserCities = new HashSet<UserCity>();
            UserCitiesLeaders = new HashSet<UserCitiesLeader>();
        }

        [Key]
        public Guid UserId { get; set; }
        [Required]
        [Column("created_at")]
        public byte[] CreatedAt { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<ConstructedBuilding> ConstructedBuildings { get; set; }
        [InverseProperty("FriendsWithNavigation")]
        public virtual ICollection<Friend> Friends { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<HiredLeader> HiredLeaders { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<HiredUnit> HiredUnits { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ItemInventory> ItemInventories { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<MarketListing> MarketListings { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ResourceInventory> ResourceInventories { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserCity> UserCities { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserCitiesLeader> UserCitiesLeaders { get; set; }
    }
}
