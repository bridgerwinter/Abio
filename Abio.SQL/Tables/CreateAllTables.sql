CREATE SCHEMA [Security]
GO

CREATE SCHEMA [Player]
GO

CREATE SCHEMA [Economy]
GO

CREATE SCHEMA [Lookup]
GO

CREATE TABLE [Security].[User] (
  [UserId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[Friend] (
  [UserId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [FriendsWith] uniqueidentifier
)
GO

CREATE TABLE [Player].[Player] (
  [UserId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [MaxCities] int,
  [MaxOwnedLand] int
)
GO

CREATE TABLE [Player].[UserCity] (
  [UserCityId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [UserId] uniqueidentifier,
  [XCoord] int,
  [YCoord] int
)
GO

CREATE TABLE [Player].[UserCityLeader] (
  [UserCityLeaderId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [UserId] uniqueidentifier,
  [HiredLeaderId] uniqueidentifier,
  [UserCityId] uniqueidentifier
)
GO

CREATE TABLE [Player].[ResearchedTechnology] (
  [ResearchedTechnologyId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [UserId] uniqueidentifier,
  [TechnologyId] uniqueidentifier,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[ConstructedBuilding] (
  [ConstructedBuildingId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [BuildingId] uniqueidentifier,
  [UserId] uniqueidentifier,
  [BuildingLevelId] uniqueidentifier,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[HiredUnit] (
  [HiredUnitId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [UserId] uniqueidentifier,
  [UnitId] uniqueidentifier,
  [UnitLevelId] uniqueidentifier,
  [HiredLeaderId] uniqueidentifier,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[HiredUnitStat] (
  [HiredUnitStatId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [HiredUnitId] uniqueidentifier,
  [Leadership] int,
  [Attack] int,
  [Defense] int,
  [MovementSpeed] int,
  [AttackSpeed] int,
  [MeleeRange] int,
  [RangedRange] int
)
GO

CREATE TABLE [Player].[HiredLeader] (
  [HiredLeaderId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [UserId] uniqueidentifier,
  [HiredLeaderName] varchar(24),
  [LeaderStatId] uniqueidentifier,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[HiredLeaderStat] (
  [HiredLeaderStatId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [HiredLeaderId] uniqueidentifier,
  [Leadership] int,
  [Attack] int,
  [Defense] int,
  [Construction] int,
  [ResourceProduction] int
)
GO

CREATE TABLE [Player].[UnitGroup] (
  [UnitGroupId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [HiredUnitId] uniqueidentifier,
  [HiredLeaderId] uniqueidentifier,
  [GroupNumber] int
)
GO

CREATE TABLE [Player].[ItemInventory] (
  [ItemInventoryId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [UserId] uniqueidentifier,
  [ItemId] uniqueidentifier,
  [Quantity] bigint,
  [MaxInventory] bigint
)
GO

CREATE TABLE [Player].[ResourceInventory] (
  [ResourceInventoryId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [UserId] uniqueidentifier,
  [ResourceId] uniqueidentifier,
  [Quantity] bigint
)
GO

CREATE TABLE [Economy].[Market] (
  [MarketId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [MarketCoordinatesX] bigint,
  [MarketCoordinatesY] bigint,
  [MarketRadius] int,
  [MarketName] varchar(max),
  [IsMainMarket] bit
)
GO

CREATE TABLE [Economy].[MarketListing] (
  [MarketListingId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [MarketId] uniqueidentifier,
  [ItemId] uniqueidentifier,
  [UserId] uniqueidentifier,
  [ItemInventoryId] uniqueidentifier,
  [ItemQuantity] bigint
)
GO

CREATE TABLE [Lookup].[Resource] (
  [ResourceId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [ResourceName] varchar(100)
)
GO

CREATE TABLE [Lookup].[Item] (
  [ItemId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [ItemName] varchar(100),
  [ItemDescription] varchar(max)
)
GO

CREATE TABLE [Lookup].[Building] (
  [BuildingId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [BuildingName] varchar(max),
  [FactionId] uniqueidentifier,
)
GO

CREATE TABLE [Lookup].[Unit] (
  [UnitId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [UnitName] varchar(max),
  [FactionId] uniqueidentifier,
  [Health] int,
  [Attack] int,
  [Defense] int
)
GO

CREATE TABLE [Lookup].[UnitLevel] (
  [UnitLevelId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [UnitRankName] varchar(max)
)
GO

CREATE TABLE [Lookup].[BuildingLevel] (
  [BuildingLevelId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [BuildingRankName] varchar(max)
)
GO

CREATE TABLE [Lookup].[Faction] (
  [FactionId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [FactionName] varchar(max)
)
GO

CREATE TABLE [Lookup].[Technology] (
  [TechnologyId] uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
  [TechnologyName] varchar(max)
)
GO

ALTER TABLE [Player].[Player] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[UserCity] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[UserCityLeader] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[UserCityLeader] ADD FOREIGN KEY ([HiredLeaderId]) REFERENCES [Player].[HiredLeader] ([HiredLeaderId])
GO

ALTER TABLE [Player].[UserCityLeader] ADD FOREIGN KEY ([UserCityId]) REFERENCES [Player].[UserCity] ([UserCityId])
GO

ALTER TABLE [Player].[HiredUnit] ADD FOREIGN KEY ([HiredLeaderId]) REFERENCES [Player].[HiredLeader] ([HiredLeaderId])
GO

ALTER TABLE [Player].[HiredUnitStat] ADD FOREIGN KEY ([HiredUnitId]) REFERENCES [Player].[HiredUnit] ([HiredUnitId])
GO

ALTER TABLE [Player].[HiredLeaderStat] ADD FOREIGN KEY ([HiredLeaderId]) REFERENCES [Player].[HiredLeader] ([HiredLeaderId])
GO

ALTER TABLE [Player].[UnitGroup] ADD FOREIGN KEY ([HiredUnitId]) REFERENCES [Player].[HiredUnit] ([HiredUnitId])
GO

ALTER TABLE [Player].[UnitGroup] ADD FOREIGN KEY ([HiredLeaderId]) REFERENCES [Player].[HiredLeader] ([HiredLeaderId])
GO

ALTER TABLE [Player].[ConstructedBuilding] ADD FOREIGN KEY ([BuildingId]) REFERENCES [Lookup].[Building] ([BuildingId])
GO

ALTER TABLE [Player].[ConstructedBuilding] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[ConstructedBuilding] ADD FOREIGN KEY ([BuildingLevelId]) REFERENCES [Lookup].[BuildingLevel] ([BuildingLevelId])
GO

ALTER TABLE [Player].[ResearchedTechnology] ADD FOREIGN KEY ([TechnologyId]) REFERENCES [Lookup].[Technology] ([TechnologyId])
GO

ALTER TABLE [Player].[ResearchedTechnology] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[HiredUnit] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[HiredUnit] ADD FOREIGN KEY ([UnitId]) REFERENCES [Lookup].[Unit] ([UnitId])
GO

ALTER TABLE [Player].[HiredUnit] ADD FOREIGN KEY ([UnitLevelId]) REFERENCES [Lookup].[UnitLevel] ([UnitLevelId])
GO

ALTER TABLE [Player].[HiredLeader] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[ItemInventory] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[ItemInventory] ADD FOREIGN KEY ([ItemId]) REFERENCES [Lookup].[Item] ([ItemId])
GO

ALTER TABLE [Player].[ResourceInventory] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[ResourceInventory] ADD FOREIGN KEY ([ResourceId]) REFERENCES [Lookup].[Resource] ([ResourceId])
GO

ALTER TABLE [Player].[Friend] ADD FOREIGN KEY ([FriendsWith]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Economy].[MarketListing] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Economy].[MarketListing] ADD FOREIGN KEY ([ItemId]) REFERENCES [Lookup].[Item] ([ItemId])
GO

ALTER TABLE [Economy].[MarketListing] ADD FOREIGN KEY ([ItemInventoryId]) REFERENCES [Player].[ItemInventory] ([ItemInventoryId])
GO

ALTER TABLE [Economy].[MarketListing] ADD FOREIGN KEY ([MarketId]) REFERENCES [Economy].[Market] ([MarketId])
GO

ALTER TABLE [Lookup].[Building] ADD FOREIGN KEY ([FactionId]) REFERENCES [Lookup].[Faction] ([FactionId])
GO

ALTER TABLE [Lookup].[Unit] ADD FOREIGN KEY ([FactionId]) REFERENCES [Lookup].[Faction] ([FactionId])
GO
