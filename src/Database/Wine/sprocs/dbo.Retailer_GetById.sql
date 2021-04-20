IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Retailer_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Retailer_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Retailer_GetById]
    @RetailerId INT
AS
BEGIN

    SELECT
        R.[ID],
        R.[Name],
        R.[MinimumPurchaseQuantity],
        R.[IncrementQuantity],
        R.[GenericDiscountPercentage],
        R.[GenericDiscountName],
        R.[WebsiteUrl],
        R.[WebsiteRating],
        R.[OrderRating],
        R.[DeliveryRating],
        R.[MaxCustomerRating],
        R.[Note],
        R.[DateCreated],
        R.[DateUpdated]
    FROM [dbo].[Retailer] AS R
    WHERE R.[ID] = @RetailerId;

END