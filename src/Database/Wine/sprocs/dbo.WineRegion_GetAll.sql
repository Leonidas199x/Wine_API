IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineRegion_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineRegion_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineRegion_GetAll]

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
    ORDER BY R.[Name] ASC;

END