IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Retailer_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Retailer_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Retailer_Lookup]
AS
BEGIN

    SELECT
        R.[ID],
        R.[Name]
    FROM [dbo].[Retailer] AS R
    ORDER BY R.[Name] ASC;

END