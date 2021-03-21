IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Lookup_Country]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Lookup_Country] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Lookup_Country]
AS
BEGIN

    SELECT 
        C.[ID],
        C.[Name]
    FROM [dbo].[Country] AS C
    ORDER BY [Name] ASC;

END