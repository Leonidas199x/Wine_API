IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_Lookup]
AS
BEGIN

    SELECT
        C.[ID],
        C.[Name]
    FROM [dbo].[Country] AS C
    ORDER BY C.[Name] ASC;

END