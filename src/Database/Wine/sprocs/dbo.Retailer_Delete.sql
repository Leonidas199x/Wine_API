IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Retailer_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Retailer_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Retailer_Delete]
    @RetailerId INT
AS
BEGIN

    DELETE R
    FROM [dbo].[Retailer] AS R
    WHERE R.[ID] = @RetailerId;

END