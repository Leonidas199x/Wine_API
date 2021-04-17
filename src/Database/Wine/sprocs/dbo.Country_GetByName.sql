IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_GetByName]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_GetByName] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_GetByName]
    @CountryName NVARCHAR(50)
AS
BEGIN

    SELECT
        C.[ID],
        C.[Name],
        C.[IsoCode],
        C.[Note],
        C.[DateCreated],
        C.[DateUpdated]
    FROM [dbo].[Country] AS C
    WHERE C.[Name] = @CountryName;

END