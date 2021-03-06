SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FarmSubs]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[FarmSubs](
	[Crop] [nvarchar](50) NOT NULL,
	[Ammount] [int] NOT NULL,
	[As_Of] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_FarmSubs] PRIMARY KEY CLUSTERED 
(
	[Crop] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Cropsales]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Cropsales](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TransactionID] [varchar](50) NOT NULL,
	[Crop] [nvarchar](50) NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[Tonne_Sold] [int] NOT NULL,
 CONSTRAINT [PK_Cropsales] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[customerhq]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customerhq](
	[Id] [int] NOT NULL,
	[Product] [nvarchar](50) NOT NULL,
	[Customer_ID] [nvarchar](50) NOT NULL,
	[First_Name] [nvarchar](50) NOT NULL,
	[Last_Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[MOP] [nvarchar](50) NOT NULL,
	[DOR] [smalldatetime] NOT NULL,
	[Registered_By] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_customerhq] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantationOrder]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[PlantationOrder](
	[CustomerId] [varchar](50) NOT NULL,
	[Crop] [varchar](50) NOT NULL,
	[Demand_(Tonnes)] [int] NOT NULL,
	[Period_Begining] [smalldatetime] NOT NULL,
	[Period_ending] [smalldatetime] NOT NULL,
	[Demanded_on] [smalldatetime] NOT NULL,
	[Registrar] [char](50) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[MilkOrder]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[MilkOrder](
	[CustomerID] [nvarchar](50) NOT NULL,
	[Demand] [int] NOT NULL,
	[STD] [smalldatetime] NOT NULL,
	[STTPD] [smalldatetime] NOT NULL,
	[Registrar] [nvarchar](50) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[AnimalHQ]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[AnimalHQ](
	[ID] [int] NOT NULL,
	[TagID] [nvarchar](15) NOT NULL,
	[Animal_Name] [nvarchar](50) NOT NULL,
	[Breed] [nvarchar](10) NOT NULL,
	[Sex] [nvarchar](10) NOT NULL,
	[Parent] [nvarchar](50) NOT NULL,
	[DOB] [smalldatetime] NOT NULL,
	[DOR] [smalldatetime] NOT NULL,
	[Registered_by] [nvarchar](15) NOT NULL,
	[Current_Condition] [nvarchar](10) NOT NULL,
	[age]  AS (datediff(day,[dob],getdate())),
	[Source] [int] NULL,
 CONSTRAINT [PK_AnimalHQ] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Depart]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Depart](
	[Dept] [nvarchar](50) NOT NULL,
	[Sub] [nvarchar](50) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PrivStaffHQ]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[PrivStaffHQ](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SysID] [nvarchar](50) NOT NULL,
	[First_Name] [nvarchar](50) NOT NULL,
	[Last_Name] [nvarchar](50) NOT NULL,
	[National_ID] [char](10) NOT NULL,
	[DOE] [smalldatetime] NOT NULL,
	[POE]  AS (datediff(year,[doe],getdate())),
	[DEPARTMENT] [varchar](50) NOT NULL,
	[SUB_DEPARTMENT] [varchar](50) NOT NULL,
	[USERNAME] [varchar](50) NOT NULL,
	[PASSCODE] [varchar](50) NOT NULL,
	[STATUS] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PrivStaffHQ] PRIMARY KEY CLUSTERED 
