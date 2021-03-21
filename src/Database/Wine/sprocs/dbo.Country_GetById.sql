IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_GetById]
    @CountryID	INT
AS
BEGIN

    SELECT
        C.[ID],
        C.[Name],
        C.[Note],
        C.[DateCreated],
        C.[DateUpdated]
    FROM [dbo].[Country] AS C
    WHERE C.[ID] = @CountryID;

END