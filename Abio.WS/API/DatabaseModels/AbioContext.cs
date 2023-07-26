using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Abio.WS.API.DatabaseModels
{
    public partial class AbioContext : DbContext
    {
        public AbioContext()
        {
        }

        public AbioContext(DbContextOptions<AbioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingsLevel> BuildingsLevels { get; set; }
        public virtual DbSet<ConstructedBuilding> ConstructedBuildings { get; set; }
        public virtual DbSet<Faction> Factions { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<HiredLeader> HiredLeaders { get; set; }
        public virtual DbSet<HiredLeaderStat> HiredLeaderStats { get; set; }
        public virtual DbSet<HiredUnit> HiredUnits { get; set; }
        public virtual DbSet<HiredUnitsStat> HiredUnitsStats { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemInventory> ItemInventories { get; set; }
        public virtual DbSet<Market> Markets { get; set; }
        public virtual DbSet<MarketListing> MarketListings { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<ResearchedTechnology> ResearchedTechnologies { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<ResourceInventory> ResourceInventories { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitGroup> UnitGroups { get; set; }
        public virtual DbSet<UnitLevel> UnitLevels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCitiesLeader> UserCitiesLeaders { get; set; }
        public virtual DbSet<UserCity> UserCities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=Abio.SQL;Integrated Security=true");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.BuildingId).ValueGeneratedNever();
            });

            modelBuilder.Entity<BuildingsLevel>(entity =>
            {
                entity.Property(e => e.BuildingLevelId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ConstructedBuilding>(entity =>
            {
                entity.Property(e => e.ConstructuredBuildingId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Faction>(entity =>
            {
                entity.Property(e => e.FactionId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            modelBuilder.Entity<HiredLeader>(entity =>
            {
                entity.Property(e => e.HiredLeaderId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<HiredLeaderStat>(entity =>
            {
                entity.Property(e => e.HiredLeaderStatsId).ValueGeneratedNever();
            });

            modelBuilder.Entity<HiredUnit>(entity =>
            {
                entity.Property(e => e.HiredUnitId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<HiredUnitsStat>(entity =>
            {
                entity.Property(e => e.HiredUnitStatsId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ItemInventory>(entity =>
            {
                entity.Property(e => e.ItemInventoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.Property(e => e.MarketId).ValueGeneratedNever();
            });

            modelBuilder.Entity<MarketListing>(entity =>
            {
                entity.Property(e => e.ListingId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ResearchedTechnology>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.ResourceId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ResourceInventory>(entity =>
            {
                entity.Property(e => e.ResourceInventoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.Property(e => e.TechnologyId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.UnitId).ValueGeneratedNever();
            });

            modelBuilder.Entity<UnitGroup>(entity =>
            {
                entity.Property(e => e.UnitGroupsId).ValueGeneratedNever();
            });

            modelBuilder.Entity<UnitLevel>(entity =>
            {
                entity.Property(e => e.UnitLevelId).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<UserCitiesLeader>(entity =>
            {
                entity.Property(e => e.UserCityLeadersId).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserCity>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
