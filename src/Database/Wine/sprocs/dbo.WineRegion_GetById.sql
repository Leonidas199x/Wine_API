IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineRegion_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineRegion_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineRegion_GetById]
    @WineRegionId INT
AS
BEGIN

    SELECT
        WR.[ID],
        WR.[Name],
        WR.[RegionId],
        WR.[Note],
        WR.[DateCreated],
        WR.[DateUpdated]
    FROM [dbo].[WineRegion] AS WR
    WHERE WR.[ID] = @WineRegionId;

END