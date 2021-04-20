IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Retailer_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Retailer_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Retailer_Update]
    @RetailerId INT,
    @Name NVARCHAR(50),
    @MinimumPurchaseQuantity TINYINT,
    @IncrementQuantity TINYINT,
    @GenericDiscountPercentage DECIMAL(4,2),
    @GenericDiscountName NVARCHAR(25),
    @WebsiteUrl NVARCHAR(MAX),
    @WebsiteRating TINYINT,
    @OrderRating TINYINT,
    @DeliveryRating TINYINT,
    @MaxCustomerRating TINYINT,
    @Note NVARCHAR(MAX)
AS
BEGIN

    UPDATE R
    SET
        [Name] = @Name,
        [MinimumPurchaseQuantity] = @MinimumPurchaseQuantity,
        [IncrementQuantity] = @IncrementQuantity,
        [GenericDiscountPercentage] = @GenericDiscountPercentage,
        [GenericDiscountName] = @GenericDiscountName,
        [WebsiteUrl] = @WebsiteUrl,
        [WebsiteRating] = @WebsiteRating,
        [OrderRating] = @OrderRating,
        [DeliveryRating] = @DeliveryRating,
        [MaxCustomerRating] = @MaxCustomerRating,
        [Note] = @Note,
        [DateUpdated] = GETDATE()
    FROM [dbo].[Retailer] AS R
    WHERE R.[ID] = @RetailerId;

END