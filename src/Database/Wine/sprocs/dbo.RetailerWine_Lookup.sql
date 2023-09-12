IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[RetailerWine_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[RetailerWine_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[RetailerWine_Lookup]
AS
BEGIN

    SELECT 
        RW.[ID],
        RW.[Name]
    FROM [dbo].[RetailerWine] AS RW
    ORDER BY RW.[Name];

END