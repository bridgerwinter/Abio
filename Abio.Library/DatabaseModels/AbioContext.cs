﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Abio.Library.DatabaseModels;

public partial class AbioContext : DbContext
{
    public AbioContext(DbContextOptions<AbioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Building> Building { get; set; }

    public virtual DbSet<BuildingLevel> BuildingLevel { get; set; }

    public virtual DbSet<ConstructedBuilding> ConstructedBuilding { get; set; }

    public virtual DbSet<Faction> Faction { get; set; }

    public virtual DbSet<Friend> Friend { get; set; }

    public virtual DbSet<HiredLeader> HiredLeader { get; set; }

    public virtual DbSet<HiredLeaderStat> HiredLeaderStat { get; set; }

    public virtual DbSet<HiredUnit> HiredUnit { get; set; }

    public virtual DbSet<HiredUnitStat> HiredUnitStat { get; set; }

    public virtual DbSet<Item> Item { get; set; }

    public virtual DbSet<ItemInventory> ItemInventory { get; set; }

    public virtual DbSet<Market> Market { get; set; }

    public virtual DbSet<MarketListing> MarketListing { get; set; }

    public virtual DbSet<Player> Player { get; set; }

    public virtual DbSet<ResearchedTechnology> ResearchedTechnology { get; set; }

    public virtual DbSet<Resource> Resource { get; set; }

    public virtual DbSet<ResourceInventory> ResourceInventory { get; set; }

    public virtual DbSet<Technology> Technology { get; set; }

    public virtual DbSet<Unit> Unit { get; set; }

    public virtual DbSet<UnitGroup> UnitGroup { get; set; }

    public virtual DbSet<UnitLevel> UnitLevel { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<UserCity> UserCity { get; set; }

    public virtual DbSet<UserCityLeader> UserCityLeader { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDC4C72E9888");

            entity.ToTable("Building", "Lookup");

            entity.Property(e => e.BuildingId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BuildingName).IsUnicode(false);

            entity.HasOne(d => d.Faction).WithMany(p => p.Building)
                .HasForeignKey(d => d.FactionId)
                .HasConstraintName("FK__Building__Factio__26BAB19C");
        });

        modelBuilder.Entity<BuildingLevel>(entity =>
        {
            entity.HasKey(e => e.BuildingLevelId).HasName("PK__Building__17A713DC35A4C9F3");

            entity.ToTable("BuildingLevel", "Lookup");

            entity.Property(e => e.BuildingLevelId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BuildingRankName).IsUnicode(false);
        });

        modelBuilder.Entity<ConstructedBuilding>(entity =>
        {
            entity.HasKey(e => e.ConstructedBuildingId).HasName("PK__Construc__AAE9794C2F370956");

            entity.ToTable("ConstructedBuilding", "Player");

            entity.Property(e => e.ConstructedBuildingId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.created_at)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Building).WithMany(p => p.ConstructedBuilding)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__Construct__Build__1590259A");

            entity.HasOne(d => d.BuildingLevel).WithMany(p => p.ConstructedBuilding)
                .HasForeignKey(d => d.BuildingLevelId)
                .HasConstraintName("FK__Construct__Build__17786E0C");

            entity.HasOne(d => d.User).WithMany(p => p.ConstructedBuilding)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Construct__UserI__168449D3");
        });

