CREATE SCHEMA [Security]
GO

CREATE SCHEMA [Identity]
GO

CREATE SCHEMA [Economy]
GO

CREATE SCHEMA [Lookup]
GO

CREATE TABLE [Security].[Users] (
  [UserId] uniqueidentifier PRIMARY KEY,
  [created_at] timestamp
)
GO

CREATE TABLE [Identity].[Friends] (
  [UserId] uniqueidentifier PRIMARY KEY,
  [FriendsWith] uniqueidentifier
)
GO

CREATE TABLE [Identity].[ResearchedTechnology] (
  [ResearchedTechnologyId] uniqueidentifier,
  [TechnologyId] int,
  [created_at] timestamp
)
GO

CREATE TABLE [Identity].[ConstructedBuildings] (
  [ConstructuredBuildingId] uniqueidentifier PRIMARY KEY,
  [BuildingId] int,
  [UserId] uniqueidentifier,
  [BuildingLevel] int,
  [created_at] timestamp
)
GO

CREATE TABLE [Identity].[HiredUnits] (
  [HiredUnitId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [UnitId] int,
  [UnitLevel] int,
  [created_at] timestamp
)
GO

CREATE TABLE [Identity].[HiredLeaders] (
  [HiredLeaderId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [HiredLeaderName] varchar(24)
)
GO

CREATE TABLE [Identity].[ItemInventory] (
  [ItemInventoryId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [ItemId] uniqueidentifier,
  [Quantity] bigint,
  [MaxInventory] bigint
)
GO

CREATE TABLE [Identity].[ResourceInventory] (
  [ResourceInventoryId] uniqueidentifier PRIMARY KEY,
  [UserId] uniqueidentifier,
  [ResourceId] int,
  [Quantity] bigint
)
GO

CREATE TABLE [Economy].[Markets] (
  [MarketId] uniqueidentifier PRIMARY KEY,
  [MarketCoordinatesX] bigint,
  [MarketCoordinatesY] bigint,
  [MarketRadius] int,
  [MarketName] varchar(max),
  [IsMainMarket] bit
)
GO

CREATE TABLE [Economy].[MarketListings] (
  [ListingId] uniqueidentifier PRIMARY KEY,
  [MarketId] uniqueidentifier,
  [ItemId] uniqueidentifier,
  [UserId] uniqueidentifier,
  [ItemInventoryId] uniqueidentifier,
  [ItemQuantity] bigint
)
GO

CREATE TABLE [Lookup].[Resources] (
  [ResourceId] int PRIMARY KEY,
  [ResourceName] varchar(100)
)
GO

CREATE TABLE [Lookup].[Items] (
  [ItemId] uniqueidentifier PRIMARY KEY,
  [ItemName] varchar(100),
  [ItemDescription] varchar(max)
)
GO

CREATE TABLE [Lookup].[Buildings] (
  [BuildingId] int PRIMARY KEY,
  [BuildingName] varchar(max),
  [FactionId] int
)
GO

CREATE TABLE [Lookup].[Units] (
  [UnitId] int PRIMARY KEY,
  [UnitName] varchar(max),
  [FactionId] int,
  [Health] int,
  [Attack] int,
  [Defense] int
)
GO

CREATE TABLE [Lookup].[UnitLevels] (
  [UnitLevelId] int PRIMARY KEY,
  [UnitRankName] varchar(max)
)
GO

CREATE TABLE [Lookup].[BuildingsLevels] (
  [BuildingLevelId] int PRIMARY KEY,
  [BuildingRankName] varchar(max)
)
GO

CREATE TABLE [Lookup].[Factions] (
  [FactionId] int PRIMARY KEY,
  [FactionName] varchar(max)
)
GO

CREATE TABLE [Lookup].[Technology] (
  [TechnologyId] int PRIMARY KEY,
  [TechnologyName] varchar(max)
)
GO

ALTER TABLE [Identity].[ConstructedBuildings] ADD FOREIGN KEY ([BuildingId]) REFERENCES [Lookup].[Buildings] ([BuildingId])
GO

ALTER TABLE [Identity].[ConstructedBuildings] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[Users] ([UserId])
GO

ALTER TABLE [Identity].[ConstructedBuildings] ADD FOREIGN KEY ([BuildingLevel]) REFERENCES [Lookup].[BuildingsLevels] ([BuildingLevelId])
GO

ALTER TABLE [Identity].[ResearchedTechnology] ADD FOREIGN KEY ([TechnologyId]) REFERENCES [Lookup].[Technology] ([TechnologyId])
GO

ALTER TABLE [Identity].[HiredUnits] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[Users] ([UserId])
GO

ALTER TABLE [Identity].[HiredUnits] ADD FOREIGN KEY ([UnitId]) REFERENCES [Lookup].[Units] ([UnitId])
GO

ALTER TABLE [Identity].[HiredUnits] ADD FOREIGN KEY ([UnitLevel]) REFERENCES [Lookup].[UnitLevels] ([UnitLevelId])
GO

ALTER TABLE [Identity].[HiredLeaders] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[Users] ([UserId])
GO

ALTER TABLE [Identity].[ItemInventory] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[Users] ([UserId])
GO

ALTER TABLE [Identity].[ItemInventory] ADD FOREIGN KEY ([ItemId]) REFERENCES [Lookup].[Items] ([ItemId])
GO

ALTER TABLE [Identity].[ResourceInventory] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[Users] ([UserId])
GO

ALTER TABLE [Identity].[ResourceInventory] ADD FOREIGN KEY ([ResourceId]) REFERENCES [Lookup].[Resources] ([ResourceId])
GO

ALTER TABLE [Identity].[Friends] ADD FOREIGN KEY ([FriendsWith]) REFERENCES [Security].[Users] ([UserId])
GO

ALTER TABLE [Economy].[MarketListings] ADD FOREIGN KEY ([UserId]) REFERENCES [Security].[Users] ([UserId])
GO

ALTER TABLE [Economy].[MarketListings] ADD FOREIGN KEY ([ItemId]) REFERENCES [Lookup].[Items] ([ItemId])
GO

ALTER TABLE [Economy].[MarketListings] ADD FOREIGN KEY ([ItemInventoryId]) REFERENCES [Identity].[ItemInventory] ([ItemInventoryId])
GO

ALTER TABLE [Economy].[MarketListings] ADD FOREIGN KEY ([MarketId]) REFERENCES [Economy].[Markets] ([MarketId])
GO

ALTER TABLE [Lookup].[Buildings] ADD FOREIGN KEY ([FactionId]) REFERENCES [Lookup].[Factions] ([FactionId])
GO

ALTER TABLE [Lookup].[Units] ADD FOREIGN KEY ([FactionId]) REFERENCES [Lookup].[Factions] ([FactionId])
GO
