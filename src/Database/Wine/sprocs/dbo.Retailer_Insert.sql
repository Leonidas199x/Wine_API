IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Retailer_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Retailer_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Retailer_Insert]
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

    DECLARE @RunDate DATETIME2(3) = GETDATE();

    INSERT INTO [dbo].[Retailer]
    (
        [Name],
        [MinimumPurchaseQuantity],
        [IncrementQuantity],
        [GenericDiscountPercentage],
        [GenericDiscountName],
        [WebsiteUrl],
        [WebsiteRating],
        [OrderRating],
        [DeliveryRating],
        [MaxCustomerRating],
        [Note],
        [DateCreated],
        [DateUpdated]
    )
    VALUES
    (
        @Name,
        @MinimumPurchaseQuantity,
        @IncrementQuantity,
        @GenericDiscountPercentage,
        @GenericDiscountName,
        @WebsiteUrl,
        @WebsiteRating,
        @OrderRating,
        @DeliveryRating,
        @MaxCustomerRating,
        @Note,
        @RunDate,
        @RunDate
    )

END