IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_GetByIsoCode]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_GetByIsoCode] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_GetByIsoCode]
    @IsoCode NVARCHAR(2)
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
    WHERE C.[IsoCode] = @IsoCode;

END