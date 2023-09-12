IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineType_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineType_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineType_Delete]
    @WineTypeId INT
AS
BEGIN

    DELETE WT
    FROM [dbo].[WineType] AS WT
    WHERE WT.[ID] = @WineTypeId;

END