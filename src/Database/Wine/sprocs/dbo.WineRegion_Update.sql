IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineRegion_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineRegion_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineRegion_Update]
    @ID INT,
    @Name NVARCHAR(50),
    @RegionId INT,
    @Note NVARCHAR(MAX)
AS
BEGIN

    DECLARE @RunDate DATETIME = GETDATE();

    UPDATE WR
    SET
        WR.[Name] = @Name,
        WR.[RegionId] = @RegionId,
        WR.[Note] = @Note
    FROM [dbo].[WineRegion] WR
    WHERE WR.[ID] = @ID;

END