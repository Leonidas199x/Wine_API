CREATE TABLE [dbo].[Retailer](
	[RetailerID] [int] IDENTITY(1,1) NOT NULL,
	[RetailerName] [nvarchar](50) NULL,
	[MinimumPurchaseQty] [tinyint] NULL,
	[IncrementQuantity] [tinyint] NULL,
	[GenericDiscountPercentage] [decimal](4, 2) NULL,
	[GenericDiscountName] [nvarchar](25) NULL,
	[WedSiteRating] [tinyint] NULL,
	[OrderRating] [tinyint] NULL,
	[DeliveryRating] [tinyint] NULL,
	[MaxCustRating] [tinyint] NULL,
	[LocationRetailerImage] [nvarchar](100) NULL,
	[RetailerShortNotes] [nvarchar](50) NULL,
	[DateCreated] [datetime2](3) NULL,
	[DateUpdated] [datetime2](3) NULL
) ON [PRIMARY]