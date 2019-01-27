CREATE TABLE [dbo].[WineType](
	[WineTypeID] [int] IDENTITY(1,1) NOT NULL,
	[WineType] [nvarchar](50) NULL,
	[WineTypeNote] [nvarchar](max) NULL,
	[DateCreated] [datetime2](3) NULL,
	[DateUpdated] [datetime2](3) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]