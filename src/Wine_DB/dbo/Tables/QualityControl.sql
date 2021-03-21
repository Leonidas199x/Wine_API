CREATE TABLE [dbo].[QualityControl](
	[QualityControlID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NULL,
	[QualityControlName] [nvarchar](50) NULL,
	[QualityControlShortNote] [nvarchar](50) NULL,
	[QualityControlNotes] [nvarchar](max) NULL,
	[DateCreated] [datetime2](3) NULL,
	[DateUpdated] [datetime2](3) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]