        modelBuilder.Entity<Faction>(entity =>
        {
            entity.HasKey(e => e.FactionId).HasName("PK__Faction__9321345A7F7B0A91");

            entity.ToTable("Faction", "Lookup");

            entity.Property(e => e.FactionId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FactionName).IsUnicode(false);
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Friend__1788CC4C380354C1");

            entity.ToTable("Friend", "Player");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.FriendsWithNavigation).WithMany(p => p.Friend)
                .HasForeignKey(d => d.FriendsWith)
                .HasConstraintName("FK__Friend__FriendsW__21F5FC7F");
        });

        modelBuilder.Entity<HiredLeader>(entity =>
        {
            entity.HasKey(e => e.HiredLeaderId).HasName("PK__HiredLea__4982B2BD2A5935EE");

            entity.ToTable("HiredLeader", "Player");

            entity.Property(e => e.HiredLeaderId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.HiredLeaderName)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.created_at)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.User).WithMany(p => p.HiredLeader)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__HiredLead__UserI__1D314762");
        });

        modelBuilder.Entity<HiredLeaderStat>(entity =>
        {
            entity.HasKey(e => e.HiredLeaderStatId).HasName("PK__HiredLea__1DA705AC3106F228");

            entity.ToTable("HiredLeaderStat", "Player");

            entity.Property(e => e.HiredLeaderStatId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.HiredLeader).WithMany(p => p.HiredLeaderStat)
                .HasForeignKey(d => d.HiredLeaderId)
                .HasConstraintName("FK__HiredLead__Hired__12B3B8EF");
        });

        modelBuilder.Entity<HiredUnit>(entity =>
        {
            entity.HasKey(e => e.HiredUnitId).HasName("PK__HiredUni__68A545159C541FD4");

            entity.ToTable("HiredUnit", "Player");

            entity.Property(e => e.HiredUnitId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.created_at)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.HiredLeader).WithMany(p => p.HiredUnit)
                .HasForeignKey(d => d.HiredLeaderId)
                .HasConstraintName("FK__HiredUnit__Hired__10CB707D");

            entity.HasOne(d => d.Unit).WithMany(p => p.HiredUnit)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK__HiredUnit__UnitI__1B48FEF0");

            entity.HasOne(d => d.UnitLevel).WithMany(p => p.HiredUnit)
                .HasForeignKey(d => d.UnitLevelId)
                .HasConstraintName("FK__HiredUnit__UnitL__1C3D2329");

            entity.HasOne(d => d.User).WithMany(p => p.HiredUnit)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__HiredUnit__UserI__1A54DAB7");
        });

        modelBuilder.Entity<HiredUnitStat>(entity =>
        {
            entity.HasKey(e => e.HiredUnitStatId).HasName("PK__HiredUni__976C0A010F6D4D71");

            entity.ToTable("HiredUnitStat", "Player");

            entity.Property(e => e.HiredUnitStatId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.HiredUnit).WithMany(p => p.HiredUnitStat)
                .HasForeignKey(d => d.HiredUnitId)
                .HasConstraintName("FK__HiredUnit__Hired__11BF94B6");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__727E838BE808A8A9");

            entity.ToTable("Item", "Lookup");

            entity.Property(e => e.ItemId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ItemDescription).IsUnicode(false);
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemInventory>(entity =>
        {
            entity.HasKey(e => e.ItemInventoryId).HasName("PK__ItemInve__FCBE0BEB97D57E72");

            entity.ToTable("ItemInventory", "Player");

            entity.Property(e => e.ItemInventoryId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemInventory)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__ItemInven__ItemI__1F198FD4");

            entity.HasOne(d => d.User).WithMany(p => p.ItemInventory)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ItemInven__UserI__1E256B9B");
        });

        modelBuilder.Entity<Market>(entity =>
        {
            entity.HasKey(e => e.MarketId).HasName("PK__Market__74B186AFD58F42AB");

            entity.ToTable("Market", "Economy");

            entity.Property(e => e.MarketId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.MarketName).IsUnicode(false);
        });

        modelBuilder.Entity<MarketListing>(entity =>
        {
            entity.HasKey(e => e.MarketListingId).HasName("PK__MarketLi__9C448E518A7C5991");

            entity.ToTable("MarketListing", "Economy");

            entity.Property(e => e.MarketListingId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Item).WithMany(p => p.MarketListing)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__MarketLis__ItemI__23DE44F1");

            entity.HasOne(d => d.ItemInventory).WithMany(p => p.MarketListing)
                .HasForeignKey(d => d.ItemInventoryId)
                .HasConstraintName("FK__MarketLis__ItemI__24D2692A");

            entity.HasOne(d => d.Market).WithMany(p => p.MarketListing)
                .HasForeignKey(d => d.MarketId)
                .HasConstraintName("FK__MarketLis__Marke__25C68D63");

            entity.HasOne(d => d.User).WithMany(p => p.MarketListing)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__MarketLis__UserI__22EA20B8");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Player__1788CC4C4447A744");

            entity.ToTable("Player", "Player");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.User).WithOne(p => p.Player)
                .HasForeignKey<Player>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Player__UserId__0C06BB60");
        });

        modelBuilder.Entity<ResearchedTechnology>(entity =>
        {
            entity.HasKey(e => e.ResearchedTechnologyId).HasName("PK__Research__927E67F699B8A582");

            entity.ToTable("ResearchedTechnology", "Player");

            entity.Property(e => e.ResearchedTechnologyId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.created_at)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Technology).WithMany(p => p.ResearchedTechnology)
                .HasForeignKey(d => d.TechnologyId)
                .HasConstraintName("FK__Researche__Techn__186C9245");

            entity.HasOne(d => d.User).WithMany(p => p.ResearchedTechnology)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Researche__UserI__1960B67E");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__Resource__4ED1816F13802370");

            entity.ToTable("Resource", "Lookup");

            entity.Property(e => e.ResourceId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ResourceName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ResourceInventory>(entity =>
        {
            entity.HasKey(e => e.ResourceInventoryId).HasName("PK__Resource__CEE02802395DE27D");

            entity.ToTable("ResourceInventory", "Player");

            entity.Property(e => e.ResourceInventoryId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceInventory)
                .HasForeignKey(d => d.ResourceId)
                .HasConstraintName("FK__ResourceI__Resou__2101D846");

            entity.HasOne(d => d.User).WithMany(p => p.ResourceInventory)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ResourceI__UserI__200DB40D");
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.HasKey(e => e.TechnologyId).HasName("PK__Technolo__705701585C4F2FE4");

            entity.ToTable("Technology", "Lookup");

            entity.Property(e => e.TechnologyId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TechnologyName).IsUnicode(false);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__Unit__44F5ECB5336C6693");

            entity.ToTable("Unit", "Lookup");

            entity.Property(e => e.UnitId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UnitName).IsUnicode(false);

            entity.HasOne(d => d.Faction).WithMany(p => p.Unit)
                .HasForeignKey(d => d.FactionId)
                .HasConstraintName("FK__Unit__FactionId__27AED5D5");
        });

        modelBuilder.Entity<UnitGroup>(entity =>
        {
            entity.HasKey(e => e.UnitGroupId).HasName("PK__UnitGrou__46226B18747573A2");

            entity.ToTable("UnitGroup", "Player");

            entity.Property(e => e.UnitGroupId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.HiredLeader).WithMany(p => p.UnitGroup)
                .HasForeignKey(d => d.HiredLeaderId)
                .HasConstraintName("FK__UnitGroup__Hired__149C0161");

            entity.HasOne(d => d.HiredUnit).WithMany(p => p.UnitGroup)
                .HasForeignKey(d => d.HiredUnitId)
                .HasConstraintName("FK__UnitGroup__Hired__13A7DD28");
        });

        modelBuilder.Entity<UnitLevel>(entity =>
        {
            entity.HasKey(e => e.UnitLevelId).HasName("PK__UnitLeve__4D7ADE084C5F1858");

            entity.ToTable("UnitLevel", "Lookup");

            entity.Property(e => e.UnitLevelId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UnitRankName).IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C680D87C5");

            entity.ToTable("User", "Security");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.created_at)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<UserCity>(entity =>
        {
            entity.HasKey(e => e.UserCityId).HasName("PK__UserCity__E130899E79ADB05B");

            entity.ToTable("UserCity", "Player");

            entity.Property(e => e.UserCityId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.User).WithMany(p => p.UserCity)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserCity__UserId__0CFADF99");
        });

        modelBuilder.Entity<UserCityLeader>(entity =>
        {
            entity.HasKey(e => e.UserCityLeaderId).HasName("PK__UserCity__8EE7BD8849CC988E");

            entity.ToTable("UserCityLeader", "Player");

            entity.Property(e => e.UserCityLeaderId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.HiredLeader).WithMany(p => p.UserCityLeader)
                .HasForeignKey(d => d.HiredLeaderId)
                .HasConstraintName("FK__UserCityL__Hired__0EE3280B");

            entity.HasOne(d => d.UserCity).WithMany(p => p.UserCityLeader)
                .HasForeignKey(d => d.UserCityId)
                .HasConstraintName("FK__UserCityL__UserC__0FD74C44");

            entity.HasOne(d => d.User).WithMany(p => p.UserCityLeader)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserCityL__UserI__0DEF03D2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}