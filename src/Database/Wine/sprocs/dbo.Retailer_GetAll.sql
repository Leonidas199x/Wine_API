IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Retailer_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Retailer_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Retailer_GetAll]
    @Page INT = 1,
    @PageSize INT = 10
AS
BEGIN

    DECLARE @Offset INT;

    IF(@Page = 1)
    BEGIN 
        SELECT @Offset = 0;
    END
    ELSE
    BEGIN
        SELECT @Offset = (@PageSize * (@Page - 1));
    END

    DECLARE @TotalPages INT;
    
    SELECT @TotalPages = CEILING(CAST(COUNT(R.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[Retailer] R;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages];

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
    ORDER BY R.[Name] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END