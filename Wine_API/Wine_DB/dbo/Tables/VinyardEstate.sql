CREATE TABLE [dbo].[VinyardEstate](
	[VinyardEstateID] [int] IDENTITY(1,1) NOT NULL,
	[VinyardEstateName] [nvarchar](50) NULL,
	[VinyardEstateShortNote] [nvarchar](50) NULL,
	[VinyardEstateNote] [nvarchar](max) NULL,
	[DateCreated] [datetime2](3) NULL,
	[DateUpdated] [datetime2](3) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]