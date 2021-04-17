IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineRegion_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineRegion_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineRegion_Delete]
    @WineRegionId INT
AS
BEGIN

    DELETE WR
    FROM [dbo].[WineRegion] AS WR
    WHERE WR.[ID] = @WineRegionId;

END