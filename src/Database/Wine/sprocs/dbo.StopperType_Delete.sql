IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[StopperType_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[StopperType_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[StopperType_Delete]
    @StopperTypeId INT
AS
BEGIN

    DELETE ST
    FROM [dbo].[StopperType] AS ST
    WHERE ST.[ID] = @StopperTypeId;

END