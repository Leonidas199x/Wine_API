IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineType_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineType_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineType_Update]
    @WineTypeId INT,
    @Name NVARCHAR(50),
    @Note NVARCHAR(MAX)
AS
BEGIN

    UPDATE WT
    SET
        WT.[Name] = @Name,
        WT.[Note] = @Note,
        WT.[DateUpdated] = GETDATE()
    FROM [dbo].[WineType] AS WT
    WHERE WT.[ID] = @WineTypeId;

END