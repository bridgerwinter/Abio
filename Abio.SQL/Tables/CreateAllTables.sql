CREATE SCHEMA [Security]
GO

CREATE SCHEMA [Player]
GO

CREATE SCHEMA [Economy]
GO

CREATE SCHEMA [Lookup]
GO

CREATE TABLE [Security].[User] (
  [UserId] uniqueidentifier PRIMARY KEY,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[Friend] (
  [UserId] uniqueidentifier PRIMARY KEY,
  [FriendsWith] uniqueidentifier
)
GO

CREATE TABLE [Player].[Player] (
  [UserId] uniqueidentifier PRIMARY KEY,
  [MaxCities] int,
  [MaxOwnedLand] int
)
GO

CREATE TABLE [Player].[UserCity] (
  [UserCityId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [XCoord] int,
  [YCoord] int
)
GO

CREATE TABLE [Player].[UserCityLeader] (
  [UserCityLeaderId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [HiredLeaderId] uniqueidentifier,
  [UserCityId] uniqueidentifier
)
GO

CREATE TABLE [Player].[ResearchedTechnology] (
  [ResearchedTechnologyId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [TechnologyId] int,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[ConstructedBuilding] (
  [ConstructedBuildingId] uniqueidentifier PRIMARY KEY,
  [BuildingId] int,
  [UserId] uniqueidentifier,
  [BuildingLevel] int,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[HiredUnit] (
  [HiredUnitId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [UnitId] int,
  [UnitLevel] int,
  [HiredLeaderId] uniqueidentifier,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[HiredUnitStat] (
  [HiredUnitStatId] uniqueidentifier PRIMARY KEY,
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
  [HiredLeaderId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [HiredLeaderName] varchar(24),
  [LeaderStatId] uniqueidentifier,
  [created_at] timestamp
)
GO

CREATE TABLE [Player].[HiredLeaderStat] (
  [HiredLeaderStatId] uniqueidentifier PRIMARY KEY,
  [HiredLeaderId] uniqueidentifier,
  [Leadership] int,
  [Attack] int,
  [Defense] int,
  [Construction] int,
  [ResourceProduction] int
)
GO

CREATE TABLE [Player].[UnitGroup] (
  [UnitGroupId] uniqueidentifier PRIMARY KEY,
  [HiredUnitId] uniqueidentifier,
  [HiredLeaderId] uniqueidentifier,
  [GroupNumber] int
)
GO

CREATE TABLE [Player].[ItemInventory] (
  [ItemInventoryId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [ItemId] uniqueidentifier,
  [Quantity] bigint,
  [MaxInventory] bigint
)
GO

CREATE TABLE [Player].[ResourceInventory] (
  [ResourceInventoryId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [ResourceId] int,
  [Quantity] bigint
)
GO

CREATE TABLE [Economy].[Market] (
  [MarketId] uniqueidentifier PRIMARY KEY,
  [MarketCoordinatesX] bigint,
  [MarketCoordinatesY] bigint,
  [MarketRadius] int,
  [MarketName] varchar(max),
  [IsMainMarket] bit
)
GO

CREATE TABLE [Economy].[MarketListing] (
  [MarketListingId] uniqueidentifier PRIMARY KEY,
  [MarketId] uniqueidentifier,
  [ItemId] uniqueidentifier,
  [UserId] uniqueidentifier,
  [ItemInventoryId] uniqueidentifier,
  [ItemQuantity] bigint
)
GO

CREATE TABLE [Lookup].[Resource] (
  [ResourceId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [ResourceName] varchar(100)
)
GO

CREATE TABLE [Lookup].[Item] (
  [ItemId] uniqueidentifier PRIMARY KEY,
  [ItemName] varchar(100),
  [ItemDescription] varchar(max)
)
GO

CREATE TABLE [Lookup].[Building] (
  [BuildingId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [BuildingName] varchar(max),
  [FactionId] int
)
GO

CREATE TABLE [Lookup].[Unit] (
  [UnitId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [UnitName] varchar(max),
  [FactionId] int,
  [Health] int,
  [Attack] int,
  [Defense] int
)
GO

CREATE TABLE [Lookup].[UnitLevel] (
  [UnitLevelId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [UnitRankName] varchar(max)
)
GO

CREATE TABLE [Lookup].[BuildingLevel] (
  [BuildingLevelId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [BuildingRankName] varchar(max)
)
GO

CREATE TABLE [Lookup].[Faction] (
  [FactionId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [FactionName] varchar(max)
)
GO

CREATE TABLE [Lookup].[Technology] (
  [TechnologyId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
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

ALTER TABLE [Player].[ConstructedBuilding] ADD FOREIGN KEY ([BuildingLevel]) REFERENCES [Lookup].[BuildingLevel] ([BuildingLevelId])
GO

ALTER TABLE [Player].[ResearchedTechnology] ADD FOREIGN KEY ([TechnologyId]) REFERENCES [Lookup].[Technology] ([TechnologyId])
GO

ALTER TABLE [Player].[ResearchedTechnology] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[HiredUnit] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([UserId])
GO

ALTER TABLE [Player].[HiredUnit] ADD FOREIGN KEY ([UnitId]) REFERENCES [Lookup].[Unit] ([UnitId])
GO

ALTER TABLE [Player].[HiredUnit] ADD FOREIGN KEY ([UnitLevel]) REFERENCES [Lookup].[UnitLevel] ([UnitLevelId])
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
