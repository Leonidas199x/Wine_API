IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineRegion_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineRegion_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineRegion_Insert]
    @Name NVARCHAR(50),
    @RegionId INT,
    @Note NVARCHAR(MAX)
AS
BEGIN

    DECLARE @RunDate DATETIME = GETDATE();

    INSERT INTO [dbo].[WineRegion]
    (
        [Name],
        [RegionId],
        [Note]
    )
    VALUES
    (
        @Name,
        @RegionId,
        @Note
    );

END