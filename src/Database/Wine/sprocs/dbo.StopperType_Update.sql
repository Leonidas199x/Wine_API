IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[StopperType_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[StopperType_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[StopperType_Update]
    @StopperTypeId INT,
    @Name NVARCHAR(50)
AS
BEGIN

    UPDATE ST
    SET
        ST.[Name] = @Name,
        ST.[UpdatedDate] = GETDATE()
    FROM [dbo].[StopperType] AS ST
    WHERE ST.[ID] = @StopperTypeId;

END