USE [master]
GO
/****** Object:  Database [Abio]    Script Date: 11/28/2023 7:42:12 PM ******/
CREATE DATABASE [Abio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Abio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Abio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Abio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Abio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Abio] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Abio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Abio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Abio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Abio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Abio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Abio] SET ARITHABORT OFF 
GO
ALTER DATABASE [Abio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Abio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Abio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Abio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Abio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Abio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Abio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Abio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Abio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Abio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Abio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Abio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Abio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Abio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Abio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Abio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Abio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Abio] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Abio] SET  MULTI_USER 
GO
ALTER DATABASE [Abio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Abio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Abio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Abio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Abio] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Abio] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Abio] SET QUERY_STORE = ON
GO
ALTER DATABASE [Abio] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Abio]
GO
/****** Object:  Schema [Economy]    Script Date: 11/28/2023 7:42:12 PM ******/
CREATE SCHEMA [Economy]
GO
/****** Object:  Schema [Lookup]    Script Date: 11/28/2023 7:42:12 PM ******/
CREATE SCHEMA [Lookup]
GO
/****** Object:  Schema [Player]    Script Date: 11/28/2023 7:42:12 PM ******/
CREATE SCHEMA [Player]
GO
/****** Object:  Schema [Security]    Script Date: 11/28/2023 7:42:12 PM ******/
CREATE SCHEMA [Security]
GO
/****** Object:  Table [Economy].[Market]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Economy].[Market](
	[MarketId] [uniqueidentifier] NOT NULL,
	[MarketCoordinatesX] [bigint] NULL,
	[MarketCoordinatesY] [bigint] NULL,
	[MarketRadius] [int] NULL,
	[MarketName] [varchar](max) NULL,
	[IsMainMarket] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MarketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Economy].[MarketListing]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Economy].[MarketListing](
	[MarketListingId] [uniqueidentifier] NOT NULL,
	[MarketId] [uniqueidentifier] NULL,
	[ItemId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[ItemInventoryId] [uniqueidentifier] NULL,
	[ItemQuantity] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[MarketListingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Attribute]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Attribute](
	[AttributeId] [int] IDENTITY(1,1) NOT NULL,
	[AttributeName] [varchar](100) NULL,
	[AttributeDescription] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[BodyPart]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[BodyPart](
	[BodyPartId] [int] IDENTITY(1,1) NOT NULL,
	[BodyPartName] [varchar](100) NULL,
	[BodyPartDescription] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[BodyPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Building]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Building](
	[BuildingId] [uniqueidentifier] NOT NULL,
	[BuildingName] [varchar](max) NULL,
	[FactionId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[BuildingLevel]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[BuildingLevel](
	[BuildingLevelId] [uniqueidentifier] NOT NULL,
	[BuildingRankName] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[BuildingLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Emotion]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Emotion](
	[EmotionId] [int] IDENTITY(1,1) NOT NULL,
	[EmotionName] [varchar](100) NULL,
	[EmotionDescription] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Faction]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Faction](
	[FactionId] [uniqueidentifier] NOT NULL,
	[FactionName] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[FactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Feat]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Feat](
	[FeatId] [int] IDENTITY(1,1) NOT NULL,
	[FeatName] [varchar](100) NULL,
	[FeatDescription] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[FeatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Item]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Item](
	[ItemId] [uniqueidentifier] NOT NULL,
	[ItemName] [varchar](100) NULL,
	[ItemDescription] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[PersonalityTrait]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[PersonalityTrait](
	[PersonalityTraitId] [int] IDENTITY(1,1) NOT NULL,
	[PersonalityTraitName] [varchar](100) NULL,
	[PersonalityTraitDescription] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonalityTraitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Resource]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Resource](
	[ResourceId] [uniqueidentifier] NOT NULL,
	[ResourceName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Skill]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Skill](
	[SkillId] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [varchar](100) NULL,
	[SkillDescription] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Technology]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Technology](
	[TechnologyId] [uniqueidentifier] NOT NULL,
	[TechnologyName] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[TechnologyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[Unit]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[Unit](
	[UnitId] [uniqueidentifier] NOT NULL,
	[UnitName] [varchar](max) NULL,
	[FactionId] [uniqueidentifier] NULL,
	[Health] [int] NULL,
	[Attack] [int] NULL,
	[Defense] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[UnitLevel]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lookup].[UnitLevel](
	[UnitLevelId] [uniqueidentifier] NOT NULL,
	[UnitRankName] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[UnitLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Player].[ConstructedBuilding]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[ConstructedBuilding](
	[ConstructedBuildingId] [uniqueidentifier] NOT NULL,
	[BuildingId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[BuildingLevelId] [uniqueidentifier] NULL,
	[created_at] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ConstructedBuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[Friend]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[Friend](
	[UserId] [uniqueidentifier] NOT NULL,
	[FriendsWith] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[HiredLeader]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[HiredLeader](
	[HiredLeaderId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[HiredLeaderName] [varchar](24) NULL,
	[LeaderStatId] [uniqueidentifier] NULL,
	[created_at] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HiredLeaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[HiredLeaderStat]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[HiredLeaderStat](
	[HiredLeaderStatId] [uniqueidentifier] NOT NULL,
	[HiredLeaderId] [uniqueidentifier] NULL,
	[Leadership] [int] NULL,
	[Attack] [int] NULL,
	[Defense] [int] NULL,
	[Construction] [int] NULL,
	[ResourceProduction] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HiredLeaderStatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[HiredUnit]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[HiredUnit](
	[HiredUnitId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[UnitId] [uniqueidentifier] NULL,
	[UnitLevelId] [uniqueidentifier] NULL,
	[HiredLeaderId] [uniqueidentifier] NULL,
	[created_at] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HiredUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[HiredUnitStat]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[HiredUnitStat](
	[HiredUnitStatId] [uniqueidentifier] NOT NULL,
	[HiredUnitId] [uniqueidentifier] NULL,
	[Leadership] [int] NULL,
	[Attack] [int] NULL,
	[Defense] [int] NULL,
	[MovementSpeed] [int] NULL,
	[AttackSpeed] [int] NULL,
	[MeleeRange] [int] NULL,
	[RangedRange] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HiredUnitStatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[ItemInventory]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[ItemInventory](
	[ItemInventoryId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[ItemId] [uniqueidentifier] NULL,
	[Quantity] [bigint] NULL,
	[MaxInventory] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemInventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[Player]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[Player](
	[UserId] [uniqueidentifier] NOT NULL,
	[MaxCities] [int] NULL,
	[MaxOwnedLand] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[ResearchedTechnology]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[ResearchedTechnology](
	[ResearchedTechnologyId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[TechnologyId] [uniqueidentifier] NULL,
	[created_at] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ResearchedTechnologyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[ResourceInventory]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[ResourceInventory](
	[ResourceInventoryId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[ResourceId] [uniqueidentifier] NULL,
	[Quantity] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ResourceInventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[UnitGroup]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[UnitGroup](
	[UnitGroupId] [uniqueidentifier] NOT NULL,
	[HiredUnitId] [uniqueidentifier] NULL,
	[HiredLeaderId] [uniqueidentifier] NULL,
	[GroupNumber] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UnitGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[UserCity]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[UserCity](
	[UserCityId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[XCoord] [int] NULL,
	[YCoord] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserCityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Player].[UserCityLeader]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Player].[UserCityLeader](
	[UserCityLeaderId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[HiredLeaderId] [uniqueidentifier] NULL,
	[UserCityId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserCityLeaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Security].[User]    Script Date: 11/28/2023 7:42:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Security].[User](
	[UserId] [uniqueidentifier] NOT NULL,
	[created_at] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Economy].[Market] ADD  DEFAULT (newid()) FOR [MarketId]
GO
ALTER TABLE [Economy].[MarketListing] ADD  DEFAULT (newid()) FOR [MarketListingId]
GO
ALTER TABLE [Lookup].[Building] ADD  DEFAULT (newid()) FOR [BuildingId]
GO
ALTER TABLE [Lookup].[BuildingLevel] ADD  DEFAULT (newid()) FOR [BuildingLevelId]
GO
ALTER TABLE [Lookup].[Faction] ADD  DEFAULT (newid()) FOR [FactionId]
GO
ALTER TABLE [Lookup].[Item] ADD  DEFAULT (newid()) FOR [ItemId]
GO
ALTER TABLE [Lookup].[Resource] ADD  DEFAULT (newid()) FOR [ResourceId]
GO
ALTER TABLE [Lookup].[Technology] ADD  DEFAULT (newid()) FOR [TechnologyId]
GO
ALTER TABLE [Lookup].[Unit] ADD  DEFAULT (newid()) FOR [UnitId]
GO
ALTER TABLE [Lookup].[UnitLevel] ADD  DEFAULT (newid()) FOR [UnitLevelId]
GO
ALTER TABLE [Player].[ConstructedBuilding] ADD  DEFAULT (newid()) FOR [ConstructedBuildingId]
GO
ALTER TABLE [Player].[Friend] ADD  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [Player].[HiredLeader] ADD  DEFAULT (newid()) FOR [HiredLeaderId]
GO
ALTER TABLE [Player].[HiredLeaderStat] ADD  DEFAULT (newid()) FOR [HiredLeaderStatId]
GO
ALTER TABLE [Player].[HiredUnit] ADD  DEFAULT (newid()) FOR [HiredUnitId]
GO
ALTER TABLE [Player].[HiredUnitStat] ADD  DEFAULT (newid()) FOR [HiredUnitStatId]
GO
ALTER TABLE [Player].[ItemInventory] ADD  DEFAULT (newid()) FOR [ItemInventoryId]
GO
ALTER TABLE [Player].[Player] ADD  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [Player].[ResearchedTechnology] ADD  DEFAULT (newid()) FOR [ResearchedTechnologyId]
GO
ALTER TABLE [Player].[ResourceInventory] ADD  DEFAULT (newid()) FOR [ResourceInventoryId]
GO
ALTER TABLE [Player].[UnitGroup] ADD  DEFAULT (newid()) FOR [UnitGroupId]
GO
ALTER TABLE [Player].[UserCity] ADD  DEFAULT (newid()) FOR [UserCityId]
GO
ALTER TABLE [Player].[UserCityLeader] ADD  DEFAULT (newid()) FOR [UserCityLeaderId]
GO
ALTER TABLE [Security].[User] ADD  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [Economy].[MarketListing]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [Lookup].[Item] ([ItemId])
GO
ALTER TABLE [Economy].[MarketListing]  WITH CHECK ADD FOREIGN KEY([ItemInventoryId])
REFERENCES [Player].[ItemInventory] ([ItemInventoryId])
GO
ALTER TABLE [Economy].[MarketListing]  WITH CHECK ADD FOREIGN KEY([MarketId])
REFERENCES [Economy].[Market] ([MarketId])
GO
ALTER TABLE [Economy].[MarketListing]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Lookup].[Building]  WITH CHECK ADD FOREIGN KEY([FactionId])
REFERENCES [Lookup].[Faction] ([FactionId])
GO
ALTER TABLE [Lookup].[Unit]  WITH CHECK ADD FOREIGN KEY([FactionId])
REFERENCES [Lookup].[Faction] ([FactionId])
GO
ALTER TABLE [Player].[ConstructedBuilding]  WITH CHECK ADD FOREIGN KEY([BuildingId])
REFERENCES [Lookup].[Building] ([BuildingId])
GO
ALTER TABLE [Player].[ConstructedBuilding]  WITH CHECK ADD FOREIGN KEY([BuildingLevelId])
REFERENCES [Lookup].[BuildingLevel] ([BuildingLevelId])
GO
ALTER TABLE [Player].[ConstructedBuilding]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Player].[Friend]  WITH CHECK ADD FOREIGN KEY([FriendsWith])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Player].[HiredLeader]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Player].[HiredLeaderStat]  WITH CHECK ADD FOREIGN KEY([HiredLeaderId])
REFERENCES [Player].[HiredLeader] ([HiredLeaderId])
GO
ALTER TABLE [Player].[HiredUnit]  WITH CHECK ADD FOREIGN KEY([HiredLeaderId])
REFERENCES [Player].[HiredLeader] ([HiredLeaderId])
GO
ALTER TABLE [Player].[HiredUnit]  WITH CHECK ADD FOREIGN KEY([UnitId])
REFERENCES [Lookup].[Unit] ([UnitId])
GO
ALTER TABLE [Player].[HiredUnit]  WITH CHECK ADD FOREIGN KEY([UnitLevelId])
REFERENCES [Lookup].[UnitLevel] ([UnitLevelId])
GO
ALTER TABLE [Player].[HiredUnit]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Player].[HiredUnitStat]  WITH CHECK ADD FOREIGN KEY([HiredUnitId])
REFERENCES [Player].[HiredUnit] ([HiredUnitId])
GO
ALTER TABLE [Player].[ItemInventory]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [Lookup].[Item] ([ItemId])
GO
ALTER TABLE [Player].[ItemInventory]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Player].[Player]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Player].[ResearchedTechnology]  WITH CHECK ADD FOREIGN KEY([TechnologyId])
REFERENCES [Lookup].[Technology] ([TechnologyId])
GO
ALTER TABLE [Player].[ResearchedTechnology]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Player].[ResourceInventory]  WITH CHECK ADD FOREIGN KEY([ResourceId])
REFERENCES [Lookup].[Resource] ([ResourceId])
GO
ALTER TABLE [Player].[ResourceInventory]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Player].[UnitGroup]  WITH CHECK ADD FOREIGN KEY([HiredUnitId])
REFERENCES [Player].[HiredUnit] ([HiredUnitId])
GO
ALTER TABLE [Player].[UnitGroup]  WITH CHECK ADD FOREIGN KEY([HiredLeaderId])
REFERENCES [Player].[HiredLeader] ([HiredLeaderId])
GO
ALTER TABLE [Player].[UserCity]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Player].[UserCityLeader]  WITH CHECK ADD FOREIGN KEY([HiredLeaderId])
REFERENCES [Player].[HiredLeader] ([HiredLeaderId])
GO
ALTER TABLE [Player].[UserCityLeader]  WITH CHECK ADD FOREIGN KEY([UserCityId])
REFERENCES [Player].[UserCity] ([UserCityId])
GO
ALTER TABLE [Player].[UserCityLeader]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
USE [master]
GO
ALTER DATABASE [Abio] SET  READ_WRITE 
GO
