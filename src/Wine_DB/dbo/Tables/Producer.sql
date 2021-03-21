CREATE TABLE [dbo].[Producer](
	[ProducerID] [int] IDENTITY(1,1) NOT NULL,
	[ProducerShortNote] [nvarchar](25) NULL,
	[ProducerNote] [nvarchar](50) NULL,
	[DateCreated] [datetime2](3) NULL,
	[DateUpdated] [datetime2](3) NULL,
	[ProducerName] [nvarchar](50) NULL
) ON [PRIMARY]