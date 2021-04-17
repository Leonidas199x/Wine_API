CREATE TABLE [dbo].[Retailer]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [MinimumPurchaseQuantity] TINYINT NOT NULL,
    [IncrementQuantity] TINYINT NOT NULL,
    [GenericDiscountPercentage] DECIMAL(4,2) NULL,
    [GenericDiscountName] NVARCHAR(25) NULL,
    [WebsiteUrl] NVARCHAR(MAX) NULL,
    [WebsiteRating] TINYINT NULL,
    [OrderRating] TINYINT NULL,
    [DeliveryRating] TINYINT NULL,
    [MaxCustomerRating] TINYINT NOT NULL,
    [Note] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);