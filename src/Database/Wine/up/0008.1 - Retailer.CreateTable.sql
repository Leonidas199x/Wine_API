CREATE TABLE [dbo].[Retailer]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [MinimumPurchaseQty] TINYINT NULL,
    [IncrementQuantity] TINYINT NULL,
    [GenericDiscountPercentage] DECIMAL(4, 2) NULL,
    [GenericDiscountName] NVARCHAR(25) NULL,
    [WedSiteRating] TINYINT NULL,
    [OrderRating] TINYINT NULL,
    [DeliveryRating] TINYINT NULL,
    [MaxCustRating] TINYINT NULL,
    [LocationRetailerImage] NVARCHAR(100) NULL,
    [RetailerShortNotes] NVARCHAR(50) NULL,
    [DateCreated] DATETIME2(3) NULL,
    [DateUpdated] DATETIME2(3) NULL
);