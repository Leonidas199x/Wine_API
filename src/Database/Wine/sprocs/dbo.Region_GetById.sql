IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Region_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Region_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Region_GetById]
    @RegionId INT
AS
BEGIN

    SELECT
        R.[ID],
        R.[CountryID],
        R.[Name],
        R.[Note],
        R.[LocationRegionImage],
        R.[DateCreated],
        R.[DateUpdated]
    FROM [dbo].[Region] AS R
    WHERE R.[ID] = @RegionId;

END