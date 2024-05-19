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

    public virtual DbSet<Attribute> Attribute { get; set; }

    public virtual DbSet<BodyPart> BodyPart { get; set; }

    public virtual DbSet<Building> Building { get; set; }

    public virtual DbSet<BuildingLevel> BuildingLevel { get; set; }

    public virtual DbSet<ConstructedBuilding> ConstructedBuilding { get; set; }

    public virtual DbSet<Emotion> Emotion { get; set; }

    public virtual DbSet<Faction> Faction { get; set; }

    public virtual DbSet<Feat> Feat { get; set; }

    public virtual DbSet<Friend> Friend { get; set; }

    public virtual DbSet<HiredLeader> HiredLeader { get; set; }

    public virtual DbSet<HiredLeaderStat> HiredLeaderStat { get; set; }

    public virtual DbSet<HiredUnit> HiredUnit { get; set; }

    public virtual DbSet<HiredUnitStat> HiredUnitStat { get; set; }

    public virtual DbSet<HiredUnitStatBody> HiredUnitStatBody { get; set; }

    public virtual DbSet<HiredUnitStatCivil> HiredUnitStatCivil { get; set; }

    public virtual DbSet<HiredUnitStatCombat> HiredUnitStatCombat { get; set; }

    public virtual DbSet<HiredUnitStatEmotion> HiredUnitStatEmotion { get; set; }

    public virtual DbSet<HiredUnitStatFeat> HiredUnitStatFeat { get; set; }

    public virtual DbSet<HiredUnitStatMagic> HiredUnitStatMagic { get; set; }

    public virtual DbSet<Item> Item { get; set; }

    public virtual DbSet<ItemInventory> ItemInventory { get; set; }

    public virtual DbSet<Market> Market { get; set; }

    public virtual DbSet<MarketListing> MarketListing { get; set; }

    public virtual DbSet<PersonalityTrait> PersonalityTrait { get; set; }

    public virtual DbSet<Player> Player { get; set; }

    public virtual DbSet<ResearchedTechnology> ResearchedTechnology { get; set; }

    public virtual DbSet<Resource> Resource { get; set; }

    public virtual DbSet<ResourceGain> ResourceGain { get; set; }

    public virtual DbSet<ResourceInventory> ResourceInventory { get; set; }

    public virtual DbSet<Skill> Skill { get; set; }

    public virtual DbSet<Technology> Technology { get; set; }

    public virtual DbSet<Unit> Unit { get; set; }

    public virtual DbSet<UnitLevel> UnitLevel { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<UserCity> UserCity { get; set; }

    public virtual DbSet<UserCityLeader> UserCityLeader { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PK__Attribut__C18929EACE3A1441");

            entity.ToTable("Attribute", "Lookup");

            entity.Property(e => e.AttributeDescription).IsUnicode(false);
            entity.Property(e => e.AttributeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BodyPart>(entity =>
        {
            entity.HasKey(e => e.BodyPartId).HasName("PK__BodyPart__4819A284F639F744");

            entity.ToTable("BodyPart", "Lookup");

            entity.Property(e => e.BodyPartDescription).IsUnicode(false);
            entity.Property(e => e.BodyPartName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDC47DAA78DB");

            entity.ToTable("Building", "Lookup");

            entity.Property(e => e.BuildingDescription).IsUnicode(false);
            entity.Property(e => e.BuildingName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Faction).WithMany(p => p.Building)
                .HasForeignKey(d => d.FactionId)
                .HasConstraintName("FK__Building__Factio__033C6B35");
        });

        modelBuilder.Entity<BuildingLevel>(entity =>
        {
            entity.HasKey(e => e.BuildingLevelId).HasName("PK__Building__17A713DC1C9D12A7");

            entity.ToTable("BuildingLevel", "Lookup");

            entity.Property(e => e.BuildingLevelDescription).IsUnicode(false);
            entity.Property(e => e.BuildingLevelName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConstructedBuilding>(entity =>
        {
            entity.HasKey(e => e.ConstructedBuildingId).HasName("PK__Construc__AAE9794C16D41167");

            entity.ToTable("ConstructedBuilding", "Player");

            entity.Property(e => e.ConstructedBuildingId).ValueGeneratedNever();
            entity.Property(e => e.created_at)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Building).WithMany(p => p.ConstructedBuilding)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__Construct__Build__7211DF33");

            entity.HasOne(d => d.BuildingLevel).WithMany(p => p.ConstructedBuilding)
                .HasForeignKey(d => d.BuildingLevelId)
                .HasConstraintName("FK__Construct__Build__73FA27A5");

            entity.HasOne(d => d.User).WithMany(p => p.ConstructedBuilding)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Construct__UserI__7306036C");
        });

        modelBuilder.Entity<Emotion>(entity =>
        {
            entity.HasKey(e => e.EmotionId).HasName("PK__Emotion__25B02E315F5C51FB");

            entity.ToTable("Emotion", "Lookup");

            entity.Property(e => e.EmotionDescription).IsUnicode(false);
            entity.Property(e => e.EmotionName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Faction>(entity =>
        {
            entity.HasKey(e => e.FactionId).HasName("PK__Faction__9321345ACC17001D");

            entity.ToTable("Faction", "Lookup");

            entity.Property(e => e.FactionDescription).IsUnicode(false);
            entity.Property(e => e.FactionName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Feat>(entity =>
        {
            entity.HasKey(e => e.FeatId).HasName("PK__Feat__D53F25CE2F9C398C");

            entity.ToTable("Feat", "Lookup");

            entity.Property(e => e.FeatDescription).IsUnicode(false);
            entity.Property(e => e.FeatName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Friend__1788CC4C31D6E7D1");

            entity.ToTable("Friend", "Player");

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasOne(d => d.FriendsWithNavigation).WithMany(p => p.Friend)
                .HasForeignKey(d => d.FriendsWith)
                .HasConstraintName("FK__Friend__FriendsW__7E77B618");
        });

        modelBuilder.Entity<HiredLeader>(entity =>
        {
            entity.HasKey(e => e.HiredLeaderId).HasName("PK__HiredLea__4982B2BDF6C94B10");

            entity.ToTable("HiredLeader", "Player");

            entity.Property(e => e.HiredLeaderId).ValueGeneratedNever();
            entity.Property(e => e.HiredLeaderName)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.created_at)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.User).WithMany(p => p.HiredLeader)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__HiredLead__UserI__79B300FB");
        });

        modelBuilder.Entity<HiredLeaderStat>(entity =>
        {
            entity.HasKey(e => e.HiredLeaderStatId).HasName("PK__HiredLea__1DA705AC12314292");

            entity.ToTable("HiredLeaderStat", "Player");

            entity.Property(e => e.HiredLeaderStatId).ValueGeneratedNever();

            entity.HasOne(d => d.HiredLeader).WithMany(p => p.HiredLeaderStat)
                .HasForeignKey(d => d.HiredLeaderId)
                .HasConstraintName("FK__HiredLead__Hired__6F357288");
        });

        modelBuilder.Entity<HiredUnit>(entity =>
        {
            entity.HasKey(e => e.HiredUnitId).HasName("PK__HiredUni__68A54515CE5D2F5D");

            entity.ToTable("HiredUnit", "Player");

            entity.Property(e => e.HiredUnitId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Age).HasDefaultValue((byte)0);
            entity.Property(e => e.Name)
                .HasMaxLength(24)
                .IsUnicode(false);

            entity.HasOne(d => d.HiredUnitStat).WithMany(p => p.HiredUnit)
                .HasForeignKey(d => d.HiredUnitStatId)
                .HasConstraintName("FK__HiredUnit__Hired__00EA0E6F");

            entity.HasOne(d => d.Unit).WithMany(p => p.HiredUnit)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK__HiredUnit__UnitI__7F01C5FD");

            entity.HasOne(d => d.User).WithMany(p => p.HiredUnit)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__HiredUnit__UserI__7FF5EA36");
        });

        modelBuilder.Entity<HiredUnitStat>(entity =>
        {
            entity.HasKey(e => e.HiredUnitStatId).HasName("PK__HiredUni__976C0A01D568DA02");

            entity.ToTable("HiredUnitStat", "Player");

            entity.Property(e => e.HiredUnitStatId).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.HiredUnitStatBody).WithMany(p => p.HiredUnitStat)
                .HasForeignKey(d => d.HiredUnitStatBodyId)
                .HasConstraintName("FK__HiredUnit__Hired__7854C86E");

            entity.HasOne(d => d.HiredUnitStatCivil).WithMany(p => p.HiredUnitStat)
                .HasForeignKey(d => d.HiredUnitStatCivilId)
                .HasConstraintName("FK__HiredUnit__Hired__766C7FFC");

            entity.HasOne(d => d.HiredUnitStatCombat).WithMany(p => p.HiredUnitStat)
                .HasForeignKey(d => d.HiredUnitStatCombatId)
                .HasConstraintName("FK__HiredUnit__Hired__75785BC3");

            entity.HasOne(d => d.HiredUnitStatEmotion).WithMany(p => p.HiredUnitStat)
                .HasForeignKey(d => d.HiredUnitStatEmotionId)
                .HasConstraintName("FK__HiredUnit__Hired__7948ECA7");

            entity.HasOne(d => d.HiredUnitStatFeat).WithMany(p => p.HiredUnitStat)
                .HasForeignKey(d => d.HiredUnitStatFeatId)
                .HasConstraintName("FK__HiredUnit__Hired__7A3D10E0");

            entity.HasOne(d => d.HiredUnitStatMagic).WithMany(p => p.HiredUnitStat)
                .HasForeignKey(d => d.HiredUnitStatMagicId)
                .HasConstraintName("FK__HiredUnit__Hired__7760A435");
        });

        modelBuilder.Entity<HiredUnitStatBody>(entity =>
        {
            entity.HasKey(e => e.HiredUnitStatBodyId).HasName("PK__HiredUni__99967EFA12D4AA1F");

            entity.ToTable("HiredUnitStatBody", "Player");

            entity.Property(e => e.HiredUnitStatBodyId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Arteries).HasDefaultValue((byte)0);
            entity.Property(e => e.Brain).HasDefaultValue((byte)0);
            entity.Property(e => e.Butt).HasDefaultValue((byte)0);
            entity.Property(e => e.Chest).HasDefaultValue((byte)0);
            entity.Property(e => e.Genitals).HasDefaultValue((byte)0);
            entity.Property(e => e.Hair).HasDefaultValue((byte)0);
            entity.Property(e => e.Head).HasDefaultValue((byte)0);
            entity.Property(e => e.Heart).HasDefaultValue((byte)0);
            entity.Property(e => e.Larynx).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftEar).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftElbow).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftEye).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftFoot).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftHand).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftKnee).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftLowerArm).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftLowerLeg).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftShoulder).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftUpperArm).HasDefaultValue((byte)0);
            entity.Property(e => e.LeftUpperLeg).HasDefaultValue((byte)0);
            entity.Property(e => e.Lungs).HasDefaultValue((byte)0);
            entity.Property(e => e.Mouth).HasDefaultValue((byte)0);
            entity.Property(e => e.Neck).HasDefaultValue((byte)0);
            entity.Property(e => e.Nose).HasDefaultValue((byte)0);
            entity.Property(e => e.RightEar).HasDefaultValue((byte)0);
            entity.Property(e => e.RightElbow).HasDefaultValue((byte)0);
            entity.Property(e => e.RightEye).HasDefaultValue((byte)0);
            entity.Property(e => e.RightFoot).HasDefaultValue((byte)0);
            entity.Property(e => e.RightHand).HasDefaultValue((byte)0);
            entity.Property(e => e.RightKnee).HasDefaultValue((byte)0);
            entity.Property(e => e.RightLowerArm).HasDefaultValue((byte)0);
            entity.Property(e => e.RightLowerLeg).HasDefaultValue((byte)0);
            entity.Property(e => e.RightShoulder).HasDefaultValue((byte)0);
            entity.Property(e => e.RightUpperArm).HasDefaultValue((byte)0);
            entity.Property(e => e.RightUpperLeg).HasDefaultValue((byte)0);
            entity.Property(e => e.Stomach).HasDefaultValue((byte)0);
            entity.Property(e => e.Teeth).HasDefaultValue((byte)0);
            entity.Property(e => e.Trachea).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<HiredUnitStatCivil>(entity =>
        {
            entity.HasKey(e => e.HiredUnitStatCivilId).HasName("PK__HiredUni__E1F82CE55128B63B");

            entity.ToTable("HiredUnitStatCivil", "Player");

            entity.Property(e => e.HiredUnitStatCivilId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Adaptability).HasDefaultValue((byte)0);
            entity.Property(e => e.Alchemy).HasDefaultValue((byte)0);
            entity.Property(e => e.Artifice).HasDefaultValue((byte)0);
            entity.Property(e => e.Blacksmithing).HasDefaultValue((byte)0);
            entity.Property(e => e.Clothier).HasDefaultValue((byte)0);
            entity.Property(e => e.Cobbling).HasDefaultValue((byte)0);
            entity.Property(e => e.Comedy).HasDefaultValue((byte)0);
            entity.Property(e => e.Construction).HasDefaultValue((byte)0);
            entity.Property(e => e.CriticalThinking).HasDefaultValue((byte)0);
            entity.Property(e => e.Deception).HasDefaultValue((byte)0);
            entity.Property(e => e.Farming).HasDefaultValue((byte)0);
            entity.Property(e => e.Fletching).HasDefaultValue((byte)0);
            entity.Property(e => e.Hatter).HasDefaultValue((byte)0);
            entity.Property(e => e.Horsemanship).HasDefaultValue((byte)0);
            entity.Property(e => e.Leadership).HasDefaultValue((byte)0);
            entity.Property(e => e.Leatherworking).HasDefaultValue((byte)0);
            entity.Property(e => e.Medicine).HasDefaultValue((byte)0);
            entity.Property(e => e.Mining).HasDefaultValue((byte)0);
            entity.Property(e => e.Music).HasDefaultValue((byte)0);
            entity.Property(e => e.Negotiation).HasDefaultValue((byte)0);
            entity.Property(e => e.Painting).HasDefaultValue((byte)0);
            entity.Property(e => e.Persuasion).HasDefaultValue((byte)0);
            entity.Property(e => e.Planning).HasDefaultValue((byte)0);
            entity.Property(e => e.Quarrying).HasDefaultValue((byte)0);
            entity.Property(e => e.Teamwork).HasDefaultValue((byte)0);
            entity.Property(e => e.Woodcutting).HasDefaultValue((byte)0);
            entity.Property(e => e.Writing).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<HiredUnitStatCombat>(entity =>
        {
            entity.HasKey(e => e.HiredUnitStatCombatId).HasName("PK__HiredUni__ACEC443E45128889");

            entity.ToTable("HiredUnitStatCombat", "Player");

            entity.Property(e => e.HiredUnitStatCombatId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Archery).HasDefaultValue((byte)0);
            entity.Property(e => e.DualWielding).HasDefaultValue((byte)0);
            entity.Property(e => e.Dueling).HasDefaultValue((byte)0);
            entity.Property(e => e.HeavyArmor).HasDefaultValue((byte)0);
            entity.Property(e => e.LightArmor).HasDefaultValue((byte)0);
            entity.Property(e => e.LongBlade).HasDefaultValue((byte)0);
            entity.Property(e => e.MeleeDefence).HasDefaultValue((byte)0);
            entity.Property(e => e.RangedDefence).HasDefaultValue((byte)0);
            entity.Property(e => e.Shield).HasDefaultValue((byte)0);
            entity.Property(e => e.ShortBlade).HasDefaultValue((byte)0);
            entity.Property(e => e.Siege).HasDefaultValue((byte)0);
            entity.Property(e => e.Staff).HasDefaultValue((byte)0);
            entity.Property(e => e.ThrownWeapons).HasDefaultValue((byte)0);
            entity.Property(e => e.Unarmed).HasDefaultValue((byte)0);
            entity.Property(e => e.Unarmored).HasDefaultValue((byte)0);
            entity.Property(e => e.Ward).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<HiredUnitStatEmotion>(entity =>
        {
            entity.HasKey(e => e.HiredUnitStatEmotionId).HasName("PK__HiredUni__7DD21A9BAF15B05A");

            entity.ToTable("HiredUnitStatEmotion", "Player");

            entity.Property(e => e.HiredUnitStatEmotionId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Angry).HasDefaultValue((byte)0);
            entity.Property(e => e.Fear).HasDefaultValue((byte)0);
            entity.Property(e => e.Happy).HasDefaultValue((byte)0);
            entity.Property(e => e.Sad).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<HiredUnitStatFeat>(entity =>
        {
            entity.HasKey(e => e.HiredUnitStatFeatId).HasName("PK__HiredUni__97AD709DA82F6A60");

            entity.ToTable("HiredUnitStatFeat", "Player");

            entity.Property(e => e.HiredUnitStatFeatId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.HasNoble).HasDefaultValue(false);
            entity.Property(e => e.HasQuick).HasDefaultValue(false);
            entity.Property(e => e.HasSavant).HasDefaultValue(false);
            entity.Property(e => e.HasSurvivor).HasDefaultValue(false);
        });

        modelBuilder.Entity<HiredUnitStatMagic>(entity =>
        {
            entity.HasKey(e => e.HiredUnitStatMagicId).HasName("PK__HiredUni__E36A5DE782695BC0");

            entity.ToTable("HiredUnitStatMagic", "Player");

            entity.Property(e => e.HiredUnitStatMagicId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Death).HasDefaultValue((byte)0);
            entity.Property(e => e.Life).HasDefaultValue((byte)0);
            entity.Property(e => e.Nature).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__727E838B0DCAB9DD");

            entity.ToTable("Item", "Lookup");

            entity.Property(e => e.ItemId).ValueGeneratedNever();
            entity.Property(e => e.ItemDescription).IsUnicode(false);
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemInventory>(entity =>
        {
            entity.HasKey(e => e.ItemInventoryId).HasName("PK__ItemInve__FCBE0BEBB80AC978");

            entity.ToTable("ItemInventory", "Player");

            entity.Property(e => e.ItemInventoryId).ValueGeneratedNever();

            entity.HasOne(d => d.Item).WithMany(p => p.ItemInventory)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__ItemInven__ItemI__7B9B496D");

            entity.HasOne(d => d.User).WithMany(p => p.ItemInventory)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ItemInven__UserI__7AA72534");
        });

        modelBuilder.Entity<Market>(entity =>
        {
            entity.HasKey(e => e.MarketId).HasName("PK__Market__74B186AFCAB62EDF");

            entity.ToTable("Market", "Economy");

            entity.Property(e => e.MarketId).ValueGeneratedNever();
            entity.Property(e => e.MarketName).IsUnicode(false);
        });

        modelBuilder.Entity<MarketListing>(entity =>
        {
            entity.HasKey(e => e.MarketListingId).HasName("PK__MarketLi__9C448E51BB01E901");

            entity.ToTable("MarketListing", "Economy");

            entity.Property(e => e.MarketListingId).ValueGeneratedNever();

            entity.HasOne(d => d.Item).WithMany(p => p.MarketListing)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__MarketLis__ItemI__005FFE8A");

            entity.HasOne(d => d.ItemInventory).WithMany(p => p.MarketListing)
                .HasForeignKey(d => d.ItemInventoryId)
                .HasConstraintName("FK__MarketLis__ItemI__015422C3");

            entity.HasOne(d => d.Market).WithMany(p => p.MarketListing)
                .HasForeignKey(d => d.MarketId)
                .HasConstraintName("FK__MarketLis__Marke__024846FC");

            entity.HasOne(d => d.User).WithMany(p => p.MarketListing)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__MarketLis__UserI__7F6BDA51");
        });

        modelBuilder.Entity<PersonalityTrait>(entity =>
        {
            entity.HasKey(e => e.PersonalityTraitId).HasName("PK__Personal__0BFA7AD653F27F85");

            entity.ToTable("PersonalityTrait", "Lookup");

            entity.Property(e => e.PersonalityTraitDescription).IsUnicode(false);
            entity.Property(e => e.PersonalityTraitName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Player__1788CC4C4C76720F");

            entity.ToTable("Player", "Player");

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithOne(p => p.Player)
                .HasForeignKey<Player>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Player__UserId__688874F9");
        });

        modelBuilder.Entity<ResearchedTechnology>(entity =>
        {
            entity.HasKey(e => e.ResearchedTechnologyId).HasName("PK__Research__927E67F67B73215E");

            entity.ToTable("ResearchedTechnology", "Player");

            entity.Property(e => e.ResearchedTechnologyId).ValueGeneratedNever();
            entity.Property(e => e.created_at)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Technology).WithMany(p => p.ResearchedTechnology)
                .HasForeignKey(d => d.TechnologyId)
                .HasConstraintName("FK__Researche__Techn__74EE4BDE");

            entity.HasOne(d => d.User).WithMany(p => p.ResearchedTechnology)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Researche__UserI__75E27017");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__Resource__4ED1816FBAC0749D");

            entity.ToTable("Resource", "Lookup");

            entity.Property(e => e.ResourceDescription).IsUnicode(false);
            entity.Property(e => e.ResourceName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ResourceGain>(entity =>
        {
            entity.HasKey(e => e.ResourceGainlId);

            entity.ToTable("ResourceGain", "Player");

            entity.Property(e => e.ResourceGainlId).ValueGeneratedNever();
            entity.Property(e => e.TimeSinceLastGathered).HasColumnType("datetime");

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceGain)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResourceGain_Resource");
        });

        modelBuilder.Entity<ResourceInventory>(entity =>
        {
            entity.HasKey(e => e.ResourceInventoryId).HasName("PK__Resource__CEE028020F468FE7");

            entity.ToTable("ResourceInventory", "Player");

            entity.Property(e => e.ResourceInventoryId).ValueGeneratedNever();

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceInventory)
                .HasForeignKey(d => d.ResourceId)
                .HasConstraintName("FK__ResourceI__Resou__7D8391DF");

            entity.HasOne(d => d.User).WithMany(p => p.ResourceInventory)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ResourceI__UserI__7C8F6DA6");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skill__DFA09187D7FEEF73");

            entity.ToTable("Skill", "Lookup");

            entity.Property(e => e.SkillDescription).IsUnicode(false);
            entity.Property(e => e.SkillName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.HasKey(e => e.TechnologyId).HasName("PK__Technolo__7057015851C40338");

            entity.ToTable("Technology", "Lookup");

            entity.Property(e => e.TechnologyDescription).IsUnicode(false);
            entity.Property(e => e.TechnologyName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__Unit__44F5ECB511F86552");

            entity.ToTable("Unit", "Lookup");

            entity.Property(e => e.UnitDescription).IsUnicode(false);
            entity.Property(e => e.UnitName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Faction).WithMany(p => p.Unit)
                .HasForeignKey(d => d.FactionId)
                .HasConstraintName("FK__Unit__FactionId__04308F6E");
        });

        modelBuilder.Entity<UnitLevel>(entity =>
        {
            entity.HasKey(e => e.UnitLevelId).HasName("PK__UnitLeve__4D7ADE0846F08B2A");

            entity.ToTable("UnitLevel", "Lookup");

            entity.Property(e => e.UnitLevelDescription).IsUnicode(false);
            entity.Property(e => e.UnitLevelName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C250B993E");

            entity.ToTable("User", "Security");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.created_at)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<UserCity>(entity =>
        {
            entity.HasKey(e => e.UserCityId).HasName("PK__UserCity__E130899E8D77B779");

            entity.ToTable("UserCity", "Player");

            entity.Property(e => e.UserCityId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.UserCity)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserCity__UserId__697C9932");
        });

        modelBuilder.Entity<UserCityLeader>(entity =>
        {
            entity.HasKey(e => e.UserCityLeaderId).HasName("PK__UserCity__8EE7BD889452AC41");

            entity.ToTable("UserCityLeader", "Player");

            entity.Property(e => e.UserCityLeaderId).ValueGeneratedNever();

            entity.HasOne(d => d.HiredLeader).WithMany(p => p.UserCityLeader)
                .HasForeignKey(d => d.HiredLeaderId)
                .HasConstraintName("FK__UserCityL__Hired__6B64E1A4");

            entity.HasOne(d => d.UserCity).WithMany(p => p.UserCityLeader)
                .HasForeignKey(d => d.UserCityId)
                .HasConstraintName("FK__UserCityL__UserC__6C5905DD");

            entity.HasOne(d => d.User).WithMany(p => p.UserCityLeader)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserCityL__UserI__6A70BD6B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}