(
	[SysID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Messager]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Messager](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Destination] [nvarchar](50) NOT NULL,
	[Header] [nvarchar](40) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[Sender] [nvarchar](50) NOT NULL,
	[Dept] [nvarchar](50) NOT NULL,
	[Flag] [char](10) NOT NULL,
	[Sent_on] [smalldatetime] NOT NULL,
	[Period]  AS (datediff(day,[sent_on],getdate()))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DairyList]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[DairyList](
	[diff] [varchar](50) NOT NULL,
	[Tagid] [nchar](10) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ItemHq]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ItemHq](
	[Category] [nchar](10) NOT NULL,
	[Item_type] [nchar](50) NOT NULL,
	[Item_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ItemHq] PRIMARY KEY CLUSTERED 
(
	[Item_name] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DairyMilk]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[DairyMilk](
	[Id] [int] NOT NULL,
	[Milking_Day] [smalldatetime] NOT NULL,
	[Time] [nchar](10) NOT NULL,
	[TagID] [nchar](15) NOT NULL,
	[Animal] [nvarchar](50) NOT NULL,
	[Breed] [nvarchar](50) NULL,
	[Calf] [nvarchar](50) NOT NULL,
	[Milk] [int] NOT NULL,
	[Supervisor] [varchar](50) NOT NULL,
	[Uniq] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DairyMilk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[MilkEntrybook]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[MilkEntrybook](
	[Litres] [int] NOT NULL,
	[Pushed_on] [datetime] NOT NULL,
	[TOD] [char](10) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Flagpost]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Flagpost](
	[Leo] [varchar](50) NOT NULL,
	[Flag] [tinyint] NOT NULL,
 CONSTRAINT [PK_Flagpost] PRIMARY KEY CLUSTERED 
(
	[Leo] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FarmasterMilkSales]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[FarmasterMilkSales](
	[Id] [int] NOT NULL,
	[TRNo] [varchar](50) NOT NULL,
	[CustomerID] [varchar](50) NOT NULL,
	[Demand] [int] NOT NULL,
	[Serviced_By] [varchar](50) NOT NULL,
	[Uniq] [varchar](50) NOT NULL,
	[DOS] [smalldatetime] NULL,
 CONSTRAINT [PK_FarmasterMilkSales] PRIMARY KEY CLUSTERED 
(
	[Uniq] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Dailytemp]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Dailytemp](
	[Day] [varchar](50) NOT NULL,
	[Morning_tempratures] [int] NULL,
	[Afternoon_tempratures] [int] NULL,
	[Evening_Tempratures] [int] NULL,
	[Nigth_Tempratures] [int] NULL,
 CONSTRAINT [PK_Dailytemp] PRIMARY KEY CLUSTERED 
(
	[Day] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plantationhq]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Plantationhq](
	[PlotNo] [char](10) NOT NULL,
	[PlotName] [char](10) NOT NULL,
	[Terrain] [varchar](50) NOT NULL,
	[Soil] [varchar](50) NOT NULL,
	[Size_in_Hectares] [char](10) NOT NULL,
	[Manager] [nvarchar](50) NOT NULL,
	[Grade] [char](10) NOT NULL,
	[Vacant] [char](10) NOT NULL,
 CONSTRAINT [PK_Plantationhq] PRIMARY KEY CLUSTERED 
(
	[PlotNo] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[LandUse]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[LandUse](
	[PlantationID] [varchar](50) NOT NULL,
	[PlotNo] [varchar](50) NULL,
	[PlotName] [varchar](50) NULL,
	[Land_Size] [varchar](50) NULL,
	[Crop] [nvarchar](50) NULL,
	[Duration] [varchar](50) NULL,
	[Planted_On] [smalldatetime] NULL,
	[Due] [smalldatetime] NULL,
	[CountDown]  AS (datediff(day,getdate(),[due])),
	[Land_Manager] [nvarchar](50) NULL,
	[Registered_By] [nvarchar](50) NULL,
 CONSTRAINT [PK_LandUse] PRIMARY KEY CLUSTERED 
(
	[PlantationID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[LandGrade]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[LandGrade](
	[Grade] [char](10) NOT NULL,
	[Crop] [nvarchar](50) NOT NULL,
	[Crop_Type] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PLTtable]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[PLTtable](
	[Id] [char](10) NOT NULL,
	[PlotNo] [char](10) NULL,
	[PlantationNo] [char](10) NULL,
	[Crop] [char](20) NULL,
	[Reason] [varchar](50) NULL,
 CONSTRAINT [PK_PLTtable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Storagehq]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Storagehq](
	[ItemBatchNo] [char](20) NOT NULL,
	[Category] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Qtty] [varchar](50) NULL,
	[Units] [char](10) NULL,
	[Supplied_On] [smalldatetime] NULL,
	[Class] [char](10) NULL,
	[Received_By] [nvarchar](50) NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[ItemBatchNo] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[OrderHQ]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[OrderHQ](
	[Id] [int] NOT NULL,
	[ItemOrderID] [nchar](20) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[Item_Type] [varchar](50) NOT NULL,
	[Item_Name] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Units] [char](15) NOT NULL,
	[Ordate] [smalldatetime] NOT NULL,
	[Status] [char](10) NOT NULL,
	[Ordered_by] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OrderHQ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Breed]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Breed](
	[BreedName] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Breed] PRIMARY KEY CLUSTERED 
(
	[BreedName] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[Breed]') AND name = N'IX_Breed')
CREATE NONCLUSTERED INDEX [IX_Breed] ON [dbo].[Breed] 
(
	[BreedName] ASC
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Condition]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Condition](
	[Condition] [nvarchar](10) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[RequestHQ]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[RequestHQ](
	[ID] [int] NOT NULL,
	[ItemReqID] [char](15) NOT NULL,
	[Category] [char](20) NOT NULL,
	[Item_Type] [varchar](50) NOT NULL,
	[Item_Name] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Units] [char](15) NOT NULL,
	[DOReq] [smalldatetime] NOT NULL,
	[Status] [int] NOT NULL,
	[RO] [varchar](50) NOT NULL,
	[Department] [char](16) NOT NULL,
 CONSTRAINT [PK_RequestHQ] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[LandyieldHQ]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[LandyieldHQ](
	[HarvID] [char](10) NOT NULL,
	[PlotID] [char](10) NOT NULL,
	[Crop] [char](10) NOT NULL,
	[Planted_On] [smalldatetime] NOT NULL,
	[Harvested_on] [smalldatetime] NOT NULL,
	[Yield] [int] NOT NULL,
	[Units] [char](20) NOT NULL,
	[Flag] [char](10) NOT NULL,
 CONSTRAINT [PK_LandyieldHQ] PRIMARY KEY CLUSTERED 
(
	[HarvID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DAnimalHQ]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[DAnimalHQ](
	[ID] [int] NOT NULL,
	[TagID] [nvarchar](15) NOT NULL,
	[Animal_Name] [nvarchar](50) NOT NULL,
	[Breed] [nvarchar](10) NOT NULL,
	[Sex] [nvarchar](10) NOT NULL,
	[Parent] [nvarchar](50) NOT NULL,
	[DOB] [smalldatetime] NOT NULL,
	[DOR] [smalldatetime] NOT NULL,
	[DODR] [smalldatetime] NOT NULL,
	[DeRegistered_by] [nvarchar](15) NOT NULL,
	[reason] [nvarchar](10) NOT NULL,
	[Cause] [nvarchar](50) NOT NULL,
	[age] [int] NULL,
 CONSTRAINT [PK_DAnimalHQ] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_customerhq_customerhq]') AND type = 'F')
ALTER TABLE [dbo].[customerhq]  WITH NOCHECK ADD  CONSTRAINT [FK_customerhq_customerhq] FOREIGN KEY([Id])
REFERENCES [dbo].[customerhq] ([Id])
GO
ALTER TABLE [dbo].[customerhq] CHECK CONSTRAINT [FK_customerhq_customerhq]
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_customerhq_customerhq1]') AND type = 'F')
ALTER TABLE [dbo].[customerhq]  WITH NOCHECK ADD  CONSTRAINT [FK_customerhq_customerhq1] FOREIGN KEY([Id])
REFERENCES [dbo].[customerhq] ([Id])
GO
ALTER TABLE [dbo].[customerhq] CHECK CONSTRAINT [FK_customerhq_customerhq1]
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_DAnimalHQ_AnimalHQ]') AND type = 'F')
ALTER TABLE [dbo].[DAnimalHQ]  WITH CHECK ADD  CONSTRAINT [FK_DAnimalHQ_AnimalHQ] FOREIGN KEY([ID])
REFERENCES [dbo].[AnimalHQ] ([ID])
GO
ALTER TABLE [dbo].[DAnimalHQ] CHECK CONSTRAINT [FK_DAnimalHQ_AnimalHQ]
