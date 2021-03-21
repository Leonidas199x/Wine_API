CREATE TABLE [dbo].[Grapes](
	[GrapeID] [int] IDENTITY(1,1) NOT NULL,
	[GrapeName] [nvarchar](25) NULL,
	[GrapeColourID] [int] NULL,
	[GrapeNote] [nvarchar](max) NULL,
	[GrapeAlternateName] [nvarchar](max) NULL,
	[DateCreated] [datetime2](3) NULL,
	[DateUpdated] [datetime2](3) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]