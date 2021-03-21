CREATE TABLE [dbo].[WineRegion](
	[WineRegionID] [int] IDENTITY(1,1) NOT NULL,
	[RegionID] [int] NULL,
	[WineRegionName] [nvarchar](50) NULL,
	[WineRegionNote] [nvarchar](50) NULL,
	[DateCreated] [datetime2](3) NULL,
	[DateUpdated] [datetime2](3) NULL
) ON [PRIMARY]