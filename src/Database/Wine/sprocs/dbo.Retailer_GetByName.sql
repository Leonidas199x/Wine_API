IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Retailer_GetByName]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Retailer_GetByName] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Retailer_GetByName]
    @Name NVARCHAR(50)
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
    WHERE R.[Name] = @Name;

END