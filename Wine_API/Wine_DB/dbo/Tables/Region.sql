CREATE TABLE [dbo].[Region](
	[RegionID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NULL,
	[RegionName] [nvarchar](50) NULL,
	[RegionNote] [nvarchar](500) NULL,
	[DateCreated] [datetime2](3) NULL,
	[DateUpdated] [datetime2](3) NULL,
	[LocationRegionImage] [nvarchar](100) NULL
) ON [PRIMARY]